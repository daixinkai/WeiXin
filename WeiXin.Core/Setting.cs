using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using WeiXin.Core.Models;

namespace WeiXin.Core
{
    /// <summary>
    /// 微信配置类
    /// </summary>
    internal static class Setting
    {
        static Setting()
        {
            Initialization();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private static void Initialization()
        {
            Setting.ApiUrl = ConfigurationManager.AppSettings["ApiUrl"] ?? "https://api.weixin.qq.com/";

            Setting.WeiXinServiceNumberMessageDic = new Dictionary<string, string>();
        }
        /// <summary>
        /// 获取微信API URL
        /// </summary>
        public static string ApiUrl { get; private set; }

        /// <summary>
        /// 当前网站的地址 ( http://xxxxxxx[:xx]/)
        /// </summary>
        public static string WebSite
        {
            get
            {
                if (System.Web.HttpContext.Current.Request.Url.Port == 80)
                {
                    return "http://" + System.Web.HttpContext.Current.Request.Url.Host + "/";
                }
                else
                {
                    return "http://" + System.Web.HttpContext.Current.Request.Url.Host + ":" + System.Web.HttpContext.Current.Request.Url.Port + "/";
                }
            }
        }

        public static void Save(string value, string fileName)
        {
            string path = HttpContext.Current.Server.MapPath("~/Log/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (Stream stream = File.Open(path + fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
                {

                    writer.WriteLine(value);
                }
            }
        }

        /// <summary>
        /// 对应的微信号的上一次发送的内容
        /// </summary>
        public static Dictionary<string, string> WeiXinServiceNumberMessageDic { get; private set; }
    }
}
