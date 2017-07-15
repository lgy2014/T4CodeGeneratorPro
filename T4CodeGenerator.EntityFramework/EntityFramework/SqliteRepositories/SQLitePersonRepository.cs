using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using T4CodeGenerator.Core;
using T4CodeGenerator.Core.IRepositories;
using T4CodeGenerator.Core.People;

namespace T4CodeGenerator.EntityFramework.EntityFramework.SqliteRepositories
{
    public class SQLitePersonRepository :SQLiteRepositoryBase<Person>, IPersonRepository
    {
        public SQLitePersonRepository()
        {
        }
        public void Test()
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
        }

        public int Add(Core.People.Person entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Core.People.Person entity)
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

        public IList<Core.People.Person> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
