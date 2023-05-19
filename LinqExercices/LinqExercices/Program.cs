using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using LinqExercices.Entities;

namespace LinqExercices
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Employee> employees = new List<Employee>();

            Console.Write("Enter the file path: ");
            string path = Console.ReadLine();

            try
            {
                using(StreamReader sr = File.OpenText(path))
                {
                    while(!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                        employees.Add(new Employee(name, email, salary));
                    }
                    Console.WriteLine();
                    Console.Write("Enter salary: ");
                    double _salaryConsult = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    Console.WriteLine("Email of people whose salary is more than " + _salaryConsult.ToString("F2", CultureInfo.InvariantCulture));

                    var greatSalary = employees.Where(p => p.Salary >=  _salaryConsult).ToList();
                    foreach(Employee emp in greatSalary )
                    {
                        Console.WriteLine(emp.Email);
                    }

                    var sumSalary = employees.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
                    Console.Write("Sum of salary of people whose name starts with 'M': " + sumSalary.ToString("F2",CultureInfo.InvariantCulture));


                }



            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}