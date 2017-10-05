/*************************************************************
*        文件名：Constant.cs                                 *
*        作者：伍昕钰     学号：1100012443                   *
*        功能：ESRI 文件相关常量                             *      
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaGISProClient
{
    /// <summary>
    /// 字段值类型常数
    /// </summary>
    public enum ValueTypeConstant
    {
        Point = 1,
        PolyLine = 3,
        Polygon = 5,
        Int = 10,
        Double = 11,
        Text = 12
    }

    public enum DBFFileDataTypeConstant
    {
        Binary = 'B',
        Char = 'C',
        Date = 'D',
        General = 'G',
        Numeric = 'N',
        Logical = 'L',
        Memo = 'M'
    }
}
