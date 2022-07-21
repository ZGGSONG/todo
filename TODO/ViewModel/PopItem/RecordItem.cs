using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.ViewModel.PopItem
{

    public class RecordItem : BaseViewModel
    {
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

    }
}
