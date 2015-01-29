using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core
{
    /// <summary>
    /// 表示微信菜单
    /// </summary>
    public interface IButton
    {
        /// <summary>
        /// 显示名
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        ButtonType Type { get; }
    }
}
