using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core
{
    /// <summary>
    /// 表示处理微信中出现的错误
    /// </summary>
    public class WeiXinException : Exception
    {
        public WeiXinException() { }
        public WeiXinException(string message)
            : base(message) { }
        public WeiXinException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
