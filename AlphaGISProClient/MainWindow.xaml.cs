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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Fluent;

namespace AlphaGISProClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region private functions
        private void btnOpenProject() { }
        private void btnNewLayer() { }
        private void btnUploadData() { }
        private void btnSelect() { }
        private void btnPan() { }
        private void btnZoomIn() { }
        private void btnZoomOut() { }
        private void btnFullExtent() { }
        private void btnIdentify() { }
        private void btnQueryByLocation() { }
        private void btnQueryByAttribute() { }
        private void btnProjection() { }
        private void btnStyle() { }
        private void btnLabel() { }
        private void treeviewClick() { }
        private void treeviewDragDrop() { }
        private void statusbarRefresh() { }
        private void mapcontrolRefresh() { }
        #endregion
    }
}
