using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Instruction
{
    /// <summary>
    /// 表示操作指令
    /// </summary>
    public abstract class InstructionBase : IInstructionable
    {

        static InstructionBase()
        {
            Init();
        }

        /// <summary>
        /// 表示当前应用程序所有指令的集合
        /// </summary>
        static ICollection<InstructionBase> _StaticInstructions;

        static object _lockObj = new object();
        /// <summary>
        /// 获取帮助消息
        /// </summary>
        public string HelpMessage { get; protected set; }
        /// <summary>
        /// 检查指令是否与消息相匹配
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract bool IsMatch(RequestMessage message);
        /// <summary>
        /// 分析消息内容并返回响应内容
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract IRespondable GetRespond(RequestMessage message);

        static void Init()
        {
            _StaticInstructions = new List<InstructionBase>();
            //var assemblys = WeiXinTools.GetAssemblys().ToList();
            //foreach (var ass in assemblys)
            //{
            //    foreach (var item in WeiXinTools.GetInstanceFromAssembly<InstructionBase>(ass))
            //    {
            //        if (!_StaticInstructions.Contains(item, new ComparerInstructionBaseByType()))
            //        {
            //            _StaticInstructions.Add(item);
            //        }
            //    }
            //}

            foreach (var ass in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var item in WeiXinTools.GetInstanceFromAssembly<InstructionBase>(ass))
                {
                    //是否需要忽略指令   IgnoreInstructionAttribute
                    if (item.GetType().GetCustomAttributes<IgnoreInstructionAttribute>().Count() > 0)
                    {
                        continue;
                    }
                    if (!_StaticInstructions.Contains(item, new ComparerInstructionBaseByType()))
                    {
                        _StaticInstructions.Add(item);
                    }
                }
            }

            
        }

        /// <summary>
        /// 从当前程序中获取所有派生InstructionBase的对象
        /// </summary>
        /// <returns></returns>
        public static List<InstructionBase> Copy()
        {
            lock (_lockObj)
            {
                return _StaticInstructions.ToList();
            }
        }

    }
}
