using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using WeiXin.Core.Models;
using WeiXin.Core.Models.Request;
using WeiXin.Core.Models.Response;

namespace WeiXin.Core
{
    public static class WeiXinCommon
    {
        /// <summary>
        /// 告知微信服务器，已通过验证
        /// </summary>
        public static void EchoPass()
        {
            //响应微信验证
            HttpContext.Current.Response.Write(HttpContext.Current.Request["echostr"]);
            HttpContext.Current.Response.Flush();
        }

        /// <summary>
        /// 发送微信返回消息
        /// </summary>
        /// <param name="message"></param>
        public static void RespondMessage(IRespondable respond)
        {
            HttpContext.Current.Response.Write(respond.GetRespond());
        }

        /// <summary>
        /// 将字符串转换为指定枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strValue"></param>
        /// <returns></returns>

        public static T ToEnum<T>(string strValue) where T : struct
        {
            T t = default(T);
            return Enum.TryParse<T>(strValue, false, out t) ? t : default(T);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T DeSerialize<T>(string value)
        {
            return (new JavaScriptSerializer()).Deserialize<T>(value);
        }

        /// <summary>
        /// 转为JSON
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        /// <summary>
        /// 下载Json资源
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DownJsonData(string url, string data = null)
        {
            WebClient client = new WebClient();
            client.Headers["Content-Type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            if (string.IsNullOrEmpty(data))
            {
                return client.DownloadString(url);
            }
            else
            {
                return client.UploadString(url, data);
            }
        }


        ///// <summary>
        ///// 获取AccessToken对象
        ///// </summary>
        ///// <returns></returns>
        //public static AccessToken GetAccessToken()
        //{
        //    //获取access_token
        //    string url = string.Format("{0}token?grant_type=client_credential&appid={1}&secret={2}", Setting.ApiUrl, Setting.AppID, Setting.AppSecret);

        //    WebClient webclient = new WebClient();
        //    try
        //    {
        //        //byte[] bytes = webclient.DownloadData(url);
        //        //return DeSerialize<AccessToken>(Encoding.GetEncoding("utf-8").GetString(bytes));

        //        return DeSerialize<AccessToken>(DownJsonData(url));
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// 获取微信账号的Access_Token数据
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static AccessToken GetAccessToken(WeiXinAccount account)
        {
            if (account == null)
            {
                return null;
            }

            //获取access_token
            string url = string.Format("{0}cgi-bin/token?grant_type=client_credential&appid={1}&secret={2}", Setting.ApiUrl, account.AppID, account.AppSecret);

            WebClient webclient = new WebClient();
            try
            {

                return DeSerialize<AccessToken>(DownJsonData(url));
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 返回当前公众号的用户列表
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="next_OpenID">第一个拉取的OPENID，不填默认从头开始拉取</param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static UserList GetUserList(string access_Token, string next_OpenID, out ResponseState state)
        {
            state = null;
            string url = Setting.ApiUrl + "cgi-bin/user/get?access_token=" + access_Token + "&next_openid=" + next_OpenID;
            string response = DownJsonData(url);
            try
            {
                return DeSerialize<UserList>(response);
            }
            catch (Exception ex)
            {
                state = DeSerialize<ResponseState>(response);
                return null;
            }
        }

        /// <summary>
        /// 返回当前公众号的用户列表从头开始拉取
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static UserList GetUserList(string access_Token, out ResponseState state)
        {
            state = null;
            string url = Setting.ApiUrl + "cgi-bin/user/get?access_token=" + access_Token;
            string response = DownJsonData(url);
            try
            {
                return DeSerialize<UserList>(response);
            }
            catch (Exception ex)
            {
                state = DeSerialize<ResponseState>(response);
                return null;
            }
        }

        /// <summary>
        /// 获取用户基本信息（包括UnionID机制）
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="openID">用户openID</param>
        /// <param name="lang">语言</param>
        /// <param name="state">返回状态</param>
        /// <returns></returns>
        public static UserDetail GetUserDetail(string access_Token, string openID, Lang lang, out ResponseState state)
        {
            state = null;
            string url = Setting.ApiUrl + "cgi-bin/user/info?access_token=" + access_Token + "openid=" + openID + "&lang=" + lang.ToString();
            string response = DownJsonData(url);
            try
            {
                return DeSerialize<UserDetail>(response);
            }
            catch (Exception ex)
            {
                state = DeSerialize<ResponseState>(response);
                return null;
            }
        }

        /// <summary>
        /// 获取用户基本信息（包括UnionID机制）
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="openID">用户openID</param>
        /// <param name="lang">语言</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public static UserDetail GetUserDetail(string access_Token, string openID, out ResponseState state)
        {
            return GetUserDetail(access_Token, openID, Lang.Zh_CN, out state);
        }

        /// <summary>
        /// 创建客服
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="account"></param>
        /// <returns></returns>
        public static ResponseState CreateKFAccount(string access_Token, KFAccount account)
        {
            string post = account.ToString();

            string url = Setting.ApiUrl + "customservice/kfaccount/add?access_token=" + access_Token;

            string response = DownJsonData(url, post);

            return DeSerialize<ResponseState>(response);
        }

        /// <summary>
        /// 更新客服
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="account"></param>
        /// <returns></returns>
        public static ResponseState UpdateKFAccount(string access_Token, KFAccount account)
        {
            string post = account.ToString();

            string url = Setting.ApiUrl + "customservice/kfaccount/update?access_token=" + access_Token;

            string response = DownJsonData(url, post);

            return DeSerialize<ResponseState>(response);
        }

        /// <summary>
        /// 删除客服
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="account"></param>
        /// <returns></returns>
        public static ResponseState DeleteKFAccount(string access_Token, KFAccount account)
        {
            string post = account.ToString();

            string url = Setting.ApiUrl + "customservice/kfaccount/del?access_token=" + access_Token;

            string response = DownJsonData(url, post);

            return DeSerialize<ResponseState>(response);
        }

        /// <summary>
        /// 发送客服消息
        /// </summary>
        /// <param name="access_Token">微信号access_Token</param>
        /// <param name="account"></param>
        /// <returns></returns>
        public static ResponseState SendMessage(string access_Token, string openID, CustomMessage message)
        {
            string post = message.ToString();

            string url = Setting.ApiUrl + "customservice/kfaccount/del?access_token=" + access_Token;

            string response = DownJsonData(url, post);

            return DeSerialize<ResponseState>(response);
        }

        /// <summary>
        /// 发送客服消息
        /// </summary>
        /// <param name="account">微信帐号</param>
        /// <param name="account"></param>
        /// <returns></returns>
        public static ResponseState SendMessage(WeiXinAccount account, string openID, CustomMessage message)
        {
            return SendMessage(GetAccessToken(account).Access_Token, openID, message);
        }


    }
}
