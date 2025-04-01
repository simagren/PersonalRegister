using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalRegister
{
    internal class Employee
    {
        private int id;
        private string firstName;
        private string lastName;
        private float salary;

        public Employee(int id, string firstName, string lastName, float salary) 
        { 
            this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
        }

        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public float Salary { get {  return salary; } set { salary = value; } }
        public int ID { get { return id; } }
    }
}
