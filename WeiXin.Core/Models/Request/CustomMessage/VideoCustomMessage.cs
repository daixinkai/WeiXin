using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Models
{
    /// <summary>
    /// 视频消息
    /// </summary>
    public class VideoCustomMessage : CustomMessage
    {

        public override MessageType Msgtype
        {
            get { return MessageType.Video; }
        }



        public class VideoModel
        {
            public string Media_ID { get; set; }

            public string Thumb_Media_ID { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }
        }
    }
}
