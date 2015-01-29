using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core
{
    /// <summary>
    /// 一个接口,表示可以处理微信指令
    /// </summary>
    public interface IInstructionable : IWeiXinable
    {
        /// <summary>
        /// 检查指令是否与消息相匹配
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        bool IsMatch(RequestMessage message);
        /// <summary>
        /// 分析消息内容并返回响应内容
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        IRespondable GetRespond(RequestMessage message);
    }
}
