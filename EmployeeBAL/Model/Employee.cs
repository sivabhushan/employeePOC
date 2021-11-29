using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeBAL.Model
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Experience { get; set; }

        public double Salary { get; set; }

        public string Team { get; set; }
    }
}
