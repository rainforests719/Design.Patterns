using System;
using System.Collections.Generic;

namespace Design.Patterns.SimpleFactoryPattern
{
    /**
     * 简单工厂：通过定义一个工厂类，由工厂对象决定创建出哪一种产品的实例（用一个单独的类来负责对象的创建）。
     * 简单工厂违背了开闭原则。
     */

    /// <summary> 简单工厂模式 </summary>
    public class OperationFactory
    {
        /// <summary> 创建对象实例 </summary>
        /// <param name="type">type</param>
        /// <returns> IOperation </returns>
        public static IOperation CreateInstance(string type) => type switch
        {
            "+" => new Addition(),
            "-" => new Subtraction(),
            "*" => new Multiply(),
            _ => throw new NotImplementedException("未实现")
        };

        // # 第二种写法——————————————————————————————

        // 缓存对象
        private static Dictionary<string, IOperation> cacherOperations = new Dictionary<string, IOperation>();

        static OperationFactory()
        {
            cacherOperations.Add("+", new Addition());
            cacherOperations.Add("-", new Subtraction());
            cacherOperations.Add("*", new Multiply());
        }

        /// <summary> 创建对象实例 </summary>
        /// <param name="type">type</param>
        /// <returns> IOperation </returns>
        public static IOperation GetInstance(string type) => cacherOperations[type];
    }

    /// <summary>
    /// 运算
    /// </summary>
    public interface IOperation
    {
        void Operation(int a, int b);
    }

    /// <summary> 加法 </summary>
    public class Addition : IOperation
    {
        public void Operation(int a, int b) => Console.WriteLine($"{a}+{b}={a + b}");
    }

    /// <summary> 减法 </summary>
    public class Subtraction : IOperation
    {
        public void Operation(int a, int b) => Console.WriteLine($"{a}-{b}={a - b}");
    }

    /// <summary> 乘 </summary>
    public class Multiply : IOperation
    {
        public void Operation(int a, int b) => Console.WriteLine($"{a}*{b}={a * b}");
    }
}