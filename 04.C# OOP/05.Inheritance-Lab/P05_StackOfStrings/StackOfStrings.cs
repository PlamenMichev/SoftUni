using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        private List<string> stack;

        public StackOfStrings()
        {
            this.stack = new List<string>();
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }

        public void Push(string item)
        {
            stack.Add(item);
        }

        public List<string> AddRange(List<string> items)
        {
            foreach (var item in items)
            {
                stack.Add(item);
            }

            return stack;
        }
    }
}
