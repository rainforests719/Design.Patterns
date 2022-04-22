﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Design.Patterns.Observer.Pattern_观察者模式_.EventBusExtensions
{
    /// <summary>
    /// 轻量级事件总线服务拓展
    /// </summary>
    public static class EventBusExtensions
    {
        //public static IServiceCollection AddSimpleEventBus(this IServiceCollection services)
        //{
        //    // 查找所有贴了 [SubscribeMessage] 特性的方法，并且含有两个参数，第一个参数为 string messageId，第二个参数为 object payload
        //    var typeMethods = Assembly.GetExecutingAssembly().GetTypes()
        //        // 查询符合条件的订阅类
        //        .Where(m => m.IsClass && !m.IsAbstract && !m.IsInterface && typeof(ISubscribeHandler).IsAssignableFrom(m))
        //        // 查询符合条件的订阅方法
        //        .SelectMany(n => n.GetMethods(BindingFlags.Public | BindingFlags.Instance)
        //        .Where(x => x.IsDefined(typeof(SubscribeMessageAttribute), false)
        //                                            && x.GetParameters().Length == 2
        //                                            && x.GetParameters()[0].ParameterType == typeof(string)
        //                                            && x.GetParameters()[1].ParameterType == typeof(object))
        //        //根据类分组
        //        .GroupBy(m => m.DeclaringType));

        //    if (!typeMethods.Any()) return services;

        //    // 遍历所有订阅类型
        //    foreach (var item in typeMethods)
        //    {
        //        if (!item.Any()) continue;

        //        //创建订阅类对象
        //        var typeInstance = Activator.CreateInstance(item.Key);

        //        foreach (var method in item)
        //        {
        //            // 判断是否是异步方法
        //            var isAsyncMethod = method.IsDefined();

        //            //创建委托类型,（将实例化类，类中的方法，定义方法参数弄成委托）
        //            var action = Delegate.CreateDelegate((isAsyncMethod ? typeof(Func<string, object, Task>) : typeof(Action<string, object>)), typeInstance, method.Name);

        //            // 获取单个方法的所有消息特性
        //            var subscribeMessageAttributes = method.GetCustomAttributes<SubscribeMessageAttribute>();

        //            //注册订阅
        //            foreach (var attr in subscribeMessageAttributes)
        //            {
        //                if (string.IsNullOrWhiteSpace(attr.MessageId)) continue;

        //                if (isAsyncMethod)
        //                {
        //                    InternalMessageCenter.Instance.Subscribe(item.Key, attr.MessageId, (Func<string, object, Task>)action);
        //                }
        //                else
        //                {
        //                    InternalMessageCenter.Instance.Subscribe(item.Key, attr.MessageId, (Action<string, object>)action);
        //                }
        //            }
        //        }
        //    }
        //    return services;
        //}
    }
}
