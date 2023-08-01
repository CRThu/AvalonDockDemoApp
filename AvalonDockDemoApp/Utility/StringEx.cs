using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.Utility
{
    public static class StringEx
    {
        /// <summary>
        /// String转Enum类型
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="str">字符串</param>
        /// <returns>字符串转换枚举</returns>
        public static T ToEnum<T>(this string str)
        {
            return (T)Enum.Parse(typeof(T), str, true);
        }
    }
}
