using System;
using System.Text;

namespace Design.Patterns.PrototypePattern
{
    /// <summary> 原型模式 </summary>
    public class User : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public StringBuilder Address { get; set; }

        // # 浅拷贝——————————————————————————————————————
        /**
         * StringBuilder Address: 浅拷贝复制对象的引用，一旦发生修改将会影响到全部通过浅拷贝得到的对象。
         * string Name 不会受影响，具有不可变性（immutable string）。
         */

        /// <summary>
        /// 浅拷贝
        /// <remarks> Object.MemberwiseClone </remarks>
        /// </summary>
        /// <returns> object </returns>
        public object Clone() => this.MemberwiseClone();

        // # 深拷贝——————————————————————————————————————
        // 1. 二进制序列化
        // 2. Json 序列化
        // 3. 反射
        // 4. 表达式目录树
    }
}