using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            int sum = numbers.Sum();
            double average = numbers.Average();
            Console.WriteLine($"Sum {sum} : Average {average}");

            //Order numbers in ascending order and decsending order. Print each to console.
            var orderNums = from num in numbers
                            orderby num
                            select num;

            Console.WriteLine("Ascending\n");
            foreach (var item in orderNums)
            {
                Console.WriteLine(item);
            }

            var orderNums2 = from num in numbers
                             orderby num descending
                             select num;

            Console.WriteLine("\nDescending\n");
            foreach (var item in orderNums2)
            {
                Console.WriteLine(item);
            }


            //Print to the console only the numbers greater than 6
            var numGreaterThan = numbers.Where(num => num > 6);

            foreach (var item in numGreaterThan)
            {
                Console.WriteLine(item);
            }

            //Order numbers in any order(acsending or desc) but only print 4 of them **foreach loop only!**
            var take4 = numbers.OrderByDescending(num => num).Take(4);

            foreach (var item in take4)
            {
                Console.WriteLine(item);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 59;
            var myself = numbers.OrderByDescending(num => num);

            foreach (var item in myself)
            {
                Console.WriteLine(item);
            }


            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var firstName = employees.Where(names => employees.Any(name => names.FirstName.StartsWith("S") ||
                            names.FirstName.StartsWith("C"))).OrderBy(name => name.FirstName);

            foreach (var item in firstName)
            {
                Console.WriteLine(item.FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var fullName = employees.Where(names => employees.Any(name => names.Age > 26)).
                OrderBy(name => name.FirstName).OrderBy(age => age.Age);

            foreach (var item in fullName)
            {
                Console.WriteLine($"{item.FullName} {item.Age}");
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            //Console.WriteLine(employees.Where(years => years.YearsOfExperience < 10 && years.Age > 35).Sum(x => x.YearsOfExperience));
            //Console.WriteLine(employees.Where(years => years.YearsOfExperience < 10 && years.Age > 35).Average(x => x.YearsOfExperience));
            //Console.ReadKey(true);

            //Add an employee to the end of the list without using employees.Add()\
            Employee emp = new Employee("Jay", "Snodderly", 59, 30);
            List<Employee> newEmployee = employees.Append(emp).ToList();

            foreach (var item in newEmployee)
            {
                Console.WriteLine($"{item.FullName} {item.Age} {item.YearsOfExperience}");
            }
            Console.ReadKey(true);

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}