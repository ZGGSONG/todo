using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.Helper
{
    /// <summary>
    /// 单例辅助类
    /// </summary>
    public class SingletonMode<T> where T : class
    {
        public static T _Instance;
        public static T Instance()
        {
            Type type = typeof(T);
            lock (type)
            {
                if (SingletonMode<T>._Instance == null)
                {
                    SingletonMode<T>._Instance = (Activator.CreateInstance(typeof(T), true) as T);
                }
                return SingletonMode<T>._Instance;
            }
        }

    }
}
