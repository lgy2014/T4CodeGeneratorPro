using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace CodeTemplate.T4
{
    public partial class Model: IGenerator
    {
        public string ClassName { get; private set; }
        private string _fileName;
        public SysTable Table { get; private set; }
        public SysColumn[] Columns { get; private set; }
        public string NameSpace { get; private set; }
        private string basePath = null;

        public Model(string tableName, string nameSpace, string prefix)
        {
            NameSpace=nameSpace;
            if (string.IsNullOrEmpty(nameSpace))
            {
                NameSpace = "MyNameSpace";
            }
            DateTime time = DateTime.Now;
            string notPrefix = tableName;
            if (!string.IsNullOrEmpty(prefix))
            {
                notPrefix = notPrefix.Replace(prefix, "");
            }
            ClassName = notPrefix;
            basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeFiles");
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            _fileName = Path.Combine(basePath, ClassName + ".cs");
            Initialize(tableName);
        }

        private void Initialize(string tableName)
        {
            string sql = string.Format("SELECT * FROM sys.tables AS t WHERE t.name='{0}';", tableName);
            using (var db = new DbContext(SqlHelper.ConnectionString))
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
            }
        }

        public Model(string tableName) : this(tableName, "MyNameSpace",null) { }

        public string Test()
        {
            StringBuilder modelBuilder = new StringBuilder(500);
            foreach (var item in Columns)
            {
                string _type = GetCLRType(item.user_type);
                modelBuilder.AppendLine("public "+_type+" "+item.name+" { get; set; }");
            }

            return modelBuilder.ToString();
        }

        private string GetCLRType(string type)
        {
            string retType = string.Empty;
            switch (type)
            {
                case "bit":
                    retType = "Boolean";
                    break;
                case "tinyint":
                    retType = "Byte";
                    break;
                case "smallint":
                    retType = "Int16";
                    break;
                case "int":
                    retType = "Int32";
                    break;
                case "bigint":
                    retType = "Int64";
                    break;

                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney":
                    retType = "Decimal";
                    break;
                case "real":
                    retType = "Single";
                    break;
                case "float":
                    retType = "Double";
                    break;

                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                    retType = "String";
                    break;
                case "datetime":
                case "time":
                case "smalldatetime":
                case "datetime2":
                case "timestamp":
                    retType = "DateTime";
                    break;
                case "binary":
                case "varbinary":
                case "image":
                    retType = "Byte[]";
                    break;
                case "uniqueidentifier":
                    retType = "Guid";
                    break;

                case "Variant":
                case "sql_variant":
                    retType = "Object";
                    break;
                default:
                    retType = "Object";
                    break;
            }

            return retType;
        }

        public string FileName
        {
            get
            {
                return _fileName;
            }
        }

        public string TransformTextP()
        {
            return TransformText();
        }

        public void SaveToCodeFile()
        {
            SaveToCodeFile(FileName);
        }

        public void SaveToCodeFile(string filename)
        {
            File.WriteAllText(filename, TransformTextP());
        }
    }
}