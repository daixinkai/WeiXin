using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Models
{
    /// <summary>
    /// 语音消息
    /// </summary>
    public class VoiceCustomMessage : CustomMessage
    {
        public override MessageType Msgtype
        {
            get { return MessageType.Voice; }
        }

        public class VoiceModel
        {
            public string Media_ID { get; set; }
        }
    }
}
