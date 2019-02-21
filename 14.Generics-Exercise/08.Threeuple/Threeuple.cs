using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    public class Threeuple<T, K, V>
    {
        public Threeuple(T item1, K item2, V item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        private T item1;

        private K item2;

        private V item3;

        public override string ToString()
        {

            return $"{this.item1} -> {this.item2} -> {this.item3}";

        }
    }
}
