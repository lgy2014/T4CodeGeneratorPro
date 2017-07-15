using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data;

namespace T4CodeGeneratorPro
{
    public partial class SeedData
    {
        public string ClassName { get; private set; }
        public string FileName { get; private set; }
        public SysTable Table { get; private set; }
        public SysColumn[] Columns { get; private set; }
        public DataTable DataTable { get; private set; }
        public string NameSpace { get; private set; }

        public SeedData(string tableName, string nameSpace)
        {
            NameSpace = nameSpace;
            DateTime time = DateTime.Now;
            ClassName = string.Format("_{0}_{1}_SeedData", time.ToString("yyyyMMddHHmmss"), tableName);
            FileName = ClassName + ".cs";
            Initialize(tableName);
        }

        private void Initialize(string tableName)
        {
            string sql = string.Format("SELECT * FROM sys.tables AS t WHERE t.name='{0}';", tableName);
            using (var db = new DbContext(Program.connectionString))
            {
                //初始化表参数
                DbRawSqlQuery<SysTable> tables = db.Database.SqlQuery<SysTable>(sql);
                Table = tables.FirstOrDefault();
                db.Database.Connection.Close();

                //初始化列参数

                string sql2 = "SELECT t.name AS user_type,c.name,c.column_id,c.user_type_id,c.is_identity,c.is_nullable,c.max_length,c.collation_name FROM sys.[columns] AS c JOIN sys.types AS t ON t.user_type_id =c.user_type_id WHERE c.[object_id]=" + Table.object_id;
                DbRawSqlQuery<SysColumn> columns = db.Database.SqlQuery<SysColumn>(sql2);
                Columns = columns.Where(a => a.is_identity == false).OrderBy(a => a.column_id).ToArray();//过滤掉自动增长列
                db.Database.Connection.Close();

                //查询表数据

                string sql3 = "SELECT * FROM " + tableName;
                DataTable = db.Database.SqlQueryForDataTatable(sql3);

            }
        }

        public SeedData(string tableName) : this(tableName, "MyNameSpace") { }

        public string TransformText(bool isRun)
        {
            if (DataTable.Rows.Count<1)
            {
                return null;
            }
            return this.TransformText();
        }

        public string Test()
        {
            StringBuilder sqlBuilder = new StringBuilder(1000);
            sqlBuilder.Append("INSERT INTO " + Table.name + "(");
            foreach (var item in Columns)
            {
                sqlBuilder.Append(item.name + ",");
            }
            sqlBuilder.Remove(sqlBuilder.Length - 1, 1);
            sqlBuilder.Append(")Values");

            foreach (DataRow row in DataTable.Rows)
            {
                sqlBuilder.AppendLine("(");
                foreach (var col in Columns)
                {
                    string val = GetVal(col,row);
                    sqlBuilder.Append(val + ",");
                }
                sqlBuilder.Remove(sqlBuilder.Length - 1, 1);
                sqlBuilder.Append("),");
            }
            sqlBuilder.Remove(sqlBuilder.Length - 1, 1);
            sqlBuilder.Append(";");

            return sqlBuilder.ToString();
        }

        private string GetVal(SysColumn col, DataRow row)
        {
            string val = row[col.name].ToString();

            switch (col.user_type)
            {
                case "date":
                case "time":
                case "datetime2":
                case "smalldatetime":
                case "datetime":
                case "char":
                case "varchar":
                case "text":
                    val = "'" + val + "'";
                    break;
                case "nchar":
                case "nvarchar":
                case "ntext":
                    val = "N'" + val + "'";
                    break;
                case "bit":
                case "tinyint":
                case "smallint":
                case "int":
                case "bigint":
                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney":
                case "real":
                case "float":
                    if (string.IsNullOrEmpty(val))
                    {
                        val = "null";
                    }
                    break;
                default:
                    break;
            }
            return val;
        }
    }
}
