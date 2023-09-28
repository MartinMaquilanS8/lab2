using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class PartTime : Employee
    {
        private double rate;

        private double hours;

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public double Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        public PartTime() { }

        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
        {
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Sin = sin;
            this.Dob = dob;
            this.Dept = dept;
            this.Rate = rate;
            this.Hours = hours;

            //Rate = rate;
            //Hours = hours;
        }

        public override double getPay()
        {
            return rate * hours;
        }


    }
}
