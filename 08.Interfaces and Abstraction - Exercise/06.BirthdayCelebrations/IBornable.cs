using System;

namespace _06.BirthdayCelebrations
{
    public interface IBornable
    {
        DateTime BirthDate { get; set; }

        string Name { get; set; }
    }
}
