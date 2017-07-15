using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4CodeGenerator.Application._ConnectionInfo.Dto;

namespace T4CodeGenerator.Application._ConnectionInfo
{
    public interface IConnectionInfoAppService : IApplicationService
    {
        ConnectionInfoDto GetModel(string server);
        void Add(ConnectionInfoDto connectionInfoDto);

        IList<ConnectionInfoDto> GetList();
    }
}
