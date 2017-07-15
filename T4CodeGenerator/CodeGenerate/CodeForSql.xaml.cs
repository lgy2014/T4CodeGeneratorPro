using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using T4CodeGenerator.ViewModel;

namespace T4CodeGenerator.CodeGenerate
{
    /// <summary>
    /// CodeForSql.xaml 的交互逻辑
    /// </summary>
    public partial class CodeForSql : Page
    {
        public CodeForSqlViewModel CodeForSqlViewModel { get; set; }

        public CodeForSql()
        {
            InitializeComponent();
            ViewModelLocator locator = FindResource("Locator") as ViewModelLocator;
            if (null !=locator)
            {
                CodeForSqlViewModel = locator.CodeForSqlViewModel2;
            }
            DataContext = CodeForSqlViewModel;
        }
    }
}
