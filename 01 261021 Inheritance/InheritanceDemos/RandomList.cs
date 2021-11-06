using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemos
{
    public class RandomList<T> : List<T>
    {
        private Random random;

        public RandomList()
        {
            random = new Random();
        }

        public T GetRandomElement()
        {
            var index = random.Next(0, Count);
            return this[index];
        }
        
        public void RemoveRandomElement()
        {
            var index = random.Next(0, Count);
            RemoveAt(index);
        }
    }
}
