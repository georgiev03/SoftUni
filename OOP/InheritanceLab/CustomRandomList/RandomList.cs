using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rdm;

        public RandomList()
        {
            rdm = new Random();
        }
        public string RandomString()
        {
            int idx = rdm.Next(0, this.Count);
            string removed = this[idx];
            this.RemoveAt(idx);

            return removed;
        }
    }
}
