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
using System.Data;


namespace AlphaGISProClient
{
    /// <summary>
    /// PropertyData.xaml 的交互逻辑
    /// </summary>
    public partial class PropertyData : Window
    {
        private DataTable dt;
        

        public PropertyData()
        {
            InitializeComponent();
        }

        public void SetTable(DataTable input)
        {
            dt = input;
            dataGrid.ItemsSource = dt.DefaultView;
        }

        public void SetData()
        {
            
        }

        private void addField_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void deleteField_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dataGrid_CellEditEnding(Object sender, DataGridCellEditEndingEventArgs e)
        {
            
            
        }
    }
}
