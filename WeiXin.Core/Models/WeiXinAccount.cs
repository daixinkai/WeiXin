using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Models
{
    /// <summary>
    /// 表示微信公众账号
    /// </summary>
    public class WeiXinAccount
    {
        public string AppID { get; set; }
        public string AppSecret { get; set; }
        public string Token { get; set; }

        public string ServiceNumber { get; set; }
    }
}
