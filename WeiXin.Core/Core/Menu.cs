using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core
{
    /// <summary>
    /// 表示一个菜单
    /// </summary>
    public class Menu
    {

        public Menu()
        {
            this.Buttons = new List<IButton>();
            this.MaxCount = 3;
        }

        /// <summary>
        /// 获取当前菜单的按钮集合
        /// </summary>
        public ICollection<IButton> Buttons { get; private set; }


        public bool Add(IButton button)
        {
            if (this.Buttons.Count>this.MaxCount)
            {
                return false;
            }
            this.Buttons.Add(button);
            return true;
        }


        /// <summary>
        /// 获取或设置最大菜单数量
        /// </summary>
        public int MaxCount { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"button\":[");
            int count = this.Buttons.Count;
            if (count > 0)
            {
                int index = 0;
                foreach (var item in this.Buttons)
                {
                    index++;
                    if (index > MaxCount)
                    {
                        break;
                    }
                    sb.Append(item.ToString());
                    if (index < count && index < MaxCount)
                    {
                        sb.Append(",");
                    }
                }
            }
            sb.Append("]}");
            return sb.ToString();
        }


    }
}
