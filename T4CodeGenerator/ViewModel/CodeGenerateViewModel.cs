using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using T4CodeGenerator.Application._SysDatabase.Dto;
using Abp.Dependency;
using T4CodeGenerator.Application._SysDatabase;
using T4CodeGenerator.Application._SysTable;
using T4CodeGenerator.Application._ConnectionInfo;

namespace T4CodeGenerator.ViewModel
{
    public class CodeGenerateViewModel : ViewModelBase, ISingletonDependency
    {
        public IConnectionInfoAppService ConnectionInfoAppService { get; set; }
        public ISysTableAppService SysTableAppService { get; set; }
        public ISysDatabaseAppService SysDatabaseAppService { get; set; }

        public ObservableCollection<MyItem> dbType2 { get;private set; }
        public ObservableCollection<MyItem> server2 { get;private set; }
        public ObservableCollection<MyItem> validateType2 { get;private set; }

        public ObservableCollection<SysDatabaseDto> databases2 { get; private set; }
        public ObservableCollection<SysDatabaseDto> tables2 { get; private set; }
        public ObservableCollection<SysDatabaseDto> views2 { get; private set; }

        public CodeGenerateViewModel()
        {
            dbType2 = new ObservableCollection<MyItem>();
            server2 = new ObservableCollection<MyItem>();
            validateType2 = new ObservableCollection<MyItem>();

            databases2 = new ObservableCollection<SysDatabaseDto>();
            tables2 = new ObservableCollection<SysDatabaseDto>();
            views2 = new ObservableCollection<SysDatabaseDto>();

            dbType2Selected = new MyItem() { Text = "MS SqlServer", Id = "0" };
            dbType2.Add(dbType2Selected);

            server2Selected = new MyItem() { Text = "localhost" };
            server2.Add(server2Selected);
            server2.Add(new MyItem() { Text = "127.0.0.1"});
            server2.Add(new MyItem() { Text = "."});

            validateType2Selected = new MyItem() { Text = "Windows 身份验证" };
            validateType2.Add(validateType2Selected);
            validateType2.Add(new MyItem() { Text = "Sql Server 身份验证" });

            ConnectCommand = new RelayCommand(ConnectCommand2);
            databasesSelectionChanged = new RelayCommand(databasesSelectionChanged2);
        }

        public MyItem dbType2Selected { get; set; }
        public MyItem server2Selected { get; set; }
        public MyItem validateType2Selected { get; set; }

        public ICommand ConnectCommand { get;private set; }
        public ICommand databasesSelectionChanged { get;private set; }

        private void ConnectCommand2()
        {
        }

        private void databasesSelectionChanged2()
        {
        }
    }

    public class MyItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
