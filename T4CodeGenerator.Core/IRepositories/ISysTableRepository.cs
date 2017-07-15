using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4CodeGenerator.Core.IRepositories
{
    public interface ISysTableRepository:IRepository<SysTable>
    {
        List<SysTable> GetSystablesByDbName(string dbName);
        List<SysTable> GetSysViewsByDbName(string dbName);
    }
}
