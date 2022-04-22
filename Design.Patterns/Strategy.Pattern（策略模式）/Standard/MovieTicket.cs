using System;

namespace Design.Patterns.Strategy.Pattern
{
    /// <summary>
    /// 环境类：电影票MovieTicket
    /// 角色：Context 上下文
    /// </summary>
    public class MovieTicket
    {
        private double _price;
        private IDiscount _discount;

        public double Price
        {
            get
            {
                // 也可以自动触发
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public IDiscount Discount
        {
            set
            {
                _discount = value;
            }
        }
    }

    /// <summary>
    /// 抽象策略类：折扣 Discount
    /// 角色：Stategy
    /// </summary>
    public interface IDiscount { double Calculate(double price); }

    /// <summary>
    /// 具体策略类：学生票折扣 StudentDiscount
    /// 角色：ConcreteStategy
    /// </summary>
    public class StudentDiscount : IDiscount
    {
        public double Calculate(double price)
        {
            Console.WriteLine("学生票：");
            return price * 0.8;
        }
    }

    /// <summary>
    /// 具体策略类：VIP会员票 VIPDiscount
    /// 角色：ConcreteStategy
    /// </summary>
    public class VIPDiscount : IDiscount
    {
        public double Calculate(double price)
        {
            Console.WriteLine("VIP票：");
            Console.WriteLine("增加积分！");
            return price * 0.5;
        }
    }

    /// <summary>
    /// 具体策略类：儿童票折扣 ChildrenDiscount
    /// 角色：ConcreteStategy
    /// </summary>
    public class ChildrenDiscount : IDiscount
    {
        public double Calculate(double price)
        {
            Console.WriteLine("儿童票：");
            return price - 10;
        }
    }
}