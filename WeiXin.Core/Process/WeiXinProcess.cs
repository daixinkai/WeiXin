using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiXin.Core.Instruction;

namespace WeiXin.Core
{
    /// <summary>
    /// 表示微信的处理
    /// </summary>
    public abstract class WeiXinProcess
    {

        public WeiXinProcess()
        {
            //this.Instructions = new Collection<IInstructionable>();
            this.Instructions = InstructionBase.Copy();
        }

        /// <summary>
        /// 获取或设置用于处理数据的Stream
        /// </summary>
        public Stream Stream { get; set; }
        /// <summary>
        /// 表示指令处理
        /// </summary>
        public IEnumerable<IInstructionable> Instructions { get; private set; }
        RequestMessage _Message;
        /// <summary>
        /// 获取得到的微信数据
        /// </summary>
        protected RequestMessage Message
        {
            get
            {
                if (this.Stream == null)
                {
                    return null;
                }
                else if (this._Message == null)
                {
                    this._Message = RequestMessage.GetInstance(this.Stream);
                }
                return this._Message;
            }
        }
        /// <summary>
        /// 在派生类中重写时,获取处理的回发消息
        /// </summary>
        /// <returns></returns>
        public abstract IRespondable Process();

    }
}
