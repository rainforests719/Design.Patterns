using System;

namespace Design.Patterns.BridgePattern_桥接模式_
{
    /// <summary>
    /// 实现化（Implementor）角色：定义实现化角色的接口，供扩展抽象化角色调用。
    /// </summary>
    public interface Implementor
    {
        public void OperationImpl();
        /// <summary>
        /// 虽然扩展了，但是细节无需扩展照样正常运行。
        /// </summary>
        public void OperationImpl2();
    }

    /// <summary>
    /// 具体实现化（Concrete Implementor）角色：给出实现化角色接口的具体实现。
    /// </summary>
    public class ConcreteImplementorA : Implementor
    {
        public void OperationImpl()
        {
            Console.WriteLine("具体实现化(Concrete Implementor)角色被访问");
        }

        public void OperationImpl2()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 抽象化（Abstraction）角色：定义抽象类，并包含一个对实现化对象的引用。
    /// </summary>
    public abstract class Abstraction
    {
        protected Implementor imple;

        protected Abstraction(Implementor imple)
        {
            this.imple = imple;
        }

        public abstract void Operation();
    }

    /// <summary>
    /// 扩展抽象化（Refined Abstraction）角色：是抽象化角色的子类，实现父类中的业务方法，并通过组合关系调用实现化角色中的业务方法。
    /// </summary>
    public class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor imple) : base(imple)
        {
        }

        public override void Operation()
        {
            Console.WriteLine("扩展抽象化(Refined Abstraction)角色被访问");
            imple.OperationImpl();
        }
    }
}