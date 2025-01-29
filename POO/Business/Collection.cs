using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Business
{
    public class Collection<T>
    {
        private T[] _elements;
        private int _index;
        private int _limit;

        public Collection(int limit)
        {
            _index = 0;
            _limit = limit;
            _elements = new T[_limit];
        }
        public void Add(T element)
        {
            if (_index < _limit)
            {
                _elements[_index] = element;
                _index++;
            }
        }

        public T[] get()
        => _elements;
    }
}
