using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeDirectory = new List<Employee>();
            var position = "VP";
            var name = "Todd Skelton";

            var subordinates = employeeDirectory.IfChain(position == "CEO", employees => employees)
                                                .ElseIf(position == "VP", employees => employees.Where(employee => employee.VicePresidentName == name))
                                                .ElseIf(position == "Manager", employees => employees.Where(employee => employee.ManagerName == name))
                                                .Else(employees => employees.Where(employee => false));

            var subordinateCount = employeeDirectory.IfChain(position == "CEO", employees => employees.Count())
                                                    .ElseIf(position == "VP", employees => employees.Where(employee => employee.VicePresidentName == name).Count())
                                                    .ElseIf(position == "Manager", employees => employees.Where(employee => employee.ManagerName == name).Count())
                                                    .Else(employees => 0);

            var results = new List<Employee>();

            var columnSort = "Name";

            var sortedResults = results.Switch(columnSort)
                                        .Case("Name", set => set.OrderBy(e => e.Name))
                                        .Case("Position", set => set.OrderBy(e => e.Position))
                                        .Case("VicePresidentName", set => set.OrderBy(e => e.VicePresidentName))
                                        .Case("ManagerName", set => set.OrderBy(e => e.ManagerName))
                                        .Default();

            var department = "IT";

            int total = employeeDirectory.Switch<string, Employee, int>(department)
                                         .Case("IT", set => set.Where(e => e.Department == "Information Technology").Count())
                                         .Case("HR", set => set.Where(e => e.Department == "Human Resources").Count())
                                         .Default(set => 0);

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
