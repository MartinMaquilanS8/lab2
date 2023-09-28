using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Wages : Employee
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

        public Wages() { }

        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Sin = sin;
            this.Dob = dob;
            this.Dept = dept;
            this.Rate = rate;
            this.Hours = hours;
        }

        public override double getPay()
        {
            double pay;
            if (Hours > 40)
            {
                double overtimeHours = hours - 40;
                pay = (40 * rate) + (overtimeHours * 1.5 * rate);
            }
            else
            {
                pay = hours * rate;
            }
            return pay;
        }
    }
}
