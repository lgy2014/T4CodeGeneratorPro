using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using T4CodeGenerator.Core.People;

namespace T4CodeGenerator.Core.IRepositories
{
    public interface IPersonRepository : ISQLiteRepository<Person>
    {
        void Test();
    }
}
