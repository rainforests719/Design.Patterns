using System;
using System.Collections.Generic;

namespace Design.Patterns.BuilderPattern.Build
{
    /// <summary>
    /// 产品类_产品角色
    /// </summary>
    public class Computer
    {
        /// <summary>
        /// 品牌
        /// </summary>
        public string Band { get; set; }

        /// <summary>
        /// 电脑组件列表
        /// </summary>
        private IList<string> assemblyParts = new List<string>();

        /// <summary>
        /// 组装部件
        /// </summary>
        /// <param name="partName"> 部件名称 </param>
        public void AssemblePart(string partName) => this.assemblyParts.Add(partName);

        public void ShowSteps()
        {
            Console.WriteLine("开始组装『{0}』电脑:", Band);
            foreach (var part in assemblyParts) Console.WriteLine(string.Format("组装『{0}』;", part));
            Console.WriteLine("组装『{0}』电脑完毕！", Band);
        }
    }

    /// <summary>
    /// 抽象建造者，也可通过接口实现
    /// Director 不关心具体组装的细节，所以将具体的组装细节方法标记为: protected
    /// </summary>
    public abstract class Builder
    {
        /// <summary>
        /// 具体产品
        /// </summary>
        protected Computer computer { set; get; } = new Computer();

        /// <summary> 组装主机 </summary>
        public abstract Builder BuildMainFramePart();

        /// <summary> 组装显示器 </summary>
        public abstract Builder BuildScreenPart();

        /// <summary> 组装输入设备（键鼠）</summary>
        public abstract Builder BuildInputPart();

        /// <summary>
        /// 获取具体的产品
        /// </summary>
        /// <returns> Computer </returns>
        public abstract Computer Build();
    }

    /// <summary>
    /// 具体建造者_惠普电脑组装商
    /// </summary>
    public class HpBulider : Builder
    {
        public HpBulider()
        {
            computer.Band = "惠普";
        }

        public override Builder BuildMainFramePart()
        {
            computer.AssemblePart("主机");
            return this;
        }

        public override Builder BuildScreenPart()
        {
            computer.AssemblePart("显示器");
            return this;
        }

        public override Builder BuildInputPart()
        {
            computer.AssemblePart("键鼠");
            return this;
        }

        /// <summary>
        /// 获取具体的产品
        /// </summary>
        /// <returns> Computer </returns>
        public override Computer Build() => computer;
    }

    /// <summary>
    /// 具体建造者_惠普电脑组装商
    /// </summary>
    public class DellBulider : Builder
    {
        public DellBulider()
        {
            computer.Band = "Dell";
        }

        public override Builder BuildMainFramePart()
        {
            computer.AssemblePart("主机");
            return this;
        }

        public override Builder BuildScreenPart()
        {
            computer.AssemblePart("显示器");
            return this;
        }

        public override Builder BuildInputPart()
        {
            computer.AssemblePart("键鼠");
            return this;
        }

        /// <summary>
        /// 获取具体的产品
        /// </summary>
        /// <returns> Computer </returns>
        public override Computer Build() => computer;
    }

    /// <summary>
    /// 指挥者（采购经理）
    /// </summary>
    public class Director
    {
        /**
         * 如何组装电脑交给指挥者
         */

        public Computer Construct(Builder builder)
        {
            return builder.BuildInputPart()
                .BuildMainFramePart()
                .BuildScreenPart()
                .Build();
        }
    }
}


namespace Design.Patterns.BuilderPattern
{/// <summary>
 /// 产品类_产品角色
 /// </summary>
    public class Computer
    {
        /// <summary>
        /// 品牌
        /// </summary>
        public string Band { get; set; }

        /// <summary>
        /// 电脑组件列表
        /// </summary>
        private IList<string> assemblyParts = new List<string>();

        /// <summary>
        /// 组装部件
        /// </summary>
        /// <param name="partName"> 部件名称 </param>
        public void AssemblePart(string partName) => this.assemblyParts.Add(partName);

        public void ShowSteps()
        {
            Console.WriteLine("开始组装『{0}』电脑:", Band);
            foreach (var part in assemblyParts) Console.WriteLine(string.Format("组装『{0}』;", part));
            Console.WriteLine("组装『{0}』电脑完毕！", Band);
        }
    }

    /// <summary>
    /// 抽象建造者，也可通过接口实现
    /// Director 不关心具体组装的细节，所以将具体的组装细节方法标记为: protected
    /// </summary>
    public abstract class Builder
    {
        /// <summary>
        /// 具体产品
        /// </summary>
        protected Computer computer { set; get; } = new Computer();

        /// <summary> 组装主机 </summary>
        public abstract void BuildMainFramePart();

        /// <summary> 组装显示器 </summary>
        public abstract void BuildScreenPart();

        /// <summary> 组装输入设备（键鼠）</summary>
        public abstract void BuildInputPart();

        /// <summary> 获取组装电脑 </summary>
        /// <returns> Computer </returns>
        public abstract Computer BuildComputer();
    }

    /// <summary>
    /// 具体建造者_惠普电脑组装商
    /// </summary>
    public class HpBulider : Builder
    {
        public HpBulider()
        {
            computer.Band = "惠普";
        }

        public override void BuildMainFramePart() => computer.AssemblePart("主机");

        public override void BuildScreenPart() => computer.AssemblePart("显示器");

        public override void BuildInputPart() => computer.AssemblePart("键鼠");

        /// <summary> 建造 </summary>
        /// <returns> Computer </returns>
        public override Computer BuildComputer()
        {
            BuildMainFramePart();
            BuildScreenPart();
            BuildInputPart();
            return computer;
        }
    }

    /// <summary>
    /// 具体建造者_惠普电脑组装商
    /// </summary>
    public class DellBulider : Builder
    {
        public DellBulider()
        {
            computer.Band = "Dell";
        }

        public override void BuildMainFramePart() => computer.AssemblePart("主机");

        public override void BuildScreenPart() => computer.AssemblePart("显示器");

        public override void BuildInputPart() => computer.AssemblePart("键鼠");

        /// <summary> 建造 </summary>
        /// <returns> Computer </returns>
        public override Computer BuildComputer()
        {
            BuildMainFramePart();
            BuildScreenPart();
            BuildInputPart();
            return computer;
        }
    }

    /// <summary>
    /// 指挥者（采购经理）
    /// </summary>
    public class Director
    {
        /**
         * 如何组装电脑交给指挥者
         */

        public Computer Construct(Builder builder) => builder.BuildComputer();
    }

}