using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BarracksWars_ReturnOfTheDependencies.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class InjectionAttribute : Attribute
    {
    }
}
