using System.IO;

namespace Design.Patterns.Decorator.Pattern
{
    /// <summary>
    /// 饮料_Abstract Compoent_被装饰类
    /// </summary>
    public abstract class Drink
    {
        /// <summary>
        /// 描述
        /// </summary>
        protected string Description = "Unknow Drink";

        /// <summary>
        /// 返回描述
        /// </summary>
        /// <returns> description </returns>
        public virtual string GetDescription() => Description;

        /// <summary>
        /// 计算价格
        /// </summary>
        /// <returns> float </returns>
        public abstract float cost();
    }

    // # 定义具体类————————————————————————————————————————————————————————————————————————
    /// <summary>
    /// 咖啡 Coffee
    /// </summary>
    public class Coffee : Drink
    {
        public Coffee() { Description = "Coffee"; }

        /// <summary>
        /// 价格
        /// </summary>
        /// <returns> float </returns>
        public override float cost() => 1.5f;
    }

    /// <summary>
    /// 意大利浓咖啡
    /// </summary>
    public class Espresso : Drink
    {
        public Espresso() { Description = "Espresso"; }

        /// <summary>
        /// 价格
        /// </summary>
        /// <returns> float </returns>
        public override float cost() => 10.5f;
    }

    /// <summary>
    /// 美式咖啡
    /// </summary>
    public class LongBlack : Drink
    {
        public LongBlack() { Description = "LongBlack"; }

        /// <summary>
        /// 价格
        /// </summary>
        /// <returns> float </returns>
        public override float cost() => 21.5f;
    }

    /// <summary>
    /// 黑咖啡
    /// </summary>
    public class ShortBlack : Drink
    {
        public ShortBlack() { Description = "ShortBlack"; }

        /// <summary>
        /// 价格
        /// </summary>
        /// <returns> float </returns>
        public override float cost() => 5.5f;
    }

    // # 定义装饰类————————————————————————————————————————————————————————————————————————

    /// <summary>
    /// 配料抽象装饰者
    /// </summary>
    public abstract class CondimentDecorator : Drink
    {
        private Drink _drink;
        public CondimentDecorator(Drink drink)
        {
            this._drink = drink;
        }


        /// <summary>
        /// 配料描述
        /// </summary>
        /// <returns> string </returns>
        public override string GetDescription()
        {
            return _drink.GetDescription();
        }
    }

    /// <summary>
    /// 配料装饰者_Chocolate
    /// </summary>
    public class Chocolate : CondimentDecorator
    {
        private Drink _drink;
        public Chocolate(Drink drink) : base(drink)
        {
            this._drink = drink;
        }

        /// <summary>
        /// 计算价格
        /// </summary>
        /// <returns> float </returns>
        public override float cost()
        {
            return _drink.cost() + 1.5f;
        }

        /// <summary>
        /// 另加配料
        /// </summary>
        /// <returns> string </returns>
        public override string GetDescription()
        {
            var target = base.GetDescription() + " ，Chocolate";
            return target;
        }
    }

    /// <summary>
    /// 配料装饰者_Milk
    /// </summary>
    public class Milk : CondimentDecorator
    {
        private Drink _drink;
        public Milk(Drink drink) : base(drink)
        {
            this._drink = drink;
        }

        /// <summary>
        /// 计算价格
        /// </summary>
        /// <returns> float </returns>
        public override float cost()
        {
            return _drink.cost() + 2.5f;
        }

        /// <summary>
        /// 另加配料
        /// </summary>
        /// <returns> string </returns>
        public override string GetDescription()
        {
            var target = base.GetDescription() + " ，Milk";
            return target;
        }
    }

    /// <summary>
    /// 配料装饰者_Soy 
    /// </summary>
    public class Soy : CondimentDecorator
    {
        private Drink _drink;
        public Soy(Drink drink) : base(drink)
        {
            this._drink = drink;
        }

        /// <summary>
        /// 计算价格
        /// </summary>
        /// <returns> float </returns>
        public override float cost()
        {
            return _drink.cost() + 2.5f;
        }

        /// <summary>
        /// 另加配料
        /// </summary>
        /// <returns> string </returns>
        public override string GetDescription()
        {
            var target = base.GetDescription() + " ，Soy";
            return target;
        }
    }
}