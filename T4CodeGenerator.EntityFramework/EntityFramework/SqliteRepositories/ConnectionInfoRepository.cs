using Abp.Configuration;
using Abp.Dependency;
using Abp.EntityFramework;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4CodeGenerator.Core;
using T4CodeGenerator.Core.IRepositories;

namespace T4CodeGenerator.EntityFramework.EntityFramework.SqliteRepositories
{
    public class ConnectionInfoRepository:SQLiteRepositoryBase<ConnectionInfo>,IConnectionInfoRepository
    {
        public int Add(ConnectionInfo entity)
        {
            throw new NotImplementedException();
        }

        public int Update(ConnectionInfo entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public int Count(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<ConnectionInfo> GetList()
        {
            List<ConnectionInfo> list = new List<ConnectionInfo>();
            string sql = "select * from ConnectionInfo;";
            DataTable dt = SqLite.Select(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new ConnectionInfo()
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        FServer = row["FServer"].ToString(),
                        FType = int.Parse(row["FType"].ToString()),
                        FUserId = row["FUserId"].ToString(),
                        FPassword = row["FPassword"].ToString(),
                        FRemember = int.Parse(row["FRemember"].ToString())
                    });
                }
            }

            return list;


            //string connString = null;//SettingManager.GetSettingValue("sqlite");
            //connString = "Data Source=T4CodeGenerator.db;";
            //using (SQLiteConnection conn = new SQLiteConnection(connString))
            //{
            //    if (conn.State != ConnectionState.Open)
            //    {
            //        conn.Open();
            //    }
            //    using (SQLiteCommand cmd = new SQLiteCommand(conn))
            //    {
            //        SQLiteHelper helper = new SQLiteHelper(cmd);

            //        string sql = "select * from ConnectionInfo;";
            //        DataTable dt = helper.Select(sql);
            //        if (dt != null && dt.Rows.Count > 0)
            //        {
            //            foreach (DataRow row in dt.Rows)
            //            {
            //                list.Add(new ConnectionInfo()
            //                {
            //                    Id = int.Parse(row["Id"].ToString()),
            //                    FServer = row["FServer"].ToString(),
            //                    FType = int.Parse(row["FType"].ToString()),
            //                    FUserId = row["FUserId"].ToString(),
            //                    FPassword = row["FPassword"].ToString(),
            //                    FRemember = int.Parse(row["FRemember"].ToString())
            //                });
            //            }
            //        }
            //    }

            //    conn.Close();
            //}
            //return list;
        }
    }
}
