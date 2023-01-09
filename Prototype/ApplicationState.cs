using System.Collections;

namespace Prototype
{
    public class ApplicationState
    {
        private static Hashtable State = new Hashtable();
       
        public static void AddValue(string key, object value)
        {
            if (!State.ContainsKey(key))
            {
                State.Add(key, value);
            }
        }

        public static T GetValue<T>(string key)
        {
            if (State.ContainsKey(key))
            {
                return (T)State[key];
            }

            return default;
        }

        public static void UpdateValue(string key, object value)
        {
            if (State.ContainsKey(key))
            {
                State[key] = value;
            }
        }

        public static void DeleteValue(string key)
        {
            State.Remove(key);
        }

        public static void ClearCache()
        {
            State.Clear();
        }
    }
}
