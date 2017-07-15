using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace T4CodeGeneratorPro
{
    class Program
    {
        public static string connectionString = "Server=.;Database=AudioManager_Pro_empty;Trusted_Connection=True;";
        static void Main(string[] args)
        {
            //m1();

            m2();

            //m3();

            //m4();

            //m5();

            Console.Write("Press any key to continue....");
            Console.ReadKey();
        }

        private static void m5()
        {
            string[] sqlfiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory,"*.sql");
            foreach (var sql in sqlfiles)
            {
                string sqlContent = File.ReadAllText(sql,Encoding.Default);
                Match match = Regex.Match(sql, "\\w+[.]sql$");
                string fileNameNotExt = match.Value.Replace(".sql","");
                Procedure proc = new Procedure(sqlContent, fileNameNotExt, "Business.Migrations.StoredProcedure");
                string ret = proc.TransformText();
                Console.WriteLine(ret);
                File.WriteAllText(proc.FileName, ret);
            }
        }

        private static void m4()
        {
            Model model = new Model("AbpUsers");
            //string ret = model.Test();

            string ret = model.TransformText();

            Console.WriteLine(ret);
            File.WriteAllText(model.FileName, ret);
        }

        private static void m3()
        {
            string[] tables = { "t_Authority", "t_AuthorityManager", "t_DataRule", "t_Dict", "t_Item", "t_ItemClass", "t_Menu", "t_Role", "t_User", "WebConfig" };
            foreach (string tb in tables)
            {
                //if (!tb.Equals("t_Authority"))
                //{
                //    continue;
                //}
                SeedData sd = new SeedData(tb, "Business.Migrations.SeedData");
                string ret2 = sd.TransformText(true);
                if (!string.IsNullOrEmpty(ret2))
                {
                    Console.WriteLine(ret2);
                    File.WriteAllText(sd.FileName, ret2);
                }
            }
        }

        private static void m2()
        {
            using (DbContext db = new DbContext(connectionString))
            {
                //获取column元数据
                string sql = "SELECT * FROM sys.tables";
                DbRawSqlQuery<SysTable> sqlQuery = db.Database.SqlQuery<SysTable>(sql);
                foreach (var item in sqlQuery)
                {
                    Migration m = new Migration(item.name, "Business.Migrations.Create");
                    string codeText = m.TransformText();
                    Console.WriteLine(codeText);
                    File.WriteAllText(m.FileName, codeText);
                    //Thread.Sleep(1000);
                }
            }
        }

        private static void m1()
        {
            string connstr = "Server=.;Database=AudioManager;Trusted_Connection=True;";
            using (DbContext db = new DbContext(connstr))
            {
                //获取table元数据
                //StringBuilder sqlBuilder = new StringBuilder(500);
                //sqlBuilder.AppendLine("SELECT * FROM sys.tables AS t");
                ////sqlBuilder.AppendLine("");

                //DbRawSqlQuery<SysTable> tables = db.Database.SqlQuery<SysTable>(sqlBuilder.ToString());
                //SysTable[] tabs = tables.ToArray<SysTable>();
                //foreach (var item in tabs)
                //{
                //    Console.WriteLine("{0},{1},{2}",item.object_id,item.name,item.type);
                //}



                //获取column元数据
                //string sql = "SELECT t.name AS user_type,c.name,c.column_id,c.user_type_id,c.is_identity,c.is_nullable,c.max_length FROM sys.[columns] AS c JOIN sys.types AS t ON t.user_type_id =c.user_type_id WHERE c.[object_id]=2137058649";
                //DbRawSqlQuery<SystemColumn> sqlQuery = db.Database.SqlQuery<SystemColumn>(sql);

                //StringBuilder sb = new StringBuilder(400);

                //foreach (var item in sqlQuery)
                //{
                //    Console.WriteLine("{0},{1},{2}", item.name, item.user_type, item.is_identity);
                //}
            }
        }
    }

    public class Person
    {
        public int id { get; set; }
        public string fname { get; set; }
        public int age { get; set; }
    }
}
