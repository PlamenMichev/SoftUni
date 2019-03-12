using System;

namespace _03.Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] studentInfo = Console.ReadLine()
                .Split();
            string[] workerInfo = Console.ReadLine()
                .Split();

            try
            {
                string studentFirstName = studentInfo[0];
                string studentLastName = studentInfo[1];
                string facultyNumber = studentInfo[2];
                var student = new Student(studentFirstName, studentLastName, facultyNumber);

                string workerFirstName = workerInfo[0];
                string workerLastName = workerInfo[1];
                decimal weekSalary = decimal.Parse(workerInfo[2]);
                double workHours = double.Parse(workerInfo[3]);
                var worker = new Worker(workerFirstName, workerLastName, weekSalary, workHours);

                Console.WriteLine(student + Environment.NewLine);
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
