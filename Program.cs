using System;
using System.Collections.Generic;

namespace EmployeeManagementSystem
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
                if (value < 0)
                {
                    throw new ArgumentException("Salary can't be negative.");
                }
                salary = value;
            }
        }

        private static int totalEmployees;
        public static int TotalEmployees
        {
            get { return totalEmployees; }
        }

        public Employee(int id, string name, string department, double salary)
        {
            Id = id;
            Name = name;
            Department = department;
            Salary = salary;
        }

        public static void IncrementEmployeeCount()
        {
            totalEmployees++;
        }

        public static void DecrementEmployeeCount()
        {
            totalEmployees--;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Department: {Department}, Salary: {Salary:C}");
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public void UpdateDepartment(string newDepartment)
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

        public Manager(int id, string name, string department, double salary, int teamSize) : base(id, name, department, salary)
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

    public class Developer : Employee
    {
        public List<string> ProgrammingLanguages { get; private set; }

        public Developer(int id, string name, string department, double salary, List<string> programmingLanguages) : base(id, name, department, salary)
        {
            ProgrammingLanguages = new List<string>(programmingLanguages);
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Programming Languages: {string.Join(", ", ProgrammingLanguages)}");
        }

        public void AddProgrammingLanguage(string language)
        {
            ProgrammingLanguages.Add(language);
        }

        public void RemoveProgrammingLanguage(string language)
        {
            ProgrammingLanguages.Remove(language);
        }
    }

    public class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
            Employee.IncrementEmployeeCount();  
        }

        public void RemoveEmployee(int id)
        {
            Employee employee = employees.Find(emp => emp.Id == id);

            if (employee != null)
            {
                employees.Remove(employee);
                Employee.DecrementEmployeeCount();  

                Console.WriteLine($"Employee with ID {id} has been removed.");
            }
            else
            {
                Console.WriteLine($"Employee with ID {id} not found.");
            }
        }

        public void UpdateEmployee(int id, string newName, string newDepartment, double newSalary)
        {
            Employee employee = employees.Find(emp => emp.Id == id);

            if (employee != null)
            {
                employee.UpdateName(newName);
                employee.UpdateDepartment(newDepartment);
                employee.UpdateSalary(newSalary);
                Console.WriteLine($"Employee with ID {id} has been updated.");
            }
            else
            {
                Console.WriteLine($"Employee with ID {id} not found.");
            }
        }

        public void DisplayAllEmployees()
        {
            foreach (var employee in employees)
            {
                employee.DisplayDetails();
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Employee Management System \n");

            EmployeeManager employeeManager = new EmployeeManager();

            var employeesToAdd = new List<Employee>
            {
                new Manager(1, "Abc xyz", "Sales", 90000, 10),
                new Developer(2, "Bob Smith", "IT", 75000, new List<string> { "C#", "JavaScript" }),
                new Developer(3, "Bob Smith2", "IT", 72000, new List<string> { "C#", "JavaScript" })
            };

            foreach (var employee in employeesToAdd)
            {
                employeeManager.AddEmployee(employee);
            }

            employeeManager.DisplayAllEmployees();

            employeeManager.UpdateEmployee(1, "Alice Brown", "Marketing", 95000);

            employeeManager.RemoveEmployee(2);

            employeeManager.DisplayAllEmployees();

            Console.WriteLine($"Total Employees: {Employee.TotalEmployees}");

            Console.ReadLine();
        }
    }
}
