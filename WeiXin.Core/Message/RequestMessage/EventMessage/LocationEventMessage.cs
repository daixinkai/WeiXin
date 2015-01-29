using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Request
{
    /// <summary>
    /// 表示地理信息事件
    /// 用户同意上报地理位置后，每次进入公众号会话时，都会在进入时上报地理位置，或在进入会话后每5秒上报一次地理位置，公众号可以在公众平台网站中修改以上设置。上报地理位置时，微信会将上报地理位置事件推送到开发者填写的URL。
    /// </summary>
    public class LocationEventMessage : EventMessage
    {
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// 地理位置精度
        /// </summary>
        public double Precision { get; set; }

        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                                "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                                "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                                "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                                "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                                "<Event><![CDATA[{4}]]></Event>" + Environment.NewLine +
                                "<Latitude>{5}</Latitude>" + Environment.NewLine +
                                "<Longitude>{6}</Longitude>" + Environment.NewLine +
                                "<Precision>{7}</Precision>" + Environment.NewLine +
                                "</xml>", ToUserName, FromUserName, CreateTime, MsgType, Event.ToString(), Latitude, Longitude, Precision);
        }
    }
}
