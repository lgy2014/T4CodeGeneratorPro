using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace T4CodeGeneratorPro
{
    public partial class Migration
    {
        public string ClassName { get;private set; }
        public string FileName { get; private set; }
        public SysTable Table { get;private set; }
        public SysColumn[] Columns { get;private set; }
        public SysIndex SysIndex { get;private set; }
        public SysIndexColumn[] SysIndexClumns { get;private set; }
        public string NameSpace { get;private set; }

        public Migration(string tableName,string nameSpace)
        {
            NameSpace=nameSpace;
            DateTime time = DateTime.Now;
            ClassName = string.Format("_{0}_{1}_Initialize", time.ToString("yyyyMMddHHmmss"), tableName);
            FileName = ClassName + ".cs";
            Initialize(tableName);
        }

        public Migration(string tableName) : this(tableName, "MyNameSpace") { }

        private void Initialize(string tableName)
        {
            string sql = string.Format("SELECT * FROM sys.tables AS t WHERE t.name='{0}';",tableName);
            using (var db = new DbContext(Program.connectionString))
            {
                //初始化表参数
                DbRawSqlQuery<SysTable> tables = db.Database.SqlQuery<SysTable>(sql);
                Table = tables.FirstOrDefault();
                db.Database.Connection.Close();

                //初始化列参数

                string sql2 = "SELECT t.name AS user_type,c.name,c.column_id,c.user_type_id,c.is_identity,c.is_nullable,c.max_length,c.collation_name FROM sys.[columns] AS c JOIN sys.types AS t ON t.user_type_id =c.user_type_id WHERE c.[object_id]=" + Table.object_id;
                DbRawSqlQuery<SysColumn> columns = db.Database.SqlQuery<SysColumn>(sql2);
                Columns = columns.OrderBy(a => a.column_id).ToArray();
                db.Database.Connection.Close();

                //初始化主键参数

                string sql3 = "SELECT * FROM sys.indexes AS i WHERE i.[object_id]="+Table.object_id+" AND i.is_primary_key=1";
                DbRawSqlQuery<SysIndex> sysindexs = db.Database.SqlQuery<SysIndex>(sql3);
                if (sysindexs!=null && sysindexs.Count()>0)
                {
                    SysIndex = sysindexs.FirstOrDefault();
                    db.Database.Connection.Close();

                    StringBuilder sqlBuilder = new StringBuilder(300);
                    sqlBuilder.AppendLine("SELECT ic.[object_id],ic.index_id,ic.index_column_id,ic.column_id");
                    sqlBuilder.AppendLine(",c.name AS [column]");
                    sqlBuilder.AppendLine("FROM sys.index_columns AS ic");
                    sqlBuilder.AppendLine("JOIN sys.[columns] AS c ON c.column_id=ic.column_id");
                    sqlBuilder.AppendLine("WHERE ic.[object_id]=" + Table.object_id + " AND c.[object_id]=" + Table.object_id);
                    sqlBuilder.AppendLine("AND ic.index_id=" + SysIndex.index_id);

                    string sql4 = sqlBuilder.ToString();
                    DbRawSqlQuery<SysIndexColumn> sqlQuery4 = db.Database.SqlQuery<SysIndexColumn>(sql4);
                    SysIndexClumns = sqlQuery4.OrderBy(b => b.column_id).ToArray();
                }
            }
        }

        public void test()
        {
            StringBuilder createBuilder = new StringBuilder(500);
            createBuilder.AppendLine("CREATE TABLE tablename (");

            foreach (var item in Columns)
            {
                string identity = string.Empty;
                if (item.is_identity)
                {
                    identity = " IDENTITY(1,1)";
                }
                string notNull = string.Empty;
                if (!item.is_nullable)
                {
                    notNull = " NOT NULL";
                }

                //createBuilder.AppendLine("\t{0} {1}({2}),"+Environment.NewLine,item.name,item.user_type,item.max_length);
                
            }
            createBuilder.Remove(createBuilder.Length - 1, 1);//移除最后一个逗号。
            //拼接主键
            if (SysIndexClumns != null && SysIndexClumns.Length > 0)
            {
                createBuilder.AppendLine(",PRIMARY KEY(");
                foreach (var item in SysIndexClumns)
                {
                    createBuilder.Append(item.column + ",");
                }
                createBuilder.Remove(createBuilder.Length - 1, 1);//移除最后一个逗号。
                createBuilder.AppendLine(")");
            }

            
            createBuilder.AppendLine(");");
            string sql = createBuilder.ToString();
        }
    }
}
