using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4CodeGenerator.Application._SysDatabase.Dto;

namespace T4CodeGenerator.Application._SysDatabase
{
    public interface ISysDatabaseAppService : IApplicationService
    {
        List<SysDatabaseDto> GetAllDatabase();
    }
}
