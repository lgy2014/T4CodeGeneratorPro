using System.Collections;
using Abp.Dependency;
using AutoMapper;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4CodeGenerator.Application._ConnectionInfo.Dto;
using T4CodeGenerator.Core;
using T4CodeGenerator.Core.IRepositories;

namespace T4CodeGenerator.Application._ConnectionInfo
{
    public class ConnectionInfoAppService:T4CodeGeneratorAppServiceBase,IConnectionInfoAppService
    {
        private readonly IConnectionInfoRepository _repository;
        public IIocResolver Resolver { get; set; }
        public ConnectionInfoAppService(IConnectionInfoRepository repository)
        {
            _repository = repository;
            Logger = NullLogger.Instance;
        }



        public ConnectionInfoDto GetModel(string server)
        {
            return null;
        }

        public void Add(ConnectionInfoDto connectionInfoDto)
        {

        }


        public IList<ConnectionInfoDto> GetList()
        {
            IList<ConnectionInfo> list = _repository.GetList();
            
            foreach (ConnectionInfo info in list)
            {
                Logger.Debug(info.ToString());
            }

            return null;
        }
    }
}
