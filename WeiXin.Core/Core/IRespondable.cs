using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core
{
    /// <summary>
    /// 一个接口,表示可以回复消息
    /// </summary>
    public interface IRespondable
    {
        /// <summary>
        /// 返回响应信息
        /// </summary>
        /// <returns></returns>
        string GetRespond();
    }
}
