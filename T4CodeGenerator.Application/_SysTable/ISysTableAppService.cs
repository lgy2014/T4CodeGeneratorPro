using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4CodeGenerator.Application._SysTable.Dto;

namespace T4CodeGenerator.Application._SysTable
{
    public interface ISysTableAppService:IApplicationService
    {
        List<SysTableDto> GetSystablesByDbName(string dbName);
        List<SysTableDto> GetSysViewsByDbName(string dbName);
    }
}
