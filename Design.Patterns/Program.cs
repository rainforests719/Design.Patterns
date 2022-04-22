using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Design.Patterns.Adapter.Pattern_适配器模式_;
using Design.Patterns.BridgePattern_桥接模式_;
using Design.Patterns.BuilderPattern;
using Design.Patterns.Decorator.Pattern;
using Design.Patterns.Decorator_装饰器模式_;
using Design.Patterns.Mediator.Pattern.Standard;
using Design.Patterns.Observer.Pattern_观察者模式_;
using Design.Patterns.PrototypePattern;
using Design.Patterns.ProxyPattern;
using Design.Patterns.Strategy.Pattern;

namespace Design.Patterns
{
    class Program
    {
        //private static void Main(string[] args)
        //{
        //    //Person person = new Person("senlin.huang");
        //    //TShirts thsShirts = new TShirts();
        //    //BigTrouser bigTrouser = new BigTrouser();

        //    //bigTrouser.Decorate(person);
        //    //thsShirts.Decorate(bigTrouser);
        //    //thsShirts.Show();
        //    //Drink drink = new Espresso();
        //    //Console.WriteLine($"{drink.GetDescription()}，{drink.cost()}");
        //    //drink = new Chocolate(drink);
        //    //drink = new Milk(drink);
        //    //drink = new Soy(drink);
        //    //Console.WriteLine($"{drink.GetDescription()}，{drink.cost()}");

        //    ////Design.Patterns.ProxyPattern.IMath math = new Design.Patterns.ProxyPattern.Math();
        //    ////MathProxy mathProxy = new MathProxy(math);
        //    ////mathProxy.Add(10, 50);


        //    //Project webProject = new WebProject("Web项目");
        //    //Manager projectManager = new ProjectManager(webProject);
        //    //Manager productManager = new ProductManger(webProject);

        //    //projectManager.ManageProject();
        //    //productManager.ManageProject();

        //    ////Type type = ProxyBuilder<Interceptor>.BuildProxy(typeof(Design.Patterns.ProxyPattern.Math));
        //    ////IMath math = (Design.Patterns.ProxyPattern.Math)Activator.CreateInstance(type);
        //    ////math.Add(10, 20);

        //    //TwoHole twoHole = new TwoHole();
        //    //IThreeHole threehole = new PowerAdapter(twoHole);
        //    //threehole.Request();

        //    //var fishingRod = new FishingRod();

        //    ////2、声明垂钓者
        //    //var jeff = new FishingMan("圣杰");
        //    //var child = new Child("child");

        //    ////3、将垂钓者观察鱼竿
        //    //fishingRod.FishingEvent += jeff.Update;
        //    //fishingRod.FishingEvent += child.Update;

        //    ////4、循环钓鱼
        //    //while (jeff.FishCount < 5)
        //    //{
        //    //    fishingRod.Fishing();
        //    //    Console.WriteLine("-------------------");
        //    //    //睡眠5s
        //    //    Thread.Sleep(5000);
        //    //}

        //    MovieTicket mt = new MovieTicket();
        //    double originalPrice = 60.0;
        //    double currentPrice = originalPrice;

        //    mt.Price = originalPrice;
        //    Console.WriteLine("原始票价：{0}", originalPrice);
        //    Console.WriteLine("----------------------------------------");

        //    IDiscount discount = new ChildrenDiscount();
        //    if (discount != null)
        //    {
        //        mt.Discount = discount;
        //        currentPrice = discount.Calculate(mt.Price);
        //    }
        //    Console.WriteLine("折后票价：{0}", currentPrice);

        //    Console.ReadKey();

        //    Console.ReadLine();
        //}

        static void Main(string[] args)
        {
            var mediator = new ConcreteMediator();
            var thing = new Thing();
            var part = new Part();
            var piece = new Piece();
            mediator.SetPart(part);
            mediator.SetPiece(piece);
            mediator.SetThing(thing);
            piece.SetMediator(mediator);
            piece.Invoke();
        }
    }
}