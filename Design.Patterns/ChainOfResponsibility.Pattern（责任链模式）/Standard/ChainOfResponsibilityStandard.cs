using System;

namespace Design.Patterns.ChainOfResponsibility.Pattern.Standard
{
    /**
     * 责任链模式标准写法
     * 角色划分：
     * PurchaseRequest：Context_请求上下文
     * Approver：Handler_抽象处理者
     * Director: ConcreteHandler_具体处理者
     */

    /// <summary>
    /// 采购单
    /// Context_请求上下文
    /// </summary>
    public class PurchaseRequest
    {
        /// <summary>
        /// 采购金额
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// 采购单编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 采购目的
        /// </summary>
        public string Purpose { get; set; }

        public PurchaseRequest(double amount, string number, string purpose)
        {
            Amount = amount;
            Number = number;
            Purpose = purpose;
        }
    }

    #region Handler_抽象处理者（具体处理者基类型）

    /// <summary>
    /// 审批者类：抽象处理者
    /// </summary>
    public abstract class Approver
    {
        /// <summary> 定义后继对象 </summary>
        protected Approver successor;

        /// <summary> 审批者姓名 </summary>
        protected string name;

        /// <summary> 构造函数 </summary>
        /// <param name="name"></param>
        public Approver(string name) => this.name = name;

        /// <summary>
        /// 设置后继者
        /// </summary>
        /// <param name="successor"> 后继者 </param>
        public void SetSuccessor(Approver successor) => this.successor = successor;

        // 抽象请求处理方法
        public abstract void ProcessRequest(PurchaseRequest request);

        /// <summary> 执行后继者 </summary>
        /// <param name="request"> 上下文 </param>
        protected void ProcessRequestNext(PurchaseRequest request)
        {
            if (this.successor != null)
                this.successor.ProcessRequest(request);
        }
    }

    #endregion

    #region ConcreteHandler_具体处理者

    /// <summary>
    /// 经理：具体处理类
    /// </summary>
    public class Manager : Approver
    {
        public Manager(string name) : base(name) { }

        // 具体请求处理方法
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 50000)
                // 处理请求
                Console.WriteLine("经理 {0} 审批采购单：{1}，金额：{2} 元，采购目的：{3}。", this.name, request.Number, request.Amount, request.Purpose);
            else
                base.ProcessRequestNext(request);
        }
    }

    /// <summary>
    /// 总监：具体处理类
    /// </summary>
    public class Director : Approver
    {
        public Director(string name) : base(name) { }

        // 具体请求处理方法
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 50000)
                // 处理请求
                Console.WriteLine("总监 {0} 审批采购单：{1}，金额：{2} 元，采购目的：{3}。", this.name, request.Number, request.Amount, request.Purpose);
            else
                base.ProcessRequestNext(request);
        }
    }

    /// <summary>
    /// 副总裁：具体处理类
    /// </summary>
    public class VicePresident : Approver
    {
        public VicePresident(string name) : base(name) { }

        // 具体请求处理方法
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 100000)
                // 处理请求
                Console.WriteLine("副总裁 {0} 审批采购单：{1}，金额：{2} 元，采购目的：{3}。", this.name, request.Number, request.Amount, request.Purpose);
            else
                base.ProcessRequestNext(request);
        }
    }

    /// <summary>
    /// 总裁：具体处理者
    /// </summary>
    public class President : Approver
    {
        public President(string name) : base(name) { }

        // 具体请求处理方法
        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount < 500000)
                Console.WriteLine("总裁 {0} 审批采购单：{1}，金额：{2} 元，采购目的：{3}。", this.name, request.Number, request.Amount, request.Purpose);
            else
                base.ProcessRequestNext(request);
        }
    }

    /// <summary>
    /// 董事会：具体处理者
    /// </summary>
    public class Congress : Approver
    {
        public Congress(string name) : base(name) { }

        // 具体请求处理方法
        public override void ProcessRequest(PurchaseRequest request)
        {
            // 处理请求
            Console.WriteLine("董事会 {0} 审批采购单：{1}，金额：{2} 元，采购目的：{3}。", this.name, request.Number, request.Amount, request.Purpose);
        }
    }

    #endregion
}