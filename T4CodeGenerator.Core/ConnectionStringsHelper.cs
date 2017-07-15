/*
 * Content:Sql Server连接字符串生成类
 * Author:刘光印
 * Create:2017-3-16 10:11:51
 * Modify:2017-3-16 10:12:01
 * Description:
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CodeGenerator.Core
{
    /// <summary>
    /// Sql Server连接字符串生成类
    /// </summary>
    public sealed class ConnectionStringsHelper
    {
        private static ConnectionStringsHelper _instance;
        private static object obj = new object();

        public static ConnectionStringsHelper Instance
        {
            get
            {
                if (null ==_instance)
                {
                    lock (obj)
                    {
                        if (null==_instance)
                        {
                            _instance = new ConnectionStringsHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        private ConnectionStringsHelper()
        {
        }

        /// <summary>
        /// Standard Security
        /// </summary>
        /// <param name="server"></param>
        /// <param name="database"></param>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns>Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;</returns>
        public string StandardSecurity(string server,string database,string userId,string password)
        {
            return StandardSecurity(server, null, userId, password);
        }

        /// <summary>
        /// Connection to a SQL Server instance
        /// </summary>
        /// <param name="server"></param>
        /// <param name="instance"></param>
        /// <param name="database"></param>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns>Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername;Password=myPassword;</returns>
        public string StandardSecurity(string server,string instance, string database, string userId, string password)
        {
            string connection = "Server={0};Database={1};User Id={2};Password={3};";
            if (!string.IsNullOrEmpty(instance))
            {
                server = server + "\\" + instance;
            }
            return string.Format(connection, server, database, userId, password);
        }

        /// <summary>
        /// Trusted Connection
        /// </summary>
        /// <param name="server"></param>
        /// <param name="database"></param>
        /// <returns>Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;</returns>
        public string StandardSecurity(string server, string database)
        {
            string connection = "Server={0};Database={1};Trusted_Connection=True;";
            return string.Format(connection, server, database);
        }



        /// <summary>
        /// Sqlite Basic Version 3
        /// </summary>
        /// <param name="dataSource">数据库文件物理路径</param>
        /// <returns>Data Source=c:\mydb.db;Version=3;</returns>
        public string SqliteBasicV3(string dataSource)
        {
            string connection="Data Source={0};Version=3;";
            return string.Format(connection,dataSource);
        }

        /// <summary>
        /// Sqlite Basic Version 2
        /// </summary>
        /// <param name="dataSource">数据库文件物理路径</param>
        /// <returns>Data Source=c:\mydb.db;Version=3;</returns>
        public string SqliteBasicV2(string dataSource)
        {
            string connection = "Data Source={0};";
            return string.Format(connection, dataSource);
        }
    }
}
