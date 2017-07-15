using System.Collections.Generic;
using System.IO.Ports;
using T4CodeGenerator.EntityFramework.EntityFramework.SqliteRepositories;

namespace T4CodeGenerator.EntityFramework.Migrations
{
    internal class Configuration
    {
        public void Initiation(SQLiteHelper sqLiteHelper)
        {
            Create(sqLiteHelper);
            Seed(sqLiteHelper);
        }

        private void Seed(SQLiteHelper sqLiteHelper)
        {
            long l = sqLiteHelper.LastInsertRowId();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("Id", l);
            dict.Add("FServer", ".");
            dict.Add("FType", 1);
            dict.Add("FUserId", "sa");
            dict.Add("FPassword", "");
            dict.Add("FRemember", 0);
            sqLiteHelper.Insert("ConnectionInfo", dict);
        }

        private void Create(SQLiteHelper sqLiteHelper)
        {
            //ConnectionInfo
            SQLiteTable connInfo = new SQLiteTable("ConnectionInfo");
            connInfo.Columns.Add(new SQLiteColumn("Id",ColType.Integer));
            connInfo.Columns.Add(new SQLiteColumn("FServer", ColType.Text));
            connInfo.Columns.Add(new SQLiteColumn("FType", ColType.Integer));
            connInfo.Columns.Add(new SQLiteColumn("FUserId", ColType.Text));
            connInfo.Columns.Add(new SQLiteColumn("FPassword", ColType.Text));
            connInfo.Columns.Add(new SQLiteColumn("FRemember", ColType.Integer));

            sqLiteHelper.CreateTable(connInfo);



        }
    }
}
