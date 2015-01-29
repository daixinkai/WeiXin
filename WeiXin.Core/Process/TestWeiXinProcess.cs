using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core
{
    public class TestWeiXinProcess : WeiXinProcess
    {
        /// <summary>
        /// 获取测试的回发数据
        /// </summary>
        /// <returns></returns>
        public override IRespondable Process()
        {


            //if (this.Stream == null || this.Stream.Length == 0)
            //{
            //    throw new WeiXinException("Stream is null");
            //}

            if (this.Message != null)
            {
                foreach (var item in this.Instructions)
                {
                    if (item.IsMatch(this.Message))
                    {
                        return item.GetRespond(this.Message);
                    }
                }
            }


            return new Models.Response.UserList()
            {
                Count = 100,
                Next_OpenID = "asdasdasdasd",
                Total = 100,
                Data = new Models.Response.UserList.User()
                {
                    OpenID = new List<string>()
                    {
                         "11111",
                         "22222",
                         "33333"
                    }
                }
            };

        }
    }
}
