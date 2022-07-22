using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TODO.ViewModel.PopItem
{
    [Serializable]
    public class RecordItem : BaseViewModel
    {
        /// <summary>
        /// 索引
        /// </summary>
        private int mIndex;
        public int Index { get => mIndex; set => UpdateProperty(ref mIndex, value); }

        /// <summary>
        /// 待办信息
        /// </summary>
        private string mMessage;
        public string Message { get => mMessage; set => UpdateProperty(ref mMessage, value); }

        /// <summary>
        /// 创建时间
        /// </summary>
        private string mCreateTime;
        public string CreateTime { get => mCreateTime; set => UpdateProperty(ref mCreateTime, value); }


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(Message), Message);
            info.AddValue(nameof(CreateTime), CreateTime);
        }
        public RecordItem(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Message = info.GetString(nameof(Message));
            CreateTime = info.GetString(nameof(CreateTime));
        }
        public RecordItem()
        {

        }
    }
}
