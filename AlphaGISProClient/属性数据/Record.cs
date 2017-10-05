/*************************************************************
*        文件名：Records.cs                                  *
*        作者：刘鲁豫     学号：1300013278                   *
*        功能：记录类                                        *                    
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaGISProClient
{
    [Serializable]
    public class Record
    {
        #region 字段
        private List<object> _Values = new List<object>();
        #endregion

        #region 构造函数
        /// <summary>
        /// internal，不许外部直接建立
        /// </summary>
        internal Record()
        {

        }

        #endregion


        #region 属性
        public int FieldsCount
        {
            get { return _Values.Count; }
        }
        /// <summary>
        /// 访问制定索引号的值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object GetValue(int index)
        {
            return _Values[index];
        }
        /// <summary>
        /// 设置制定索引号的值
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void SetValue(int index, object value)
        {
            _Values[index] = value;
        }
        /// <summary>
        /// 添加指定索引号的值
        /// </summary>
        internal void Append(object value)
        {
            _Values.Add(value);
        }
        /// <summary>
        /// 删除指定索引号的值
        /// </summary>
        /// <param name="index"></param>
        internal void Delete(int index)
        {
            _Values.RemoveAt(index);
        }

        #endregion
    }
}
