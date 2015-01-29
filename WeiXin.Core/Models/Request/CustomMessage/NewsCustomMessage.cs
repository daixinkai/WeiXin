using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Models
{
    /// <summary>
    /// 图文消息
    /// </summary>
    public class NewsCustomMessage : CustomMessage
    {
        public override MessageType Msgtype
        {
            get { return MessageType.News; }
        }

        public NewsCustomMessage.NewsModel News { get; set; }

        public class NewsModel
        {
          public List<NewsMessageItem> Articles { get; set; }

        }

    }
}
