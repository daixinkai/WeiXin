using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Models
{
    /// <summary>
    /// 表示一个地理位置信息
    /// </summary>
    public class Address
    {
        public string Type { get; set; }
        public string Status { get; set; }

        public string Name { get; set; }
        public string AdmCode { get; set; }
        public string AdmName { get; set; }
        public List<double> NearestPoint { get; set; }
        public double Distance { get; set; }
    }
}
