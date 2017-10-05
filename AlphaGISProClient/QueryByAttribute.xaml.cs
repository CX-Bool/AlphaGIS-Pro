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
    /// Interaction logic for QueryAttribute.xaml
    /// </summary>
    public partial class QueryAttribute : Window
    {
        
        public QueryAttribute()
        {
            InitializeComponent();
        }

        

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        //Field list
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }


        //Value list
        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void fieldList_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (fieldList.SelectedIndex != -1)
            {
                textBox.Text += fieldList.SelectedItem as string;
            }
        }

        private void valueList_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (valueList.SelectedIndex != -1)
            {
                textBox.Text += valueList.SelectedItem.ToString();
            }
        }

        //Clear
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            textBox.Text += " " + btn.Content + " ";
        }

        

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            btnApply_Click(sender, e);
            //map.MapMode = Mode.Select;
            this.Close();
        }
    }
}
