using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core
{
    public static class WeiXinTools
    {
        /// <summary>
        /// 从指定程序集中获取所有派生类
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetInstanceFromAssembly<T>(Assembly assembly)
        {
            Type t = typeof(T);
            foreach (var type in assembly.GetTypes())
            {
                if ((type.IsSubclassOf(t) || type.Equals(t)) && !type.IsInterface && !type.IsAbstract)
                {
                    // 这个type就是子类了，之后你想实例化还是存到list里面就是你的事了
                    var value = (T)type.GetConstructor(Type.EmptyTypes).Invoke(null);
                    yield return value;

                }
            }

        }

        /// <summary>
        /// 获取与当前程序相关的程序集
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Assembly> GetAssemblys()
        {
            StackTrace st = new StackTrace(1, true);
            StackFrame[] stFrames = st.GetFrames();
            for (int i = 0; i < stFrames.Length; i++)
            {

                Type t = stFrames[i].GetMethod().DeclaringType;

                if (t == null)
                {
                    continue;
                }

                yield return t.Assembly;

            }
        }


        /// <summary>
        /// 得到当前应用程序中所有DLL文件
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Assembly> GetCurrentAssemblys()
        {
            var allFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            foreach (var item in allFiles)
            {
                Assembly assembly = null;
                try
                {
                    assembly = Assembly.LoadFrom(item);
                }
                catch
                {
                    continue;
                }
                yield return assembly;
            }
        }


    }
}
