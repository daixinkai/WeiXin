using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WeiXin.Core
{
    /// <summary>
    /// 上传文件到微信服务器
    /// </summary>
    public abstract class Upload
    {
        /// <summary>
        /// 调用接口凭证
        /// </summary>
        public string Access_Token { get; set; }
        /// <summary>
        /// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb）
        /// </summary>
        public abstract string Type { get; }
        /// <summary>
        /// form-data中媒体文件标识，有filename、filelength、content-type等信息
        /// </summary>
        public string Media { get; set; }

        /// <summary>
        /// 获取文件上传结果
        /// </summary>
        public UploadResult Result { get; private set; }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="ACCESS_TOKEN"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool UploadMedia(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new Exception("file is not exist");
            }
            string wxurl = "http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token=" + this.Access_Token + "&type=" + this.Type;
            WebClient myWebClient = new WebClient();
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                byte[] responseArray = myWebClient.UploadFile(wxurl, "POST", fileName);
                var value = System.Text.Encoding.Default.GetString(responseArray, 0, responseArray.Length);

                //Web.Common.LogHelper.SetException(new Exception("接受上传数据\r\n"+value));

                this.Result = WeiXinCommon.DeSerialize<UploadResult>(value);

                if (this.Result == null)
                {
                    throw new WeiXinException("Result is null");
                    return false;
                }
            }
            catch (Exception ex)
            {
                //Web.Common.LogHelper.SetException(ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="ACCESS_TOKEN"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool UploadMedia(Stream stream)
        {

            if (stream == null || stream.Length == 0)
            {
                throw new Exception("stream has not data");
            }
            string wxurl = "http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token=" + this.Access_Token + "&type=" + this.Type;
            WebClient myWebClient = new WebClient();
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                byte[] buffer = new byte[stream.Length];
                stream.Write(buffer, 0, buffer.Length);
                byte[] responseArray = myWebClient.UploadData(wxurl, "POST", buffer);
                var value = System.Text.Encoding.Default.GetString(responseArray, 0, responseArray.Length);
                this.Result = WeiXinCommon.DeSerialize<UploadResult>(value);

                if (this.Result == null)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

    }

    public class UploadResult
    {
        public string Type { get; set; }
        public string Media_ID { get; set; }
        public string Created_At { get; set; }
    }
}
