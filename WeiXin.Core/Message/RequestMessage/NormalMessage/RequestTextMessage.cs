using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeiXin.Core.Request
{
    /// <summary>
    /// 表示一个文本消息,可以用于回复
    /// </summary>
    public class RequestTextMessage : RequestNormalMessage
    {
        public RequestTextMessage()
        {
            //this.MsgType = MessageType.Text;
        }

        public override MessageType MsgType
        {
            get { return MessageType.Text; }
        }

        public string Content { get; set; }

        protected override RequestMessage Parse()
        {
            var node = this.Node;
            //发送者
            XmlNode tempNode = node.SelectSingleNode("FromUserName");
            if (tempNode == null)
            {
                return null;
            }
            this.FromUserName = tempNode.InnerText;
            //接收者
            tempNode = node.SelectSingleNode("ToUserName");
            if (tempNode == null)
            {
                return null;
            }
            this.ToUserName = tempNode.InnerText;
            //创建时间
            tempNode = node.SelectSingleNode("CreateTime");
            if (tempNode == null)
            {
                return null;
            }
            this.CreateTime = Convert.ToInt64(tempNode.InnerText);

            //消息内容
            tempNode = node.SelectSingleNode("Content");
            if (tempNode == null)
            {
                return null;
            }

            this.Content = tempNode.InnerText;

            //消息ID
            tempNode = node.SelectSingleNode("MsgId");
            if (tempNode == null)
            {
                return null;
            }
            this.MsgId = tempNode.InnerText;

            return this;
        }
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



    }
}
