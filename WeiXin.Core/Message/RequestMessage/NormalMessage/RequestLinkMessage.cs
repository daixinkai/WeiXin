using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeiXin.Core.Request
{
    /// <summary>
    /// 表示链接消息
    /// </summary>
    public class RequestLinkMessage : RequestNormalMessage
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

            //Title
            tempNode = node.SelectSingleNode("Title");
            if (tempNode == null)
            {
                return null;
            }

            this.Title = tempNode.InnerText;

            //Description
            tempNode = node.SelectSingleNode("Description");
            if (tempNode == null)
            {
                return null;
            }
            this.Description = tempNode.InnerText;

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
                             "<Title><![CDATA[{4}]]></Title>" + Environment.NewLine +
                             "<Description><![CDATA[{5}]]></Description>" + Environment.NewLine +
                             "<Url><![CDATA[{6}]]></Url>" + Environment.NewLine +
                             "<MsgId>{7}</MsgId>" + Environment.NewLine +
                             "</xml>", ToUserName, FromUserName, CreateTime, MsgType, Title, Description, Url, MsgId);
        }


    }
}
