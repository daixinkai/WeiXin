using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeiXin.Core.Request
{
    /// <summary>
    /// 音乐消息,用于回复
    /// </summary>
    [Obsolete("暂时用于回复")]
    public class RequestMusicMessage : RequestMediaMessage
    {

        public RequestMusicMessage()
        {
            //this.MsgType = MessageType.Music;
        }

        public override MessageType MsgType
        {
            get { return MessageType.Music; }
        }

        /// <summary>
        /// 音乐标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 音乐描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 音乐链接
        /// </summary>
        public string MusicUrl { get; set; }

        /// <summary>
        /// 高质量音乐链接，WIFI环境优先使用该链接播放音乐
        /// </summary>
        public string HQMusicUrl { get; set; }
        /// <summary>
        /// 缩略图的媒体id，通过上传多媒体文件，得到的id
        /// </summary>
        public string ThumbMediaId { get; set; }



        protected override RequestMessage Parse()
        {
            var node = this.Node;
            throw new Exception("暂时用于回复");
        }

    }
}
