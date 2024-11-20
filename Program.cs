﻿using System;
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