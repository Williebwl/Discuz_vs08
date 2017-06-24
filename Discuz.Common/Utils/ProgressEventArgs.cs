using System;
using System.Collections.Generic;
using System.Text;

namespace Discuz.Common
{
    public class ProgressEventArgs : System.EventArgs
    {
        /// <summary>
        /// 进度类型
        /// </summary>
        public string MethodType { get; set; }
        /// <summary>
        /// 总长度
        /// </summary>
        public long Length { get; set; }
        /// <summary>
        /// 当前进度
        /// </summary>
        public long Position { get; set; }
    }
}
