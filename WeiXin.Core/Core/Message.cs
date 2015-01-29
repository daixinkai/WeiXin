using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeiXin.Core
{
    /// <summary>
    /// 表示微信的消息
    /// </summary>
    public abstract class Message
    {

        public Message()
        {
            Initialization();
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected virtual void Initialization() { }

        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public long CreateTime { get; set; }
        /// <summary>
        /// 表示消息类型
        /// </summary>
        public abstract MessageType MsgType { get; }

        public override string ToString()
        {
            return string.Empty;
        }

    }
}
