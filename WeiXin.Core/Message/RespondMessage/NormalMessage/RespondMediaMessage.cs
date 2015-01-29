﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Respond
{
    /// <summary>
    /// 表示带有多媒体ID的消息
    /// </summary>
    public abstract class RespondMediaMessage : RespondNormalMessage
    {
        /// <summary>
        /// 媒体id，可以调用多媒体文件下载接口拉取该媒体
        /// </summary>
        public string MediaId { get; set; }



    }
}
