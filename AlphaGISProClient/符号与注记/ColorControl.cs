/*************************************************************
*         文件名：ColorControl.cs                            *
*         作者：陈旭     学号：1300012421                    *
*         功能：管理颜色，获取唯一值颜色，                   *
*         根据起始颜色、结束颜色、分级数来获得分级颜色       *
******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AlphaGISProClient
{
    public class ColorControl
    {
        public static Color[] UniqueColor = new Color[] {
            Color.AliceBlue,Color.Aquamarine,Color.Azure,//3
            Color.Beige,Color.Blue,Color.BlueViolet,Color.Brown,//7
            Color.CadetBlue,Color.Chocolate,Color.Coral,Color.Cornsilk,Color.Cyan,//12
            Color.DarkBlue,Color.DarkCyan,Color.DarkGray,Color.DarkGreen,Color.DarkOrange,Color.DodgerBlue,//18
            Color.Firebrick,Color.FloralWhite,Color.ForestGreen,//21
            Color.Gainsboro,Color.Gold,Color.Gray,Color.Green,//25
            Color.Honeydew,Color.HotPink,//27
            Color.IndianRed,Color.Ivory,//29
            Color.Khaki,//30
            Color.Lavender,Color.LemonChiffon,Color.LightSteelBlue,Color.Lime,//34
            Color.Magenta,Color.Maroon,Color.MistyRose,//37
            Color.NavajoWhite,Color.Navy,//39
            Color.Olive,Color.Orange,Color.Orchid,//42
            Color.PaleGoldenrod,Color.Peru,Color.Pink,Color.Purple,//46
            Color.Red,Color.RoyalBlue,//48
            Color.Salmon,Color.SeaGreen,Color.Silver,Color.SteelBlue,//52
            Color.Tan,Color.Tomato,Color.Turquoise,//55
            Color.Violet,//56
            Color.White,//57
            Color.Yellow,//58
        };
        //根据起始颜色、结束颜色、分级数来获得分级颜色
        public static Color[] GetLinearColorList(Color startcolor, Color endcolor, int num)
        {
            Color[] colorarray = new Color[num];
            int internal_A = (endcolor.A - startcolor.A) / (num - 1);
            int internal_R = (endcolor.R - startcolor.R) / (num - 1);
            int internal_G = (endcolor.G - startcolor.G) / (num - 1);
            int internal_B = (endcolor.B - startcolor.B) / (num - 1);
            colorarray[0] = startcolor;
            colorarray[num - 1] = endcolor;
            for (int i = 1; i < num - 1; i++)
            {
                colorarray[i] = Color.FromArgb(startcolor.A + i * internal_A,
                    startcolor.R + i * internal_R, startcolor.G + i * internal_G, startcolor.B + i * internal_B);
            }
            return colorarray;
        }

    }
}
