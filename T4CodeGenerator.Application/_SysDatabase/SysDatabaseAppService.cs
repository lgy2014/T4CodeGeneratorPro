using System.Transactions;
using Abp.Dependency;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using T4CodeGenerator.Application._SysDatabase.Dto;
using T4CodeGenerator.Core;
using T4CodeGenerator.Core.IRepositories;

namespace T4CodeGenerator.Application._SysDatabase
{
    public class SysDatabaseAppService:T4CodeGeneratorAppServiceBase,ISysDatabaseAppService
    {
        private readonly ISysDatabaseRepository _sysDatabaseRepository;

        public SysDatabaseAppService(ISysDatabaseRepository sysDatabaseRepository)
        {
            _sysDatabaseRepository = sysDatabaseRepository;
            Logger = NullLogger.Instance;
        }

        public List<SysDatabaseDto> GetAllDatabase()
        {
            List<SysDatabase> list = _sysDatabaseRepository.GetAllDatabase();
            List<SysDatabaseDto> listDto = new List<SysDatabaseDto>();
            foreach (var item in list)
            {
                SysDatabaseDto dto = AutoMapper.Mapper.Map<SysDatabaseDto>(item);
                listDto.Add(dto);
            }

            return listDto;
        }
    }
}
