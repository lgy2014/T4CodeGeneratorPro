using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4CodeGenerator.Core;
using T4CodeGenerator.Core.IRepositories;

namespace T4CodeGenerator.EntityFramework.EntityFramework.Repositories
{
    public class SysTableRepository : T4CodeGeneratorRepositoryBase<SysTable>, ISysTableRepository
    {
        public SysTableRepository(IDbContextProvider<T4CodeGeneratorDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public List<SysTable> GetSystablesByDbName(string dbName)
        {
            List<SysTable> list = null;

            string sql = "select 0 as Id,[object_id],name,[type] from sys.tables where type='U'";

            using (var db = new T4CodeGeneratorDbContext("Server=.;Database="+dbName+";Trusted_Connection=True;"))
            {
                DbRawSqlQuery<SysTable> dbs = db.Database.SqlQuery<SysTable>(sql);
                if (dbs == null || dbs.Count() < 1)
                {
                    return null;
                }
                list = dbs.ToList<SysTable>();
            }

            return list;
        }

        public List<SysTable> GetSysViewsByDbName(string dbName)
        {
            List<SysTable> list = null;

            string sql = "select 0 as Id, [object_id],name,[type] from sys.views where type='V'";

            using (var db = new T4CodeGeneratorDbContext("Server=.;Database=" + dbName + ";Trusted_Connection=True;"))
            {
                DbRawSqlQuery<SysTable> dbs = db.Database.SqlQuery<SysTable>(sql);
                if (dbs == null || dbs.Count() < 1)
                {
                    return null;
                }
                list = dbs.ToList<SysTable>();
            }

            return list;
        }
    }
}
