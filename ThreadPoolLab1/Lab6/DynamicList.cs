using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class DynamicList<T> : IEnumerable<T>
    {
        private T[] _array;

        public int Count
        {
            get
            {
                return _array.Length;
            }
        }

        public DynamicList()
        {
            this._array = new T[0];
        }

        public void Add(T t)
        {
            Array.Resize(ref _array,Count + 1);
            _array[Count-1] = t; 
        }

        public void Remove(T t)
        {
            int index = -1;
            for(int i = 0; i < Count; i++)
            {
                if (_array[i].Equals(t))
                {
                    index = i;
                    break;
                }
            }

            this.RemoveAt(index);
        }

        public void RemoveAt(int index)
        {

            for (int i = index; i < Count - 1; i++)
            {
                T buff = _array[i];
                _array[i] = _array[i + 1];
                _array[i + 1] = buff;
            }

            Array.Resize(ref this._array, Count - 1);
        }

        public void Clear()
        {
            Array.Resize(ref this._array, 0);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }
    }
}

