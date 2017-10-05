/*************************************************************
*        文件名：GeoRecordset.cs                             *
*        作者：刘鲁豫     学号：1300013278                   *
*        功能：GeoRecordset类，包括记录和字段和相关方法。    *                                      *                    
*************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaGISProClient
{
    [Serializable]
    public class GeoRecordset
    {
         #region 字段
            private Fields _Fields = new Fields();
            private Records _Records = new Records();
            #endregion

            #region 构造函数
            public GeoRecordset()
            {
                _Fields.FieldAppended +=new Fields.FieldAppendHandle(_Fields_FieldAppended);
                _Fields.FieldDeleted +=new Fields.FieldDeleteHandle(_Fields_FieldDeleted);
                _Records.ToNewRecord +=new Records.ToNewRecordHandle(_Records_ToNewRecord );
            }

            #endregion

            #region 私有函数

        //todo5.27
            private void _Fields_FieldAppended(object sender, Field field)
            {
                int sRecordCount= _Records.Count;
                Field sField = field;
                for(int i=0;i<sRecordCount;i++)
                {
                    Record sRecord=_Records.GetItem(i);
                    if(sField.Valuetype==DBFFileDataTypeConstant.Numeric)
                    {
                        sRecord.Append((double)0);
                    }
                    else 
                    {
                        sRecord.Append(string.Empty);
                    }
                }
            }


           
            private void _Fields_FieldDeleted(object sender, int index,Field field)
            {
                int sRecordCount=_Records.Count;
                for(int i=0;i<sRecordCount;i++)
                {
                    Record sRecord=_Records.GetItem(i);
                    sRecord.Delete(index);
                }
            }


        //todo5.27
            private void _Records_ToNewRecord(object sender, Record record)
            { 
                int sFieldCount=_Fields.Count;
                Record sRecord=record;
                for(int i=0;i<sFieldCount;i++)
                {
                    Field sField=_Fields.GetItem(i);
                    if (sField.Valuetype == DBFFileDataTypeConstant.Numeric)
                    {
                        sRecord.Append((double)0);
                    }
                    else
                    {
                        sRecord.Append("");
                    }
                }
            }

            #endregion

            #region 属性
            public Fields Fields
            {
                get { return _Fields; }
                set { _Fields = value; }
            }

            /// <summary>
            /// 获取记录集合对象
            /// </summary>
            public Records Records
            {
                get { return _Records; }
            }
            #endregion

            #region 方法
            /// <summary>
            /// 读取
            /// </summary>
            /// <param name="fileName"></param>
            /// <returns></returns>
            public bool Open(string fileName)//没有实现
            {
                /*Field sField = new Field("ID", ValueTypeConstant.dbInt);
                _Fields.Append(sField);
                sField = new Field("Geometry", ValueTypeConstant.MultiPolygon);
                _Fields.Append(sField);
                sField = new Field("名称", ValueTypeConstant.dbText);
                _Fields.Append(sField);
                sField = new Field("人口", ValueTypeConstant.dbInt);
                _Fields.Append(sField);
                sField = new Field("GDP", ValueTypeConstant.dbDouble);
                _Fields.Append(sField);

                int sRecordCount = 100;
                Random sRnd = new Random();//生成一个随机数生成器

                for (int i = 0; i < sRecordCount; i++)
                {
                    Record sRecord = _Records.NewRecord();
                    sRecord.SetValue(0, i);
                    sRecord.SetValue(1, null);
                    sRecord.SetValue(2, "北京");
                    sRecord.SetValue(3, sRnd.Next(10000));
                    sRecord.SetValue(4, Math.Round(1000 * sRnd.NextDouble()));
                }*/
                return true;
            }


            public bool Save(string fileName)//没有实现
            {
                return true;
            }
            #endregion

            public object dbDouble { get; set; }
    }
}
