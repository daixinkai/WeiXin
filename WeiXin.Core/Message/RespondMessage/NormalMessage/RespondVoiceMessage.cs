using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeiXin.Core.Respond
{
    /// <summary>
    /// 表示一个语音消息,可用于回复
    /// </summary>
    public class RespondVoiceMessage : RespondMediaMessage
    {

        public RespondVoiceMessage()
        {
            //this.MsgType = MessageType.Voice;
        }

        public override MessageType MsgType
        {
            get { return MessageType.Voice; }
        }

        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format { get; set; }



        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                             "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                             "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                             "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                             "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                             "<MediaId><![CDATA[{4}]]></MediaId>" + Environment.NewLine +
                             "<Format><![CDATA[{5}]]></Format>" + Environment.NewLine +
                             "<MsgId>{6}</MsgId>" + Environment.NewLine +
                             "</xml>", ToUserName, FromUserName, CreateTime, MsgType, MediaId, Format, MsgId);
        }


        //        <xml>
        //<ToUserName><![CDATA[toUser]]></ToUserName>
        //<FromUserName><![CDATA[fromUser]]></FromUserName>
        //<CreateTime>12345678</CreateTime>
        //<MsgType><![CDATA[voice]]></MsgType>
        //<Voice>
        //<MediaId><![CDATA[media_id]]></MediaId>
        //</Voice>
        //</xml>

        public override string GetRespond()
        {
            return string.Format("<xml>" + Environment.NewLine +
                             "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                             "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                             "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                             "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                             "<Voice>" + Environment.NewLine +
                             "<MediaId><![CDATA[{4}]]></MediaId>" + Environment.NewLine +
                             "</Voice>" + Environment.NewLine +
                             "</xml>", ToUserName, FromUserName, CreateTime, MsgType, MediaId);
        }

    }
}
