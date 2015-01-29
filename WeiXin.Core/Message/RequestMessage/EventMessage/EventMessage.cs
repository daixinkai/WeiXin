using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeiXin.Core.Request
{
    /// <summary>
    /// 表示一个接收的事件消息(subscribe/unsubscribe/CLICK/SCAN/LOCATION/CLICK)
    /// </summary>
    public class EventMessage : RequestMessage
    {
        public EventMessage()
        {
            //this.MsgType = MessageType.Event;
        }

        public EventType Event { get; set; }

        public override MessageType MsgType
        {
            get { return MessageType.Event; }
        }

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

            //事件(subscribe/unsubscribe/CLICK)
            tempNode = node.SelectSingleNode("Event");
            if (tempNode == null)
            {
                return null;
            }

            this.Event = WeiXinCommon.ToEnum<EventType>(tempNode.InnerText);


            return this.ToMessage(node);

            ////事件Key(当Event=CLICK时，使用Key定位具体单击的是哪个菜单项)
            //tempNode = node.SelectSingleNode("EventKey");
            //if (tempNode == null)
            //{
            //    return null;
            //}
            //EventKey = tempNode.InnerText;

            ////标签
            //tempNode = node.SelectSingleNode("Label");
            //if (tempNode != null)
            //{
            //    this.Label = tempNode.InnerText;
            //}

            //return this;
        }

        /// <summary>
        /// 返回具体事件类型
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected RequestMessage ToMessage(XmlNode node)
        {
            RequestMessage message = null;
            switch (this.Event)
            {
                case EventType.Click:
                    ClickEventMessage cm = this.Copy<ClickEventMessage>();
                    cm.EventKey = GetValue(node, "EventKey");
                    message = cm;
                    break;
                case EventType.Scan:
                    //是二维码扫描事件
                    QCodeEventMessage m = this.Copy<QCodeEventMessage>();
                    m.Ticket = GetValue(node, "Ticket");
                    m.EventKey = GetValue(node, "EventKey");
                    message = m;
                    break;
                case EventType.Location:
                    //是地理位置事件
                    LocationEventMessage lm = this.Copy<LocationEventMessage>();
                    lm.Latitude = Convert.ToDouble(GetValue(node, "Latitude"));
                    lm.Longitude = Convert.ToDouble(GetValue(node, "Longitude"));
                    lm.Precision = Convert.ToDouble(GetValue(node, "Precision"));
                    message = lm;
                    break;
                case EventType.View:
                    ViewEventMessage vm = this.Copy<ViewEventMessage>();
                    vm.EventKey = GetValue(node, "EventKey");
                    message = vm;
                    break;
                case EventType.Subscribe:
                    //分2种  用户未关注时，进行关注后的事件推送 / 关注事件
                    string ticekt = GetValue(node, "Ticket");
                    if (ticekt == null)
                    {
                        //是关注事件
                        message = this.Copy<SubscribeEventMessage>();
                    }
                    else
                    {
                        QCodeEventMessage mm = this.Copy<QCodeEventMessage>();
                        mm.Ticket = GetValue(node, "Ticket");
                        mm.EventKey = GetValue(node, "EventKey");
                        message = mm;
                    }
                    break;
                case EventType.UnSubscribe:
                    //是取消关注事件
                    message = this.Copy<SubscribeEventMessage>();
                    break;
                default:
                    message = this;
                    break;
            }


            return message;
        }

        protected string GetValue(XmlNode node, string nodeName)
        {
            XmlNode tempNode = node.SelectSingleNode(nodeName);
            return tempNode == null ? null : tempNode.Value;
        }
        private T Copy<T>() where T : EventMessage, new()
        {
            T t = new T();
            t.CreateTime = this.CreateTime;
            t.Event = this.Event;
            t.FromUserName = this.FromUserName;
            //t.MsgType = this.MsgType;
            t.ToUserName = this.ToUserName;
            t.Node = this.Node;
            return t;
        }

        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                                "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                                "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                                "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                                "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                                "<Event><![CDATA[{4}]]></Event>" + Environment.NewLine +
                                "</xml>", ToUserName, FromUserName, CreateTime, MsgType, Event.ToString());
        }


    }
}
