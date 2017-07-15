using System;
using System.Collections.Generic;
using System.Text;

namespace T4CodeGenerator.EntityFramework.EntityFramework.SqliteRepositories
{
    public class SQLiteTable
    {
        public string TableName = "";
        public SQLiteColumnList Columns = new SQLiteColumnList();

        public SQLiteTable()
        { }

        public SQLiteTable(string name)
        {
            TableName = name;
        }
    }
}