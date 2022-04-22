using System;

namespace Design.Patterns.Mediator.Pattern.Standard
{
    /// <summary>
    /// 抽象中介者类
    /// </summary>
    public interface IMediator
    {
        public void Interaction(object sender, string name);
    }

    /// <summary>
    /// 抽象同事类
    /// </summary>
    public abstract class Colleague
    {
        protected IMediator _mediator;
        public Colleague(IMediator mediator = null) => this._mediator = mediator;
        public void SetMediator(IMediator mediator) => this._mediator = mediator;

        // Mediator 通知请求
        public abstract void Request(string message);
    }

    /// <summary>
    /// 具体中介者
    /// </summary>
    public class ConcreteMediator : IMediator
    {
        private Piece _piece;
        private Part _part;
        private Thing _thing;

        public ConcreteMediator(Piece piece, Part part, Thing thing)
        {
            this._piece = piece;
            this._part = part;
            this._thing = thing;
        }
        public void SetPiece(Piece piece) => this._piece = piece;
        public void SetPart(Part part) => this._part = part;
        public void SetThing(Thing thing) => this._thing = thing;

        public void Interaction(object sender, string name)
        {
            if (name.ToLower() == "Thing".ToLower())
            {
                Console.WriteLine("> Thing.......");
                this._thing.Invoke();
            }
            else if (name.ToLower() == "Part".ToLower())
            {
                Console.WriteLine("> Part.......");
                this._part.Invoke();
            }
            else if (name.ToLower() == "Piece".ToLower())
            {
                Console.WriteLine("> Piece.......");
                this._piece.Invoke();
            }
        }
    }

    public class BaseColleague
    {
        protected IMediator _mediator;

        public BaseColleague(IMediator mediator = null) => this._mediator = mediator;
        public void SetMediator(IMediator mediator) => this._mediator = mediator;
    }

    public class Thing : BaseColleague
    {
        public void Invoke()
        {
            this._mediator.Interaction(this, "Thing");
        }
    }

    public class Part : BaseColleague
    {
        public void Invoke()
        {
            this._mediator.Interaction(this, "Part");
        }
    }

    public class Piece : BaseColleague
    {
        public void Invoke()
        {
            this._mediator.Interaction(this, "Piece");
        }
    }
}