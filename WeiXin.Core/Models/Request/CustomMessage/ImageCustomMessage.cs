using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Models
{
    /// <summary>
    /// 图片消息
    /// </summary>
    public class ImageCustomMessage : CustomMessage
    {
        public override MessageType Msgtype
        {
            get { return MessageType.Image; }
        }

        public ImageCustomMessage.ImageModel Image { get; set; }

        public class ImageModel
        {
            public string Media_ID { get; set; }
        }
    }
}
