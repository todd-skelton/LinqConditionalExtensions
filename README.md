#### Latest [![](https://img.shields.io/nuget/vpre/LinqConditionalExtensions.svg)](https://www.nuget.org/packages/LinqConditionalExtensions)
#### Stable [![](https://img.shields.io/nuget/v/LinqConditionalExtensions.svg)](https://www.nuget.org/packages/LinqConditionalExtensions)

# LinqConditionalExtensions
These extensions make it easy to chain Linq expressions based on conditions—useful for sorting, filtering, and paging.

## Installation
### Package Manager
`Install-Package LinqConditionalExtensions`

### .NET CLI
`dotnet add package LinqConditionalExtensions`

## How to Use
### Conditionals
Any extension for `IEnumerable<T>` and `IQueryable<T>` that returns itself can be called with `If` appended to it and be conditionally applied.

Here is a sample for applying where clauses conditionally based on filters, ordering by a column, and paging the results. When using something like Entity Framework, this entire chain will be dynamically converted straight to SQL and make your query time much shorter.
```csharp
var results = _context.Employees
	.WhereIf(!string.IsNullOrWhitespace(nameFilter), e => e.Name.Contains(nameFilter))
	.WhereIf(!string.IsNullOrWhitespace(positionFilter), e => e.Position.Contains(positionFilter))
	.WhereIf(!string.IsNullOrWhitespace(idFilter), e => e.Id == idFilter)
	.OrderByIf(columnSort == "Name", e => e.Name)
	.OrderByIf(columnSort == "Position", e => e.Position)
	.OrderByIf(columnSort == "Id", e => e.Id)
	.SkipIf(isPaged, pageNumber * resultsPerPage)
	.TakeIf(isPaged, resultsPerPage)
	.ToList();
```

### If Chain
You can use an if chain to add if statement logic to your queryable or enumerable. If chains require you to have an `Else()` call to end the statement. You can add as many `ElseIf()` conditions in between.

In this example, a position and name is being used to filter a list of employees to find only the ones who fall under them on the org chart. The CEO returns all employees. The vice president and manager are used to filter by their respective properties. Otherwise, no employees are returned by appylying a where false.

```csharp
var position = "VP";
var name = "Todd Skelton";

var subordinates = employeeDirectory
	.IfChain(position == "CEO", employees => employees)
	.ElseIf(position == "VP", employees => employees.Where(employee => employee.VicePresidentName == name))
	.ElseIf(position == "Manager", employees => employees.Where(employee => employee.ManagerName == name))
	.Else(employees => employees.Where(employee => false));
```

In this sample, instead of returning the subordinates, we are just getting the count. You can do a transformation on the result. You just have to make sure each method in the chain returns the same type.

```csharp
var position = "VP";
var name = "Todd Skelton";

var subordinateCount = employeeDirectory
	.IfChain(position == "CEO", employees => employees.Count())
	.ElseIf(position == "VP", employees => employees.Where(employee => employee.VicePresidentName == name).Count())
	.ElseIf(position == "Manager", employees => employees.Where(employee => employee.ManagerName == name).Count())
	.Else(employees => 0);
```

### Switch
You can use a switch statement to chain together case statements. This is really useful for applying sorts.

In the example, a switch chain is being used to order results based on the column sort string.

```csharp
var columnSort = "Id";
var columnSort = "Name";

var sortedResults = results
	.Switch(columnSort)
	.Case("Name", set => set.OrderBy(e => e.Name))
	.Case("Position", set => set.OrderBy(e => e.Position))
	.Case("VicePresidentName", set => set.OrderBy(e => e.VicePresidentName))
	.Case("ManagerName", set => set.OrderBy(e => e.ManagerName))
	.Default();
```

You can also do a transformation in the switch chain, but you'll have to specify the type.

In this example, the types are string for the switch, Employee for the source, and int for the result.

```csharp
var department = "IT";

var total = employeeDirectory
	.Switch<string, Employee, int>(department)
	.Case("IT", set => set.Where(e => e.Department == "Information Technology").Count())
	.Default(set => 0);
```
