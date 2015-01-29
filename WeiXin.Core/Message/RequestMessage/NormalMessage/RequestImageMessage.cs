using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeiXin.Core.Request
{
    /// <summary>
    /// 表示图片消息,可被回复
    /// </summary>
    public class RequestImageMessage : RequestMediaMessage
    {

        public RequestImageMessage()
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

            //媒体ID
            tempNode = node.SelectSingleNode("MediaId");
            if (tempNode == null)
            {
                return null;
            }
            this.MediaId = tempNode.InnerText;

            //创建时间
            tempNode = node.SelectSingleNode("CreateTime");
            if (tempNode == null)
            {
                return null;
            }
            this.CreateTime = Convert.ToInt64(tempNode.InnerText);

            //图片链接
            tempNode = node.SelectSingleNode("PicUrl");
            if (tempNode == null)
            {
                return null;
            }

            this.PicUrl = tempNode.InnerText;

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
                             "<PicUrl><![CDATA[{4}]]></PicUrl>" + Environment.NewLine +
                             "<MediaId><![CDATA[{5}]]></MediaId>" + Environment.NewLine +
                             "<MsgId>{6}</MsgId>" + Environment.NewLine +
                             "</xml>", ToUserName, FromUserName, CreateTime, MsgType, PicUrl, MediaId, MsgId);
        }



    }
}
