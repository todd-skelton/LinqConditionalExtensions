using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeDirectory = new List<Employee>()
            {
                new Employee{Name= "Raymond Madigan", Department="IT", Position = "VP"},
                new Employee{Name= "Lawanda Damon", Department="IT", Position = "Manager", VicePresidentName="Raymond Madigan"},
                new Employee{Name= "Fred Speier", Department="IT", ManagerName ="", Position = "Engineer", VicePresidentName="Raymond Madigan"},
                new Employee{Name= "Nadine Cook", Department="HR", Position = "VP"},
                new Employee{Name= "David Burnett", Department="HR", Position = "Manager", VicePresidentName="Nadine Cook"},
                new Employee{Name= "John Hernandez", Department="HR", ManagerName ="", Position = "Recruiter", VicePresidentName="Nadine Cook"},
                new Employee{Name= "Richard Miracle", Department="Executive", Position = "CEO"}
            };

            var position = "VP";
            var name = "Raymond Madigan";

            var subordinates = employeeDirectory
                .IfChain(position == "CEO", employees => employees)
                .ElseIf(position == "VP", employees => employees.Where(employee => employee.VicePresidentName == name))
                .ElseIf(position == "Manager", employees => employees.Where(employee => employee.ManagerName == name))
                .Else(employees => employees.Where(employee => false));

            var subordinateCount = employeeDirectory
                .IfChain(position == "CEO", employees => employees.Count())
                .ElseIf(position == "VP", employees => employees.Where(employee => employee.VicePresidentName == name).Count())
                .ElseIf(position == "Manager", employees => employees.Where(employee => employee.ManagerName == name).Count())
                .Else(employees => 0);

            var columnSort = "Name";

            var sortedResults = employeeDirectory
                .Switch(columnSort)
                .Case("Name", set => set.OrderBy(e => e.Name))
                .Case("Position", set => set.OrderBy(e => e.Position))
                .Case("VicePresidentName", set => set.OrderBy(e => e.VicePresidentName))
                .Case("ManagerName", set => set.OrderBy(e => e.ManagerName))
                .Default();

            var sortedResults2 = employeeDirectory
                .Switch(columnSort)
                .OrderByCase("Name", e => e.Name)
                .OrderByCase("Position", e => e.Position)
                .OrderByCase("VicePresidentName", e => e.VicePresidentName)
                .OrderByCase("ManagerName", e => e.ManagerName)
                .Default();

var sort = (column: "Name", direction: "asc");

var sortedResults3 = employeeDirectory
    .Switch(sort)
    .OrderByCase(e => e.column == "Name" && e.direction == "asc", e => e.Name)
    .OrderByDescendingCase(e => e.column == "Name" && e.direction == "desc", e => e.Name)
    .OrderByCase(e => e.column == "Position" && e.direction == "asc", e => e.Position)
    .OrderByDescendingCase(e => e.column == "Position" && e.direction == "desc", e => e.Position)
    .OrderByCase(e => e.column == "VicePresidentName" && e.direction == "asc", e => e.VicePresidentName)
    .OrderByDescendingCase(e => e.column == "VicePresidentName" && e.direction == "desc", e => e.VicePresidentName)
    .OrderByCase(e => e.column == "ManagerName" && e.direction == "asc", e => e.VicePresidentName)
    .OrderByDescendingCase(e => e.column == "ManagerName" && e.direction == "desc", e => e.VicePresidentName)
    .OrderByDefault(e => e.Name);

            var department = "IT";

            int total = employeeDirectory
                .Switch<string, Employee, int>(department)
                .Case("IT", set => set.Where(e => e.Department == "Information Technology").Count())
                .Case("HR", set => set.Where(e => e.Department == "Human Resources").Count())
                .Default(set => 0);

            var condition = true;

            var query = employeeDirectory
                .If(condition, employees => employees
                    .Where(e => e.Name == "Something")
                    .OrderBy(e => e.Department));
        }

        public class Employee
        {
            public string Name { get; set; }
            public string Position { get; set; }
            public string VicePresidentName { get; set; }
            public string ManagerName { get; set; }
            public string Department { get; set; }
        }
    }
}
