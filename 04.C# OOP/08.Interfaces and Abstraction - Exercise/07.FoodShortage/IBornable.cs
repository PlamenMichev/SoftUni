using System;

namespace _07.FoodShortage
{
    public interface IBornable
    {
        DateTime BirthDate { get; set; }

        string Name { get; set; }
    }
}
