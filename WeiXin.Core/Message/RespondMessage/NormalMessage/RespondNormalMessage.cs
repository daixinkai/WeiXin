using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Respond
{
    /// <summary>
    /// 表示普通的消息
    /// </summary>
    public abstract class RespondNormalMessage : RespondMessage, IRespondable
    {
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; set; }


    }
}
