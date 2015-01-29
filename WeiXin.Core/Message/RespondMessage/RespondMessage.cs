using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Respond
{
    /// <summary>
    /// 表示响应的消息
    /// </summary>
    public abstract class RespondMessage : Message, IRespondable
    {
        public RespondMessage()
        {
            this.CreateTime = Convert.ToInt64(DateTime.Now.Ticks.ToString(System.Globalization.CultureInfo.InvariantCulture));
        }
        public virtual string GetRespond()
        {
            return this.ToString();
        }
    }
}
