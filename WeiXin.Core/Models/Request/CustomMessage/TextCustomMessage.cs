using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Models
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class TextCustomMessage : CustomMessage
    {
        public override MessageType Msgtype
        {
            get { return MessageType.Text; }
        }
        public TextCustomMessage.TextModel Text { get; set; }   
        public class TextModel
        {
            public string Content { get; set; }
        }
    }
}
