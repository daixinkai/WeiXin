using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Models
{
    /// <summary>
    /// 表示微信账号的Access_Token数据
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// Access_Token值
        /// </summary>
        public string Access_Token { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int Expires_In { get; set; }
    }
}
