using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Patterns.FactoryPattern
{
    /// <summary> 抽象工厂模式 </summary>
    public class AbstractFactoryPattern
    {
        // 产品抽象定义
        public interface IButton { void Display(); }
        public interface ITextField { void Display(); }
        public interface IComboBox { void Display(); }

        // Spring 产品具体实现
        public class SpringButton : IButton { public void Display() { Console.WriteLine("显示浅绿色按钮..."); } }
        public class SpringTextField : ITextField { public void Display() { Console.WriteLine("显示绿色边框文本框..."); } }
        public class SpringComboBox : IComboBox { public void Display() { Console.WriteLine("显示绿色边框下拉框..."); } }

        // Summer 产品具体实现
        public class SummerButton : IButton { public void Display() { Console.WriteLine("显示浅蓝色按钮..."); } }
        public class SummerTextField : ITextField { public void Display() { Console.WriteLine("显示蓝色边框文本框..."); } }
        public class SummerComboBox : IComboBox { public void Display() { Console.WriteLine("显示蓝色边框下拉框..."); } }


        // 抽奖工厂
        public interface ISkinFactory
        {
            IButton CreateButton();
            ITextField CreateTextField();
            IComboBox CreateComboBox();
        }

        // Spring 皮肤工厂
        public class SpringSkinFactory : ISkinFactory
        {
            public IButton CreateButton() => new SpringButton();
            public IComboBox CreateComboBox() => new SpringComboBox();
            public ITextField CreateTextField() => new SpringTextField();
        }

        // Summer 皮肤工厂
        public class SummerSkinFactory : ISkinFactory
        {
            public IButton CreateButton() => new SpringButton();
            public IComboBox CreateComboBox() => new SpringComboBox();
            public ITextField CreateTextField() => new SpringTextField();
        }
    }
}
