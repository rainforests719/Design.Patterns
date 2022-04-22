using System;

namespace Design.Patterns.ProxyPattern
{
    /// <summary>
    /// The 'Subject interface
    /// </summary>
    public interface IMath
    {
        double Add(double x, double y);
    }

    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    public class Math : IMath
    {
        [Rewrite]
        public virtual double Add(double x, double y)
        {
            return x + y;
        }
    }

    /// <summary>
    /// 具体的某个拦截器
    /// </summary>
    public class Interceptor : IInterceptor
    {
        public object Intercept(Invocation invocation)
        {
            // TODO do something ...
            Console.WriteLine("start do something ...");

            var target = invocation.Proceed();
            Console.WriteLine($"target: {target}");

            // TODO do something ...
            Console.WriteLine("end do something ...");
            return target;
        }
    }

    /// <summary>
    /// Math Proxy_静态代理类
    /// </summary>
    public class MathProxy : IMath
    {
        // 可以使用组合聚合的方式
        private IMath _math;

        public MathProxy(IMath math)
        {
            if (math == null)
                _math = new Math();
            else
                this._math = math;
        }

        public double Add(double x, double y)
        {
            // TODO do something ...
            Console.WriteLine("start do something ...");

            var target = _math.Add(x, y);
            Console.WriteLine($"target: {target}");

            // TODO do something ...
            Console.WriteLine("end do something ...");
            return target;
        }
    }
}