using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Models
{
    /// <summary>
    /// 表示从微信接口返回的位置信息
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { get; set; }

        public List<double> QueryLocation { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string Province
        {
            get
            {
                if (this.AddrList == null || this.AddrList.Count == 0)
                {
                    return string.Empty;
                }
                return this.AddrList.FirstOrDefault().AdmName.Split(',')[0];
            }
        }
        /// <summary>
        /// 市
        /// </summary>
        public string City
        {
            get
            {
                if (this.AddrList == null)
                {
                    return string.Empty;
                }
                return this.AddrList.FirstOrDefault().AdmName.Split(',')[1];
            }
        }
        /// <summary>
        /// 区
        /// </summary>
        public string Area
        {
            get
            {
                if (this.AddrList == null)
                {
                    return string.Empty;
                }
                var temp = this.AddrList.Where(o => o.Type.ToLower() == "doorplate").FirstOrDefault();
                if (temp == null)
                {
                    return string.Empty;
                }
                return temp.AdmName.Split(',')[2];
            }
        }

        public List<Address> AddrList { get; set; }
    }
}
