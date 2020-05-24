using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class OutputProccessor
    {
        public OutputProccessor()
        {

        }

        public string Output(Bag bag)
        {
            var sb = new StringBuilder();
            foreach (var category in bag.Categories)
            {
                sb.AppendLine($"<{category.Name}> ${category.GetSum()}");
                foreach (var item2 in category.Items.OrderByDescending(y => y.Name).ThenBy(y => y.Quantity))
                {
                    sb.AppendLine($"##{item2.Name} - {item2.Quantity}");
                }
            }

            return sb.ToString();
        }
    }
}
