using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) 
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public override void PrintEmployee(Employee employee)
        {
            Console.WriteLine("Kenef");
        }

        public IReadOnlyCollection<string> Documents { get; set; }
    }
}
