using System;
using System.Collections.Generic;

namespace Design.Patterns.Observer.Pattern_观察者模式_
{
    /// <summary>
    /// Subject_抽象的被观察者_抽象主题
    /// 钓鱼工具抽象类（用来维护订阅者列表，并通知订阅者）
    /// </summary>
    //public abstract class FishingTool
    //{
    //    private readonly List<ISubscriber> _subscribers;

    //    protected FishingTool()
    //    {
    //        _subscribers = new List<ISubscriber>();
    //    }

    //    /// <summary>
    //    /// 添加订阅者
    //    /// </summary>
    //    /// <param name="subscriber"> 订阅者 </param>
    //    public void AddSubscriber(ISubscriber subscriber)
    //    {
    //        if (!_subscribers.Contains(subscriber))
    //            _subscribers.Add(subscriber);
    //    }

    //    /// <summary>
    //    /// 删除订阅者
    //    /// </summary>
    //    /// <param name="subscriber"> 订阅者 </param>
    //    public void RemoveSubscriber(ISubscriber subscriber)
    //    {
    //        if (_subscribers.Contains(subscriber))
    //            _subscribers.Remove(subscriber);
    //    }

    //    /// <summary>
    //    /// 通知
    //    /// </summary>
    //    /// <param name="type"> 鱼种类 </param>
    //    public void Notify(string type)
    //    {
    //        foreach (var subscriber in _subscribers)
    //            subscriber.Update(type);
    //    }
    //}

    ///// <summary>
    ///// 鱼竿_具体被观察者_具体抽象主题
    ///// </summary>
    //public class FishingRod : FishingTool
    //{
    //    private List<string> fishLists = new List<string>()
    //{
    //    "鲫鱼",
    //    "鲤鱼",
    //    "黑鱼",
    //    "青鱼",
    //    "草鱼",
    //    "鲈鱼"
    //};

    //    /// <summary>
    //    /// 行为
    //    /// </summary>
    //    public void Fishing()
    //    {
    //        Console.WriteLine("开始下钩！");
    //        if (new Random().Next() % 2 == 0)
    //        {
    //            var type = fishLists[new Random().Next(0, 5)];
    //            Console.WriteLine("铃铛：叮叮叮，鱼儿咬钩了");
    //            Notify(type);
    //        }
    //    }
    //}

    /// <summary>
    /// 鱼竿_具体被观察者_具体抽象主题
    /// </summary>
    public class FishingRod
    {
        public delegate void FishingHandler(string type);
        public event FishingHandler FishingEvent;
        private List<string> fishLists = new List<string>() { "鲫鱼", "鲤鱼", "黑鱼", "青鱼", "草鱼", "鲈鱼" };

        /// <summary>
        /// 行为
        /// </summary>
        public void Fishing()
        {
            Console.WriteLine("开始下钩！");
            if (new Random().Next() % 2 == 0)
            {
                var type = fishLists[new Random().Next(0, 5)];
                Console.WriteLine("铃铛：叮叮叮，鱼儿咬钩了");
                if (FishingEvent != null)
                    FishingEvent(type);
            }
        }
    }

    /// <summary>
    /// Observer_抽象观察者
    /// 订阅者（观察者）接口（由具体的订阅者实现Update()方法）
    /// </summary>
    public interface ISubscriber
    {
        void Update(string type);
    }

    /// <summary>
    /// ConcreteObserver_具体观察者
    /// 垂钓者实现观察者接口
    /// </summary>
    public class FishingMan : ISubscriber
    {
        public FishingMan(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int FishCount { get; set; }

        public void Update(string type)
        {
            FishCount++;
            Console.WriteLine("{0}：钓到一条[{2}]，已经钓到{1}条鱼了！", Name, FishCount, type);
        }
    }

    /// <summary>
    /// ConcreteObserver_具体观察者
    /// 小孩
    /// </summary>
    public class Child : ISubscriber
    {
        public Child(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int FishCount { get; set; }

        public void Update(string type)
        {
            FishCount++;
            Console.WriteLine("你看他钓到一条[{2}]，这已经是钓到第{1}条鱼了！", Name, FishCount, type);
        }
    }
}
