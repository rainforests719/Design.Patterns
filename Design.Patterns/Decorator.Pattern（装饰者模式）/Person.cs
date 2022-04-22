using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Patterns.Decorator_装饰器模式_
{
    /// <summary>
    /// 人_Person_ConcreteComponent
    /// </summary>
    public class Person
    {
        private string _name;

        public Person() { }
        public Person(string name) { _name = name; }

        public virtual void Show()
        {
            Console.WriteLine($"装扮的{_name}");
        }
    }

    /// <summary>
    /// Finery_服饰_Decorator
    /// </summary>
    public class Finery : Person
    {
        protected Person _personComponent;

        /// <summary>
        /// 装扮
        /// </summary>
        /// <param name="personComponent"> Person_ConcreteComponent </param>
        public void Decorate(Person personComponent)
        {
            this._personComponent = personComponent;
        }

        public override void Show()
        {
            if (_personComponent != null)
                _personComponent.Show();
        }
    }

    /// <summary>
    /// 具体服饰类_ConcreteDecorator
    /// </summary>
    public class TShirts : Finery
    {
        public override void Show()
        {
            Console.WriteLine("大T恤 ");
            base.Show();
        }
    }

    /// <summary>
    /// 具体服饰类_ConcreteDecorator
    /// </summary>
    public class BigTrouser : Finery
    {
        public override void Show()
        {
            Console.WriteLine("垮裤 ");
            base.Show();
        }
    }
}
