/*************************************************************
*        文件名：Field.cs                                    *
*        作者：刘鲁豫     学号：1300013278                   *
*        功能：记录相关的方法和事件                          *                    
*************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlphaGISProClient
{
    [Serializable]
    public class Records
    {
        #region 字段
        private List<Record> _Records = new List<Record>();

        #endregion

        #region 构造函数
        internal Records() { }

        #endregion

        #region 属性
        /// <summary>
        /// 获取记录数
        /// </summary>
        public int Count
        {
            get { return _Records.Count; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获取制定索引号的记录
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Record GetItem(int index)
        {
            return _Records[index];
        }
        /// <summary>
        /// 新建一条记录，并且返回记录
        /// </summary>
        /// <returns></returns>
        public Record NewRecord()
        {
            Record sRecord = new Record();
            ToNewRecord(this, sRecord);//Todo，建立新字段
            _Records.Add(sRecord);
            return sRecord;
        }
        /// <summary>
        /// 在记录集合的末尾追加指定的记录
        /// </summary>
        /// <param name="record"></param>
        internal void Add(Record record)
        {
            if (record != null)
            {
                _Records.Add(record);
            }
            else
            {
                throw new Exception("Invalid record.");
            }

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            _Records.RemoveAt(index);
        }

        public void Clear()
        {
            _Records.Clear();
        }
        #endregion

        #region 事件

        internal delegate void ToNewRecordHandle(object sender, Record record);
        internal event ToNewRecordHandle ToNewRecord;

        #endregion
    }
}
