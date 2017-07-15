using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4CodeGenerator.Core;

namespace T4CodeGenerator.EntityFramework.EntityFramework
{
    public class SqliteDbContext:AbpDbContext
    {
        //public virtual IDbSet<ConnectionInfo> ConnectionInfo { get; set; }
        //public virtual IDbSet<__MigrationHistory> __MigrationHistory { get; set; }

        public SqliteDbContext() 
            : base("Default") { }

        public SqliteDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public SqliteDbContext(SQLiteConnection existingConnection)
            : base(existingConnection, false)
        {
        }
    }
}
