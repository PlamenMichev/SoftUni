namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            string methodTokens = Console.ReadLine();
            Type type = typeof(BlackBoxInteger);
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(int)}, null);
            BlackBoxInteger classInstance = (BlackBoxInteger)constructor.Invoke(new object[] { 0 });

            while (methodTokens != "END")
            {
                string[] tokens = methodTokens.Split("_");
                string name = tokens[0];
                int value = int.Parse(tokens[1]);

                MethodInfo currentMethod = type.GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic);
                currentMethod.Invoke(classInstance, new object[] { value });
                FieldInfo field = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

                Console.WriteLine($"{field.GetValue(classInstance)}");

                methodTokens = Console.ReadLine();
            }
        }
    }
}
