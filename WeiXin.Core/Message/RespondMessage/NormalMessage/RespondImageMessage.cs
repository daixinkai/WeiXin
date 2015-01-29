using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeiXin.Core.Respond
{
    /// <summary>
    /// 表示图片消息,可被回复
    /// </summary>
    public class RespondImageMessage : RespondMediaMessage
    {

        public RespondImageMessage()
        {
            //this.MsgType = MessageType.Image;
        }

        public override MessageType MsgType
        {
            get { return MessageType.Image; }
        }

        /// <summary>
        /// 图片链接
        /// </summary>
        public string PicUrl { get; set; }

        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                             "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                             "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                             "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                             "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                             "<PicUrl><![CDATA[{4}]]></PicUrl>" + Environment.NewLine +
                             "<MediaId><![CDATA[{5}]]></MediaId>" + Environment.NewLine +
                             "<MsgId>{6}</MsgId>" + Environment.NewLine +
                             "</xml>", ToUserName, FromUserName, CreateTime, MsgType, PicUrl, MediaId, MsgId);
        }

        //        <xml>
        //<ToUserName><![CDATA[toUser]]></ToUserName>
        //<FromUserName><![CDATA[fromUser]]></FromUserName>
        //<CreateTime>12345678</CreateTime>
        //<MsgType><![CDATA[image]]></MsgType>
        //<Image>
        //<MediaId><![CDATA[media_id]]></MediaId>
        //</Image>
        //</xml>


        public override string GetRespond()
        {
            return string.Format("<xml>" + Environment.NewLine +
                           "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                           "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                           "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                           "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                           "<Image>" + Environment.NewLine +
                           "<MediaId><![CDATA[{4}]]></MediaId>" + Environment.NewLine +
                           "</Image>" + Environment.NewLine +
                           "</xml>", ToUserName, FromUserName, CreateTime, MsgType, MediaId);
        }

    }
}
