using System;
using System.Collections.Generic;

namespace EmployeeManagmenetSystem
{
    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        private string department;
        public string Department
        {
            get { return department; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Department name must not be empty.");
                }
                department = value;
            }
        }
        private double salary;
        public double Salary
        {
            get { return salary; }
            private set
            {
                if(value <0 )
                {
                    throw new ArgumentException("Salary Can't be negative.");
                }
                salary = value;
            }
        }

        public static int TotalEmployees { get; private set; }

        public Employee(int id, string name, string department,double saary )
        {
            Id = id;
            Name = name;
            Department = department;
            Salary = saary;
            TotalEmployees++;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Department: {Department}, Salary: {Salary:C}");
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public void UpdateDepartment(string
            newDepartment)
        {
            Department = newDepartment;
        }

        public void UpdateSalary(double newSalary)
        {
            Salary = newSalary;
        }
    }

    public class Manager : Employee
    {
        public int TeamSize { get; private set; }

        public Manager(int id, string name, string deparment, double salary, int teamSize) : base (id , name,deparment, salary)
        {
            TeamSize = teamSize;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Team Size: {TeamSize}");
        }

        public void UpdateTeamSize(int newTeamSize)
        {
            TeamSize = newTeamSize;
        }
    }




    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("\n Employee Managment System \n");



            Console.ReadLine();
        }
    }
}