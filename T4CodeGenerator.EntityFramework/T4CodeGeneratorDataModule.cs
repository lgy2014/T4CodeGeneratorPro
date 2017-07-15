using System.Data;
using Abp.Configuration;
using Abp.Dependency;
using Abp.EntityFramework;
using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using T4CodeGenerator.Core;
using T4CodeGenerator.Core.IRepositories;
using T4CodeGenerator.EntityFramework.EntityFramework;
using T4CodeGenerator.EntityFramework.EntityFramework.SqliteRepositories;

namespace T4CodeGenerator.EntityFramework
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(T4CodeGeneratorCoreModule))]
    public class T4CodeGeneratorDataModule:AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
            //增加配置
            Configuration.Settings.Providers.Add<MySettings>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //ISettingManager settingManager = IocManager.Resolve<SettingManager>();

            //Class1 c1 = IocManager.Resolve<Class1>();
            //c1.test();

            //初始化数据库
            string connString = "Data Source=T4CodeGenerator.db;";// settingManager.GetSettingValueForApplication("sqlite");

            //using (SQLiteConnection conn = new SQLiteConnection(connString))
            //{
            //    if (conn.State != ConnectionState.Open)
            //    {
            //        conn.Open();
            //    }
            //    using (SQLiteCommand cmd = new SQLiteCommand(conn))
            //    {
            //        SQLiteHelper helper = new SQLiteHelper(cmd);
            //        Migrations.Configuration init = new Migrations.Configuration();

            //        init.Initiation(helper);
            //    }

            //    conn.Close();
            //}
        }
    }
}
