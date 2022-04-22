using System;

namespace Design.Patterns.Template.Pattern
{
    /**
     * 抽象类定义了一个模板方法，其中包含一些算法。
     * 角色：抽象类
     */

    internal abstract class AbstractClass
    {
        // 定义算法的骨架
        public void TemplateMethod()
        {
            this.BaseOperation();
            this.RequiredOperations();
            this.Hook();
        }

        protected void BaseOperation() => Console.WriteLine("AbstractClass says: BaseOperation");

        protected abstract void RequiredOperations();

        // 虚方法可重写也可不重写
        protected virtual void Hook()
        {
        }
    }

    /**
     * 子类必须重写抽象方法
     * 角色：具体子类型
     */
    internal class ConcreteClass : AbstractClass
    {
        protected override void RequiredOperations() => Console.WriteLine("ConcreteClass RequiredOperations");

        protected override void Hook() => Console.WriteLine("ConcreteClass Hook");
    }
}