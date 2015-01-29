using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core
{
    /// <summary>
    /// 菜单的类型
    /// </summary>
    public enum ButtonType
    {
        /// <summary>
        /// 事件菜单(点击会向服务器发送事件)
        /// </summary>
        Click = 0,
        /// <summary>
        /// 网页菜单(点击直接跳转url)
        /// </summary>
        View = 1,

        /// <summary>
        /// 包含子菜单的菜单
        /// </summary>
        Parent = 2
    }
}
