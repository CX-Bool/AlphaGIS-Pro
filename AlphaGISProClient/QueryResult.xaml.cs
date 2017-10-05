using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace AlphaGISProClient
{
    /// <summary>
    /// QueryResult.xaml 的交互逻辑
    /// </summary>
    public partial class QueryResult : Window
    {
        private FeatureCollection source;
        private List<List<int>> list;
        public QueryResult()
        {
            InitializeComponent();
        }

        public QueryResult(FeatureCollection source)
        {
            InitializeComponent();
            
        }

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }
    }

    public class DataRowModel
    {
        public string 字段名 { get; set; }
        public string 值 { get; set; }
        public string 数据类型 { get; set; }
    }
}
