using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WeiXin.Core.Request;
using WeiXin.Core.Respond;

namespace WeiXin.Core
{
    /// <summary>
    /// 表示接收的消息
    /// </summary>
    public abstract class RequestMessage : Message
    {
        /// <summary>
        /// 获取或设置接收的XML数据
        /// </summary>
        protected XmlNode Node { get; set; }

        /// <summary>
        /// 将xml文档转换为具体的接收实例
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected abstract RequestMessage Parse();

        /// <summary>
        /// 从当前消息创建一个用于回复的消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ToRespondMessage<T>() where T : RespondMessage, new()
        {
            return new T()
            {
                FromUserName = this.ToUserName,
                ToUserName = this.FromUserName,
                CreateTime = this.CreateTime
            };
        }


        /// <summary>
        /// 得到具体的消息处理实例
        /// </summary>
        /// <param name="xmlStream"></param>
        /// <returns></returns>
        public static RequestMessage GetInstance(Stream xmlStream)
        {
            if (xmlStream == null || xmlStream.Length == 0)
            {
                return null;
            }
            //得到请求的内容
            byte[] bytes = new byte[xmlStream.Length];
            xmlStream.Read(bytes, 0, (int)xmlStream.Length);
            string xml = Encoding.UTF8.GetString(bytes);
            return GetInstance(xml);
        }
        /// <summary>
        /// 得到具体的消息处理实例
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static RequestMessage GetInstance(string xml)
        {
            XmlDocument doc = new XmlDocument();
            RequestMessage message = null;
            try
            {
                doc.LoadXml(xml);
                XmlNode firstNode = doc.FirstChild;
                if (firstNode == null)
                {
                    return null;
                }
                //消息类型
                XmlNode tempNode = firstNode.SelectSingleNode("MsgType");
                if (tempNode == null)
                {
                    return null;
                }
                message = GetInstance(WeiXinCommon.ToEnum<MessageType>(tempNode.InnerText));
                if (message != null)
                {
                    message.Node = firstNode;
                    return message.Parse();
                }
                return message;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static RequestMessage GetInstance(MessageType type)
        {
            switch (type)
            {
                case MessageType.Text: return new RequestTextMessage();
                case MessageType.Image: return new RequestImageMessage();
                case MessageType.Link: return new RequestLinkMessage();
                case MessageType.Location: return new RequestLocationMessage();
                case MessageType.Music: return new RequestMusicMessage();
                case MessageType.News: return null;
                case MessageType.Video: return new RequestVideoMessage();
                case MessageType.Voice: return new RequestVoiceMessage();
                case MessageType.Event: return new EventMessage();
                default: return null;
            }
        }
    }
}
