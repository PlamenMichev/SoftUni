using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    public class Lake<T> : IEnumerable<int>
    {
        private List<int> stones;

        public Lake(params int[] stones)
        {
            this.stones = stones.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i += 2)
            {
                yield return stones[i];
            }

            int startReversedIndex = this.stones.Count % 2 == 0
                ? this.stones.Count - 1
               : this.stones.Count - 2;
            for (int i = startReversedIndex; i >= 0; i -= 2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}