using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeiXin.Core.Respond
{
    /// <summary>
    /// 表示链接消息
    /// </summary>
    public class RespondLinkMessage : RespondNormalMessage
    {

        public override MessageType MsgType
        {
            get { return MessageType.Link; }
        }

        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 消息描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 消息链接
        /// </summary>
        public string Url { get; set; }


        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                             "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                             "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                             "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                             "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                             "<Title><![CDATA[{4}]]></Title>" + Environment.NewLine +
                             "<Description><![CDATA[{5}]]></Description>" + Environment.NewLine +
                             "<Url><![CDATA[{6}]]></Url>" + Environment.NewLine +
                             "<MsgId>{7}</MsgId>" + Environment.NewLine +
                             "</xml>", ToUserName, FromUserName, CreateTime, MsgType, Title, Description,Url, MsgId);
        }


    }
}
