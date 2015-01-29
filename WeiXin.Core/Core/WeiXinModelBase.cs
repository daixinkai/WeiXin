using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core
{
    public class WeiXinModelBase : IRespondable
    {
        public override string ToString()
        {
            return WeiXinCommon.Serialize(this);
        }

        public string GetRespond()
        {
            return this.ToString();
        }
    }
}
