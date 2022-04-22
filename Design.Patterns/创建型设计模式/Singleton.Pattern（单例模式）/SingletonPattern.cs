namespace Design.Patterns.SingletonPattern
{
    /**
     * 单例模式：保证整个进程中只有一个对象实例 。
     */

    /// <summary> 单例模式(防止派生类继承创建实例) </summary>
    public sealed class SingletonPattern
    {
        /// <summary> 构造的实例 </summary>
        private static volatile SingletonPattern singletonPattern = null;

        /// <summary> lock 锁 </summary>
        private static readonly object singletonPatternLock = new object();

        /// <summary> 构造函数私有化 </summary>
        private SingletonPattern() { }

        /**
         * 标准经典写法（双重校验加锁，线程安全） ———————————————————————————————————————————————————————————
         *
         */
        /// <summary> 标准写法（双重校验加锁） </summary>
        /// <returns>SingletonPattern</returns>
        public static SingletonPattern CreateInstance()
        {
            if (singletonPattern == null)
            {
                lock (singletonPatternLock)
                    if (singletonPattern == null)
                        singletonPattern = new SingletonPattern();
            }
            return singletonPattern;
        }

        // # 饿汉式写法———————————————————————————————————————————————————————————
        // # 饿汉式_静态构造函数
        /// <summary> 静态构造函数(只会执行一次) </summary>
        static SingletonPattern() { singletonPattern = new SingletonPattern(); }

        // # 饿汉式_静态字段写法
        /// <summary> 静态字段（整个进程唯一） </summary>
        public static readonly SingletonPattern HCreateInstance = new SingletonPattern();

        /// <summary> 返回实例 </summary>
        /// <returns> SingletonPattern </returns>
        public static SingletonPattern CreateSingletonPatternInstance() => HCreateInstance;

        // # 懒汉式写法（非线程安全）———————————————————————————————————————————————————————————
        public static SingletonPattern GetSingletonPattern()
        {
            lock (singletonPatternLock)
            {
                if (singletonPattern == null)
                    singletonPattern = new SingletonPattern();
                return singletonPattern;
            }
        }

    }
}