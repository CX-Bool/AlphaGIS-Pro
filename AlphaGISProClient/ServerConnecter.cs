using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace AlphaGISProClient
{
    class ServerConnector
    {
        private Byte[] networkStream;
        private TcpClient tcpClient;

        #region public methods
        public void ConnectServer() { }
        public void Login() { }
        public void Logout() { }
        public void UploadShp() { }
        public void DownloadShp() { }
        public void GetProjectSchema() { }
        public void GetLayerSchema() { }
        public void ChangeLayerStatus() { }
        public void GetBitmap() { }
        public void SelectFeatures() { }
        public void QueryByLocation() { }
        public void QueryByAttribute() { }

        #endregion
    }
}
