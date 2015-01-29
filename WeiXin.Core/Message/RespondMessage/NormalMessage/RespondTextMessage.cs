using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeiXin.Core.Respond
{
    /// <summary>
    /// 表示一个文本消息,可以用于回复
    /// </summary>
    public class RespondTextMessage : RespondNormalMessage, IRespondable
    {
        public RespondTextMessage()
        {
            //this.MsgType = MessageType.Text;
        }

        public override MessageType MsgType
        {
            get { return MessageType.Text; }
        }

        public string Content { get; set; }

 
        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                             "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                             "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                             "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                             "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                             "<Content><![CDATA[{4}]]></Content>" + Environment.NewLine +
                             "<MsgId>{5}</MsgId>" + Environment.NewLine +
                             "</xml>", ToUserName, FromUserName, CreateTime, MsgType, Content, MsgId);
        }


        //<xml>
        //<ToUserName><![CDATA[toUser]]></ToUserName>
        //<FromUserName><![CDATA[fromUser]]></FromUserName>
        //<CreateTime>12345678</CreateTime>
        //<MsgType><![CDATA[text]]></MsgType>
        //<Content><![CDATA[你好]]></Content>
        //</xml>

        public override string GetRespond()
        {
            return string.Format("<xml>" + Environment.NewLine +
                          "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                          "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                          "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                          "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                          "<Content><![CDATA[{4}]]></Content>" + Environment.NewLine +
                          "</xml>", ToUserName, FromUserName, CreateTime, MsgType, Content);
        }

    }
}
