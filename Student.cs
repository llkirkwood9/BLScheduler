using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLC_Scheduler
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private string email;
        private string schedulePath;
        private string deptName;
        private bool[,] availability = new bool[7, 16];
        private bool[,] preferred = new bool[7, 16];
        private bool[,] classAvail = new bool[7, 16];
        public float hours;
        private string color;

        public Student(string firstName, string lastName, string email, string schedulePath, string deptName, string color)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.schedulePath = schedulePath;
            this.deptName = deptName;
            this.color = color;
            hours = 0;
        }

        public Student()
        {
            hours = 0;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string SchedulePath { get => schedulePath; set => schedulePath = value; }
        public string DeptName { get => deptName; set => deptName = value; }
        public bool[,] Availability { get => availability; set => availability = value; }
        public bool[,] Preferred { get => preferred; set => preferred = value; }
        public string Color { get => color; set => color = value; }
        public bool[,] ClassAvail { get => classAvail; set => classAvail = value; }
    }
}
