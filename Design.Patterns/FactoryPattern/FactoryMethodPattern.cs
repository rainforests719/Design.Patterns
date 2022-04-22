using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Patterns.FactoryMethodPattern
{
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

    /// <summary> 乘法 </summary>
    public class Multiply : IOperation
    {
        public void Operation(int a, int b) => Console.WriteLine($"{a}*{b}={a * b}");
    }

    /// <summary> 工厂接口(抽象工厂)，所有的工厂都继承并且实现该接口 </summary>
    public interface IFactory { IOperation CreateInstance(); }


    /// <summary> 加法工厂 </summary>
    public class AdditionFactory : IFactory { public IOperation CreateInstance() => new Addition(); }

    /// <summary> 减法工厂 </summary>
    public class SubtractionFactory : IFactory { public IOperation CreateInstance() => new Subtraction(); }

    /// <summary> 乘法工厂 </summary>
    public class MultiplyFactory : IFactory { public IOperation CreateInstance() => new Multiply(); }
}
