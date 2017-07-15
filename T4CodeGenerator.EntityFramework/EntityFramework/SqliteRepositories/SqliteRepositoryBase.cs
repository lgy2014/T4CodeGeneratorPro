using System.Data;
using System.Data.SQLite;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using T4CodeGenerator.Core;
using T4CodeGenerator.Core.IRepositories;

namespace T4CodeGenerator.EntityFramework.EntityFramework.SqliteRepositories
{
    public abstract class SQLiteRepositoryBase<TEntity, TPrimary> :ITransientDependency
    {
        public ILogger Logger { get; set; }
        public ISettingManager SettingManager { get; set; }

        public SQLiteHelper SqLite
        {
            get
            {
                if (null == _sqLite)
                {
                    string connString = SettingManager.GetSettingValue("sqlite");
                    connString = "Data Source=T4CodeGenerator.db;";
                    SQLiteConnection conn = new SQLiteConnection(connString);
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    _sqLite = new SQLiteHelper(cmd);
                }
                return _sqLite;
            }
        }

        private SQLiteHelper _sqLite;

    }

    public abstract class SQLiteRepositoryBase<TEntity> : SQLiteRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        
    }
}
