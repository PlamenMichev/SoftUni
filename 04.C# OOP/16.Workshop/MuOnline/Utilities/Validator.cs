using System;
using System.Collections.Generic;
using System.Text;

namespace MuOnline.Utilities
{
    public static class Validator
    {
        public static void ValidateLessThanZero(string objectName, int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{objectName} cannot be less than zero!");
            }
        }
    }
}
