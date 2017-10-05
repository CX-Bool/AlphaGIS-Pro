using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaGISProClient.Network
{
    [Serializable]
    public class NetworkStream
    {
        public Command command = null;
        public Data data = null;
    }

    [Serializable]
    public class Command
    {
        public ClientOperation clientOperation = ClientOperation.None;
        public string nameofObject = string.Empty;
        public int indexFrom = -1;
        public int indexTo = -1;
        public bool boolean = false;
        public string sql = string.Empty;
        public string newname = string.Empty;
    }

    [Serializable]
    public class Data
    {
        public Byte[] byteArrayImage = null;
        public GeoRecordset geoRecordsetSelected = null;
        public PointD pointClick = null;
        public Rectangle rectangleSelect = null;
        public Renderer renderer = null;
        public Label label = null;
        public string labelString = null;

    }

    [Serializable]
    public enum ClientOperation
    {
        None,
        NewProject, DeleteProject, OpenProject, RenameProject,
        UploadShapefile, DeleteShapefile, DownloadShapefile,
        AddLayer, RemoveLayer, SetLayerVisibility, MoveLayer, SetLayerStyle,
        SetMapScale, SetMapOffset, SetMapProjection,
        SelectByPoint, SelectByRectangle,
        GetLayerAttributes, 
        Query,
        Analyze,
        DownloadMap,
        AddFeature, DeleteFeature,
        AddField, DeleteField
    }
}
