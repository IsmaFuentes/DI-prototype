using System.Collections.Generic;
using Xamarin.Forms;

namespace Prototype.models
{
    public class CustomImageControl : Image
    {
        private Dictionary<string, object> data = new Dictionary<string, object>();
        
        public int gridRow { get; set; }
        public int gridCol { get; set; }

        public void set(string key, object o)
        {
            if (data.ContainsKey(key))
            {
                data[key] = o;
            }
            else
            {
                data.Add(key, o);
            }
        }

        public object get(string key)
        {
            if (data.ContainsKey(key))
            {
                return data[key];
            }

            return null;
        }

        public void remove(string key)
        {
            data.Remove(key);
        }
    }
}
