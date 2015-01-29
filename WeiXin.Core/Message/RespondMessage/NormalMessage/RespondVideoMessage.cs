using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeiXin.Core.Respond
{
    /// <summary>
    /// 表示视频消息,可用于回复
    /// </summary>
    public class RespondVideoMessage : RespondMediaMessage
    {

        public RespondVideoMessage()
        {
            //this.MsgType = MessageType.Video;
        }

        public override MessageType MsgType
        {
            get { return MessageType.Video; }
        }

        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId { get; set; }


        /// <summary>
        /// 视频消息的标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 视频消息的描述
        /// </summary>
        public string Description { get; set; }

 

        public override string ToString()
        {
            return string.Format("<xml>" + Environment.NewLine +
                             "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                             "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                             "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                             "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                             "<MediaId><![CDATA[{4}]]></MediaId>" + Environment.NewLine +
                             "<ThumbMediaId><![CDATA[{5}]]></ThumbMediaId>" + Environment.NewLine +
                             "<MsgId>{6}</MsgId>" + Environment.NewLine +
                             "</xml>", ToUserName, FromUserName, CreateTime, MsgType, MediaId, ThumbMediaId, MsgId);
        }


        //        <xml>
        //<ToUserName><![CDATA[toUser]]></ToUserName>
        //<FromUserName><![CDATA[fromUser]]></FromUserName>
        //<CreateTime>12345678</CreateTime>
        //<MsgType><![CDATA[video]]></MsgType>
        //<Video>
        //<MediaId><![CDATA[media_id]]></MediaId>
        //<Title><![CDATA[title]]></Title>
        //<Description><![CDATA[description]]></Description>
        //</Video> 
        //</xml>

        public override string GetRespond()
        {
            return string.Format("<xml>" + Environment.NewLine +
                                "<ToUserName><![CDATA[{0}]]></ToUserName>" + Environment.NewLine +
                                "<FromUserName><![CDATA[{1}]]></FromUserName>" + Environment.NewLine +
                                "<CreateTime>{2}</CreateTime>" + Environment.NewLine +
                                "<MsgType><![CDATA[{3}]]></MsgType>" + Environment.NewLine +
                                "<Video>" + Environment.NewLine +
                                "<MediaId><![CDATA[{4}]]></MediaId>" + Environment.NewLine +
                                "<Title><![CDATA[{5}]]></Title>" + Environment.NewLine +
                                "<Description><![CDATA[{6}]]></Description>" + Environment.NewLine +
                                "</Video>" + Environment.NewLine +
                                "</xml>", ToUserName, FromUserName, CreateTime, MsgType, MediaId, Title, Description);
        }

    }
}
