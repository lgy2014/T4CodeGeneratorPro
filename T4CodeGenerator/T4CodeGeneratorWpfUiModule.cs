using System.Configuration;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using T4CodeGenerator.Application;
using T4CodeGenerator.EntityFramework;

namespace T4CodeGenerator
{
    [DependsOn(typeof(T4CodeGeneratorDataModule), typeof(T4CodeGeneratorApplicationModule))]
    public class T4CodeGeneratorWpfUiModule : AbpModule
    {
        public override void PreInitialize()
        {
            
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            
        }
    }

}
