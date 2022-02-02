using BankingModels.Interface;
using BankingModels.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text.Json;

namespace BankingSystem.Models
{
    static class SessionExtensions
    {
        private static Dictionary<string,ICardInfo> _data = new Dictionary<string, ICardInfo>();

        //public static void Set(this ISession session, string key, object value)
        //{
        //    if (_data.Count != 0)
        //    {
        //        _data.Clear();
        //    }

        //    _data.Add(key, (ICardInfo)value);
        //}

        //public static T Get<T>(this ISession session, string key)
        //{
        //    var value = _data[key];

        //    if (value == null)
        //    {
        //        return default(T);
        //    }

        //    return (T)value;
        //}

        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
        public static void Clear(this ISession session)
        {
            if (_data.Count != 0)
            {
                _data.Clear();
            }
        }
    }
}
