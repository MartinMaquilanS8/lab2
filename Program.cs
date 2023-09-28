using System.Collections.Generic;

namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("employees.txt");

            List<Employee> employees = new List<Employee>();

            foreach (string line in lines)
            {
                string[] columns = line.Split(':');

                //List<Employee> employees = new List<Employee>();

                string id = columns[0];

                char firstDigitOfId = id[0];

                if (firstDigitOfId == '0' || firstDigitOfId == '1' || firstDigitOfId == '2' || firstDigitOfId == '3' || firstDigitOfId == '4')
                {

                    employees.Add(new Salaried(
                        line.Split(':')[0],
                        line.Split(':')[1],
                        line.Split(':')[2],
                        line.Split(':')[3],
                        long.Parse(line.Split(':')[4]),
                        line.Split(':')[5],
                        line.Split(':')[6],
                        double.Parse(line.Split(':')[7])
                        ));
                }

                else if (firstDigitOfId == '5' || firstDigitOfId == '6' || firstDigitOfId == '7')
                {
                    employees.Add(new Wages(
                        line.Split(':')[0],
                        line.Split(':')[1],
                        line.Split(':')[2],
                        line.Split(':')[3],
                        long.Parse(line.Split(':')[4]),
                        line.Split(':')[5],
                        line.Split(':')[6],
                        double.Parse(line.Split(':')[7]),
                        double.Parse(line.Split(':')[8])
                        ));
                }

                //else (firstDigitOfId == '8' || firstDigitOfId == '9')
                else
                {
                    employees.Add(new PartTime(
                        line.Split(':')[0],
                        line.Split(':')[1],
                        line.Split(':')[2],
                        line.Split(':')[3],
                        long.Parse(line.Split(':')[4]),
                        line.Split(':')[5],
                        line.Split(':')[6],
                        double.Parse(line.Split(':')[7]),
                        double.Parse(line.Split(':')[8])
                        ));
                }

                
            }
            double averagePay = 0;

            foreach (Employee employee in employees)
            {

                averagePay += employee.getPay();

            }

            Console.WriteLine($"The average pay for all employees is ${averagePay / employees.Count():F2}");

            double highestPay = 0;
            string highestNamePay = "";

            foreach (Employee employee in employees)
            {
                if (employee is Wages wageEmployee)
                {
                    double weeklyPay = wageEmployee.getPay();
                    if (weeklyPay > highestPay)
                    {
                        highestPay = weeklyPay;
                        highestNamePay = employee.Name;
                    }
                }
            }

            Console.WriteLine($"The highest weekly pay is ${highestPay} for {highestNamePay}");

            double lowestSalary = double.MaxValue;
            string lowestNameSalary = "";

            foreach (Employee employee in employees)
            {
                if (employee is Salaried salariedEmployee)
                {
                    double salary = salariedEmployee.Salary;
                    if (salary < lowestSalary)
                    {
                        lowestSalary = salary;
                        lowestNameSalary = employee.Name;
                    }
                }
            }

            Console.WriteLine($"The lowest salary is ${lowestSalary} for {lowestNameSalary}");

            int totalEmployees = employees.Count;
            int salariedCount = 0;
            int wageCount = 0;
            int partTimeCount = 0;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    salariedCount = salariedCount + 1;
                }
                else if (employee is Wages)
                {
                    wageCount = wageCount + 1;
                }
                else if (employee is PartTime)
                {
                    partTimeCount = partTimeCount + 1;
                }
            }

            double salariedPercentage = (double)salariedCount / totalEmployees * 100;
            double wagePercentage = (double)wageCount / totalEmployees * 100;
            double partTimePercentage = (double)partTimeCount / totalEmployees * 100;

            Console.WriteLine($"{salariedPercentage:F2}% of the company are salaried employees.");
            Console.WriteLine($"{wagePercentage:F2}% of the company are waged employees.");
            Console.WriteLine($"{partTimePercentage:F2}% of the company are part time employees.");

        }
    }
}