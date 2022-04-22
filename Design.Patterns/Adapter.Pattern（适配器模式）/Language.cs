using System;

namespace Design.Patterns.Adapter.Pattern_适配器模式_
{
    /**
        * 类适配器：
        * 客户想要把一个两孔的插头转换成三孔插头，这个转换就交给了 “适配器”，
        * 所以这个适配器需要同时具备：两孔和三孔插头的特征。
        */

    /// <summary>
    /// 三个孔的插头
    ///（Target）适配器模式中的目标角色
    /// </summary>
    public interface IThreeHole
    {
        void Request();
    }

    /// <summary>
    /// 两个孔的插头
    ///（Adaptee）源角色——需要适配的类
    /// </summary>
    public class TwoHole
    {
        public void SpecificRequest()
        {
            Console.WriteLine("两个孔的插头");
        }
    }

    // # 类适配器————————————————————————————————————————————————————————————————————————————————
    ///// <summary>
    /////（Adapter）适配器类
    ///// 适配器类提供了三个孔插头的行为，但其本质是调用两个孔插头的方法
    ///// </summary>
    //public class PowerAdapter : TwoHole, IThreeHole
    //{
    //    /// <summary>
    //    /// 实现三个孔插头接口方法
    //    /// </summary>
    //    public void Request()
    //    {
    //        // 调用两个孔插头方法
    //        this.SpecificRequest();
    //    }
    //}

    // # 对象适配器————————————————————————————————————————————————————————————————————————————————
    public class PowerAdapter : IThreeHole
    {
        // 对象适配器使用组合的方式
        private TwoHole _twoHole;
        public PowerAdapter(TwoHole twoHole)
        {
            _twoHole = twoHole;
        }

        /// <summary>
        /// 实现三个孔插头接口方法
        /// </summary>
        public void Request()
        {
            // 调用两个孔插头方法
            this._twoHole.SpecificRequest();
        }
    }
}