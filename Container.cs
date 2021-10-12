using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Road_Lap1
{
    public class Container<T> : IEnumerable<T>, IEnumerable
    {
        private HashSet<T> _hashSet;

        private static Container<T> _instance;

        public static Container<T> Instance => _instance ?? new Container<T>();

        private Container()
        {
            _instance = this;
            _hashSet = new HashSet<T>();
        }

        public void Register(T item) => _hashSet.Add(item);

        public void Unregister(T item) => _hashSet.Remove(item);

        public IEnumerator<T> GetEnumerator() => _hashSet.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
