using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Salaried : Employee
    {
        private double salary;

        public double Salary
        {
            get { return salary; } 
            set { salary = value; }
        }

        public Salaried() { }

        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Sin = sin;
            this.Dob = dob;
            this.Dept = dept;
            this.Salary = salary;
        }

        public override double getPay()
        {
            return salary;
        }
    }
}
