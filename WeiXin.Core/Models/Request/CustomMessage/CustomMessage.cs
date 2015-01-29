using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Models
{
    /// <summary>
    /// 表示客服消息
    /// </summary>
    public abstract class CustomMessage
    {
        /// <summary>
        /// 普通用户openid
        /// </summary>
        public string Touser { get; set; }
        /// <summary>
        /// 消息类型，文本为text，图片为image，语音为voice，视频消息为video，音乐消息为music，图文消息为news
        /// </summary>
        public abstract MessageType Msgtype { get; }

        public override string ToString()
        {
            return WeiXinCommon.Serialize(this);
        }
    }
}
