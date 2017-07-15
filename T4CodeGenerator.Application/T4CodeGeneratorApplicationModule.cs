using Abp.Modules;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using T4CodeGenerator.Application._SysDatabase.Dto;
using T4CodeGenerator.Application._SysTable.Dto;
using T4CodeGenerator.Application.People.Dto;
using T4CodeGenerator.Core;
using T4CodeGenerator.Core.People;

namespace T4CodeGenerator.Application
{
    [DependsOn(typeof(T4CodeGeneratorCoreModule))]
    public class T4CodeGeneratorApplicationModule:AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Mapper.Initialize(cfg => { 
                cfg.CreateMap<Person, PersonDto>(); 
                cfg.CreateMap<SysTable, SysTableDto>(); 
                cfg.CreateMap<SysDatabase, SysDatabaseDto>();
                cfg.CreateMap<Core.ConnectionInfo, _ConnectionInfo.Dto.ConnectionInfoDto>();
            });

        }
    }
}
