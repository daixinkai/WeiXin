using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Models
{
    /// <summary>
    /// 表示微信接口的响应状态
    /// </summary>
    public class ResponseState
    {
        public Errcode Errcode { get; set; }
        public string Errmsg { get; set; }
        public override string ToString()
        {
            return "{\"errcode\":" + (int)this.Errcode + ",\"errmsg\":\"" + this.Errmsg + "\"}";
        }
    }
}
