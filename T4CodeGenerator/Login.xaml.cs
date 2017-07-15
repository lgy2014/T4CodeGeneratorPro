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
using System.Windows.Shapes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Abp.Dependency;

namespace T4CodeGenerator
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window, ISingletonDependency
    {
        protected User user = new User();
        public Login()
        {
            InitializeComponent();
            user.loginName = "administrator";
            user.password = "";
            this.DataContext = user;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
        }
    }

    public class User {
        public string loginName { get; set; }
        public string password { get; set; }
    }

}
