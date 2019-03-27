namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type type = Type.GetType($"{typeof(AppEntryPoint).Namespace}.Models.Units.{unitType}");
            var constructor = type
                .GetConstructor(BindingFlags.Instance 
                | BindingFlags.Public 
                | BindingFlags.NonPublic, null, new Type[]{ }, null);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            IUnit unit = (IUnit)constructor.Invoke(new object[] { });

            return unit;
        }
    }
}
