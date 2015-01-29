﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core
{
    /// <summary>
    /// 表示事件的类型
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// 点击事件
        /// </summary>
        Click = 0,
        /// <summary>
        /// 关注事件
        /// </summary>
        Subscribe,
        /// <summary>
        /// 取消关注事件
        /// </summary>
        UnSubscribe,
        /// <summary>
        /// 表示二维码扫描事件
        /// </summary>
        Scan,
        /// <summary>
        /// 表示地理位置事件
        /// </summary>
        Location,
        /// <summary>
        /// 表示页面跳转事件
        /// </summary>
        View
    }
}
