using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using CodeTemplate.T4;
using CodeTemplate;
using T4CodeGenerator.Application._SysDatabase;
using T4CodeGenerator.Application._SysTable;
using T4CodeGenerator.Application._SysDatabase.Dto;
using T4CodeGenerator.Application._SysTable.Dto;
using Abp.Dependency;
using T4CodeGenerator.ViewModel;
using T4CodeGenerator.Application._ConnectionInfo.Dto;

namespace T4CodeGenerator.CodeGenerate
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class CodeGenerate : Page
    {
        public CodeGenerateViewModel CodeGenerateViewModel { get; set; }
        public CodeGenerate()
        {
            InitializeComponent();
            ViewModelLocator locator = FindResource("Locator") as ViewModelLocator;
            CodeGenerateViewModel = locator.CodeGenerateViewModel2;
            DataContext = locator.CodeGenerateViewModel2;
            Init();
            locator.PersonAppService.Test();
            //CodeGenerateViewModel.ConnectionInfoAppService.GetList();
        }

        private void Init()
        {
            validateType.IsEnabled = false;
            txtUserName.IsEnabled = false;
            password.IsEnabled = false;
            remerber.IsEnabled = false;
        }

        string connectionString = "Server={0};Database={1};Trusted_Connection=True;";
        string _server = string.Empty;
        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbi = server.SelectedItem as ComboBoxItem;
            if (null == cbi)
            {
                return;
            }

            List<SysDatabaseDto> list = CodeGenerateViewModel.SysDatabaseAppService.GetAllDatabase();
            databases.DisplayMemberPath = "name";
            databases.SelectedValuePath = "dbid";
            databases.ItemsSource = list;

            #region MyRegion
            //_server = cbi.Content.ToString();
            //string connStr = string.Format(connectionString, _server, "master");

            //string sql = "select dbid,name from master..SysDatabases";

            //using (var db = new DbContext(connStr))
            //{
            //    DbRawSqlQuery<SysDatabase> dbs = db.Database.SqlQuery<SysDatabase>(sql);
            //    if (dbs == null || dbs.Count() < 1)
            //    {
            //        return;
            //    }

            //    SysDatabase[] dbarr = dbs.ToArray<SysDatabase>();
            //    databases.DisplayMemberPath = "name";
            //    databases.SelectedValuePath = "dbid";
            //    databases.ItemsSource = dbarr;

            //} 
            #endregion

            databases.SelectionChanged += new SelectionChangedEventHandler(databases_SelectionChanged);
        }

        void databases_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SysDatabaseDto _db = databases.SelectedItem as SysDatabaseDto;
            if (null == _db)
            {
                return;
            }

            string connStr = string.Format(connectionString, _server, _db.name);
            SqlHelper.ConnectionString = connStr;
            InitTables(_db.name);
            InitViews(_db.name);
        }

        private void InitViews(string dbName)
        {
            views.ItemsSource = null;

            List<SysTableDto> list = CodeGenerateViewModel.SysTableAppService.GetSysViewsByDbName(dbName);
            if (null==list)
            {
                return;
            }
            views.DisplayMemberPath = "name";
            views.SelectedValuePath = "object_id";
            views.ItemsSource = list;

            views.SelectionChanged += new SelectionChangedEventHandler(tables_SelectionChanged);
        }

        private void InitTables(string dbName)
        {
            tables.ItemsSource = null;

            List<SysTableDto> list = CodeGenerateViewModel.SysTableAppService.GetSystablesByDbName(dbName);
            if (null==list)
            {
                return;
            }
            tables.DisplayMemberPath = "name";
            tables.SelectedValuePath = "object_id";
            tables.ItemsSource = list;

            tables.SelectionChanged += new SelectionChangedEventHandler(tables_SelectionChanged);
        }

        void tables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //全选表
        private void btnAllTables_Click(object sender, RoutedEventArgs e)
        {
            tables.SelectAll();
        }
        //全选视图
        private void btnAllViews_Click(object sender, RoutedEventArgs e)
        {
            views.SelectAll();
        }
        //执行生成代码
        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            ComboBoxItem itemType = T4Template.SelectedItem as ComboBoxItem;
            if (null == itemType)
            {
                return;
            }
            string type = itemType.Content.ToString();

            foreach (var item in tables.SelectedItems)
            {
                SysTable table = item as SysTable;
                if (null !=table)
                {
                    IGenerator gen = GeneratorFactory.GetInstance(type, table.name,txtNamespace.Text,txtPrefix.Text);
                    gen.SaveToCodeFile();
                }
            }
        }
    }
}
