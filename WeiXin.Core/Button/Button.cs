using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core
{
    /// <summary>
    /// 微信自定义菜单按钮
    /// </summary>
    public abstract class Button : IButton
    {
        /// <summary>
        /// 获取或设置显示名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取该菜单的类型
        /// </summary>
        public abstract ButtonType Type { get; }
    }
}
