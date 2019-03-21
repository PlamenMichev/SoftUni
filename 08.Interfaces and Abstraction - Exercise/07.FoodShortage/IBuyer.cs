using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage
{
    public interface IBuyer
    {
        int Food { get; set; }

        int BuyFood();
    }
}
