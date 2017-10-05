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
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public string mapName;
        public string server;
        public string port;
        public string username;
        public string password;
        public string database;

        public Login()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(Object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnLogin_Click(Object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            server = textboxServer.Text;
            port = textboxPort.Text;
            username = textboxUsername.Text;
            password = textboxPassword.Password;
        }

        private void btnAdmin_Click(Object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            server = textboxServer.Text;
            port = textboxPort.Text;
            username = textboxUsername.Text;
            password = textboxPassword.Password;
        }
    }
}
