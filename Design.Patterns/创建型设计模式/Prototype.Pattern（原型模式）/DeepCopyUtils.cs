using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Design.Patterns.PrototypePattern.DeepCopyUtils
{
    /// <summary>
    /// 深拷贝的几种方式
    /// </summary>
    public class DeepCopyUtils
    {
        /// <summary>
        /// 二进制序列化
        /// </summary>
        /// <typeparam name="T"> 类型参数 </typeparam>
        /// <param name="initialObj"> 初始对象 </param>
        /// <returns> T </returns>
        public static T BinaryDeepCopy<T>(T initialObj)
        {
            using (var memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, initialObj);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }

        /// <summary>
        /// Json 序列化
        /// </summary>
        /// <typeparam name="T"> 类型参数 </typeparam>
        /// <param name="initialObj"> 初始对象 </param>
        /// <returns> T </returns>
        public static T JsonDeepCopy<T>(T initialObj) => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(initialObj));

        /// <summary>
        /// 反射
        /// </summary>
        /// <typeparam name="T"> 类型参数 </typeparam>
        /// <param name="initialObj">
        /// <returns> T </returns>
        private static T ReflectionDeepCopy<T>(T initialObj)
        {
            T tOut = Activator.CreateInstance<T>();
            var tInType = initialObj.GetType();
            foreach (var itemOut in tOut.GetType().GetProperties())
            {
                var itemIn = tInType.GetProperty(itemOut.Name); ;
                if (itemIn != null)
                {
                    itemOut.SetValue(tOut, itemIn.GetValue(initialObj));
                }
            }
            return tOut;
        }

        /// <summary>
        /// 表达式目录树
        /// </summary>
        /// <typeparam name="TIn"> 需深拷贝的类型 </typeparam>
        /// <typeparam name="TOut"> 深拷贝得到的类型 </typeparam>
        public static class TransExp<TIn, TOut>
        {
            private static readonly Func<TIn, TOut> cache = GetFunc();
            private static Func<TIn, TOut> GetFunc()
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
                List<MemberBinding> memberBindingList = new List<MemberBinding>();

                foreach (var item in typeof(TOut).GetProperties())
                {
                    if (!item.CanWrite) continue;
                    MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }

                MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
                Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[] { parameterExpression });

                return lambda.Compile();
            }

            public static TOut Trans(TIn tIn)
            {
                return cache(tIn);
            }
        }
    }
}