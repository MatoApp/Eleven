using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MatoApp.Utilities
{
    /// <summary>
    /// デバッグ用のログ出力クラス
    /// </summary>
    public static class Logger
    {
        public static void Log()
        {
            System.Diagnostics.StackFrame stackFrame = new(1);
            var methodName = stackFrame.GetMethod().Name;
            var className = stackFrame.GetMethod().ReflectedType.FullName;
            Debug.Log($"{className}.{methodName}");
        }

        public static void Log<T>(T obj)
        {
            Debug.Log(obj);
        }

        public static IObservable<T> Log<T>(this IObservable<T> self)
        {
            self.Subscribe(x => Debug.Log(x));
            return self;
        }

        public static IObservable<T> Log<T, U>(this IObservable<T> self, U obj)
        {
            self.Subscribe(_ => Debug.Log(obj));
            return self;
        }

        public static IObservable<T> Log<T, U>(this IObservable<T> self, Func<T, U> selector)
        {
            self.Subscribe(x => Debug.Log(selector(x)));
            return self;
        }

        public static IEnumerable<T> Log<T>(this IEnumerable<T> self)
        {
            self.ForEach(x => Debug.Log(x));
            return self;
        }

        public static IEnumerable<T> Log<T, U>(this IEnumerable<T> self, U obj)
        {
            self.ForEach(_ => Debug.Log(obj));
            return self;
        }

        public static IEnumerable<T> Log<T, U>(this IEnumerable<T> self, Func<T, U> selector)
        {
            self.ForEach(x => Debug.Log(selector(x)));
            return self;
        }
    }
}
