using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core
{
    public class ClickButton : Button
    {

        public override ButtonType Type
        {
            get { return ButtonType.Click; }
        }
        /// <summary>
        /// 当前按钮的KEY 
        /// (当点击按钮时,微信会返回此KEY)
        /// </summary>
        public string Key { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Name) || string.IsNullOrEmpty(this.Key))
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            //sb.AppendFormat("{\"type\":\"{0}\",\"name\":\"{1}\",\"key\":\"{2}\"}", "click", "name", "key");
            sb.Append("{\"type\":\"" + this.Type + "\",\"name\":\"" + this.Name + "\",\"key\":\"" + this.Key + "\"}");
            //sb.AppendFormat("12345");
            return sb.ToString();
        }
    }
}
