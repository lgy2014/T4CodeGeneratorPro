using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4CodeGenerator.Core;
using T4CodeGenerator.Core.IRepositories;
using T4CodeGenerator.EntityFramework.EntityFramework.SqliteRepositories;

namespace T4CodeGenerator.EntityFramework.EntityFramework.Repositories
{
    public class SysDatabaseRepository : T4CodeGeneratorRepositoryBase<SysDatabase>, ISysDatabaseRepository
    {
        public SysDatabaseRepository(IDbContextProvider<T4CodeGeneratorDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public List<SysDatabase> GetAllDatabase()
        {
            List<SysDatabase> list = null;

            string sql = "select 0 as Id,dbid,name from master..SysDatabases";

            using (var db = new T4CodeGeneratorDbContext("Server=.;Database=master;Trusted_Connection=True;"))
            {
                DbRawSqlQuery<SysDatabase> dbs = db.Database.SqlQuery<SysDatabase>(sql);
                if (dbs == null || dbs.Count() < 1)
                {
                    return null;
                }
                list = dbs.ToList<SysDatabase>();
            }
            return list;
        }
    }
}
