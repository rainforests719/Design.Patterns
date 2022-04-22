﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Patterns.Observer.Pattern_观察者模式_.EventBusExtensions
{
    /// <summary>
    /// 轻量级消息中心（进程内）
    /// </summary>
    internal sealed class InternalMessageCenter
    {
        /// <summary>
        /// 消息注册队列
        /// </summary>
        private readonly ConcurrentDictionary<string, Func<string, object, Task>[]> MessageHandlerQueues = new ConcurrentDictionary<string, Func<string, object, Task>[]>();

        /// <summary>
        /// 类型消息 Id 注册表
        /// </summary>
        private readonly ConcurrentBag<string> TypeMessageIdsRegisterTable = new ConcurrentBag<string>();

        /// <summary>
        /// 私有构造函数
        /// </summary>
        private InternalMessageCenter()
        {
        }

        private static readonly Lazy<InternalMessageCenter> lazy = new Lazy<InternalMessageCenter>(() => new InternalMessageCenter());

        /// <summary>
        /// 采用延迟加载设计模式处理单例 (为了避免每次运行都创建该对象，在第一次使用该对象时再对其进行初始化)
        /// </summary>
        private static readonly Lazy<InternalMessageCenter> InstanceLock = lazy;

        /// <summary>
        /// 获取消息中心对象
        /// </summary>
        internal static InternalMessageCenter Instance => InstanceLock.Value;

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="messageHandlers"></param>
        internal void Subscribe<T>(string messageId, params Action<string, object>[] messageHandlers)
        {
            Subscribe(typeof(T), messageId, messageHandlers);
        }

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="messageHandlers"></param>
        internal void Subscribe<T>(string messageId, params Func<string, object, Task>[] messageHandlers)
        {
            Subscribe(typeof(T), messageId, messageHandlers);
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        /// <param name="messageId"></param>
        internal void Unsubscribe(string messageId)
        {
            _ = MessageHandlerQueues.TryRemove(messageId, out _);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="payload"></param>
        /// <param name="isSync">是否同步执行</param>
        internal void Send(string messageId, object payload = null, bool isSync = false)
        {
            if (MessageHandlerQueues.TryGetValue(messageId, out var messageHandlers))
            {
                foreach (var eventHandler in messageHandlers)
                {
                    if (isSync)
                    {

                        eventHandler(messageId, payload).GetAwaiter().GetResult();
                    }
                    else
                    {
                        //后期采用后台任务定时执行
                        eventHandler(messageId, payload);
                    }
                }
            }
        }

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="t"></param>
        /// <param name="messageId"></param>
        /// <param name="messageHandlers"></param>
        internal void Subscribe(Type t, string messageId, params Action<string, object>[] messageHandlers)
        {
            if (messageHandlers == null || messageHandlers.Length == 0) return;

            var handlers = messageHandlers.Select(u =>
            {
                Func<string, object, Task> handler = async (m, o) =>
                {
                    u(m, o);
                    await Task.CompletedTask;
                };
                return handler;
            });

            Subscribe(t, messageId, handlers.ToArray());
        }

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="t"></param>
        /// <param name="messageId"></param>
        /// <param name="messageHandlers"></param>
        internal void Subscribe(Type t, string messageId, params Func<string, object, Task>[] messageHandlers)
        {
            if (messageHandlers == null || messageHandlers.Length == 0) return;

            // 判断当前类型是否已经注册过
            var uniqueMessageId = $"{t.FullName}_{messageId}";
            if (!TypeMessageIdsRegisterTable.Contains(uniqueMessageId))
            {
                TypeMessageIdsRegisterTable.Add(uniqueMessageId);
            }

            // 如果没有包含事件Id，则添加
            var isAdded = MessageHandlerQueues.TryAdd(messageId, messageHandlers);
            if (!isAdded)
            {
                MessageHandlerQueues[messageId] = MessageHandlerQueues[messageId].Concat(messageHandlers).ToArray();
            }
        }
    }
}
