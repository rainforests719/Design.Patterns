using System;

namespace Design.Patterns.BridgePattern_桥接模式_
{
    /// <summary>
    /// 项目_抽象化角色：定义抽象类，并包含一个对实现化对象的引用。
    /// </summary>
    public abstract class Project
    {
        public string ProjectName { get; set; }

        protected Project(string projectName) { ProjectName = projectName; }

        /// <summary>
        /// 需求分析
        /// </summary>
        public abstract void AnalyzeRequirement();

        /// <summary>
        /// 产品设计
        /// </summary>
        public abstract void DesignProduct();

        /// <summary>
        /// 制定计划
        /// </summary>
        public abstract void MakePlan();

        /// <summary>
        /// 任务分解
        /// </summary>
        public abstract void ScheduleTask();

        /// <summary>
        /// 进度把控
        /// </summary>
        public abstract void ControlProcess();

        /// <summary>
        /// 产品发布
        /// </summary>
        public abstract void ReleaseProduct();

        /// <summary>
        /// 后期运维
        /// </summary>
        public abstract void MaintainProduct();

        /// <summary>
        /// 后期运维 1 (额外扩展)
        /// </summary>
        public abstract void Maintain();
    }

    /// <summary>
    /// Web 项目_扩展抽象化角色：是抽象化角色的子类，实现父类中的业务方法，并通过组合关系调用实现化角色中的业务方法。
    /// </summary>
    public class WebProject : Project
    {
        public WebProject(string projectName) : base(projectName)
        {
        }

        public override void AnalyzeRequirement()
        {
            Console.WriteLine($"[{base.ProjectName}]：进行需求分析");
        }

        public override void DesignProduct()
        {
            Console.WriteLine($"[{base.ProjectName}]：进行产品设计");
        }

        public override void MakePlan()
        {
            Console.WriteLine($"[{base.ProjectName}]：制定项目计划");
        }

        public override void ScheduleTask()
        {
            Console.WriteLine($"[{base.ProjectName}]：制作任务清单");
        }

        public override void ControlProcess()
        {
            Console.WriteLine($"[{base.ProjectName}]：把控项目进度");
        }

        public override void ReleaseProduct()
        {
            Console.WriteLine($"[{base.ProjectName}]：产品发布");
        }

        public override void MaintainProduct()
        {
            Console.WriteLine($"[{base.ProjectName}]：后期运维");
        }

        public override void Maintain()
        {
        }
    }

    /// <summary>
    /// 经理_实现化角色：是抽象化角色的子类，实现父类中的业务方法，并通过组合关系调用实现化角色中的业务方法。
    /// </summary>
    public abstract class Manager
    {
        protected Project CurrentProject { get; }

        protected Manager(Project currentProject)
        {
            CurrentProject = currentProject;
        }

        /// <summary>
        /// 制定计划
        /// </summary>
        public abstract void SchedulePlan();

        /// <summary>
        /// 任务分配
        /// </summary>
        public abstract void AssignTasks();

        /// <summary>
        /// 进度把控
        /// </summary>
        public abstract void ControlProcess();

        /// <summary>
        /// 项目管理
        /// </summary>
        public virtual void ManageProject()
        {
            SchedulePlan();
            AssignTasks();
            ControlProcess();
        }
    }

    /// <summary>
    /// 项目经理_实现化角色：定义实现化角色的接口，供扩展抽象化角色调用。
    /// </summary>
    public class ProjectManager : Manager
    {
        public ProjectManager(Project currentProject) : base(currentProject)
        {
        }

        public override void SchedulePlan()
        {
            base.CurrentProject.MakePlan();
        }

        public override void AssignTasks()
        {
            base.CurrentProject.ScheduleTask();
        }

        public override void ControlProcess()
        {
            base.CurrentProject.ControlProcess();
        }

        public override void ManageProject()
        {
            Console.WriteLine($"项目经理负责【{base.CurrentProject.ProjectName}】：");
            base.ManageProject();
        }
    }

    /// <summary>
    /// 产品经理_具体实现化角色：给出实现化角色接口的具体实现。
    /// </summary>
    public class ProductManger : Manager
    {
        public ProductManger(Project currentProject) : base(currentProject)
        {
        }

        public override void SchedulePlan()
        {
            base.CurrentProject.MakePlan();
        }

        public override void AssignTasks()
        {
            base.CurrentProject.ScheduleTask();
        }

        public override void ControlProcess()
        {
            base.CurrentProject.ControlProcess();
        }

        public void AnalyseRequirement()
        {
            base.CurrentProject.AnalyzeRequirement();
        }

        public void DesignProduct()
        {
            base.CurrentProject.DesignProduct();
        }

        public override void ManageProject()
        {
            Console.WriteLine($"产品经理负责【{base.CurrentProject.ProjectName}】：");
            AnalyseRequirement();
            DesignProduct();
            base.ManageProject();
        }
    }
}