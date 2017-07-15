using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CodeGenerator.Core.IRepositories
{
    public interface ISysDatabaseRepository:IRepository<SysDatabase>
    {
        List<SysDatabase> GetAllDatabase();
    }
}
