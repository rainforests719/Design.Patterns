using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Patterns.Singleton.Pattern_单例模式_.Standard
{
    public class MemoryCache
    {
        private int i = 0;
        private static MemoryCache _memoryCacheInstance;
        private static object _cachLock = new object();

        private MemoryCache()
        {
            $"Created {i++}".WriteLine();
        }

        public static MemoryCache CreateInstance()
        {
            if (_memoryCacheInstance == null)
            {
                lock (_cachLock)
                {
                    if (_memoryCacheInstance == null)
                    {
                        return _memoryCacheInstance = new MemoryCache();
                    }
                }
            }
            return _memoryCacheInstance;
        }

    }
}