using PersonalRegister;
using System.Text.RegularExpressions;


//List<Employee> employeeRegister = new List<Employee>();
Dictionary<int, Employee> employeeRegister = new Dictionary<int, Employee>();
MenuChoices menuChoice = MenuChoices.View;
int employeeId = 0;

MenuMessage();
while (menuChoice != MenuChoices.Exit)
{
    Console.Write("Input: ");
    if(Enum.TryParse(Console.ReadLine(),out menuChoice))
    {
        Console.Clear();
        MenuMessage();
        switch (menuChoice)
        {
            case MenuChoices.View:
                Console.WriteLine("-- List of employees -- ");
                ViewEmployees();
                break;

            case MenuChoices.Add:
                Console.WriteLine("-- Add employee --");
                AddEmployee();
                break;

            case MenuChoices.Edit:
                Console.WriteLine("-- Edit employees --");
                EditEmployee();
                break;

            case MenuChoices.Remove:
                Console.WriteLine("-- Remove employee --");
                RemoveEmployee();
                break;

            case MenuChoices.Exit:
                Console.WriteLine("Exiting...");
                menuChoice = MenuChoices.Exit;
                break;
            default:
                Console.Clear();
                MenuMessage();
                Console.WriteLine("Invalid input");
                break;
        }
    }
    else
    {
        Console.Clear();
        MenuMessage();
        Console.WriteLine("Invalid input");
    }    
}


void ViewEmployees()
{
    foreach(var employee in employeeRegister)
    {
        Console.WriteLine($"ID: {employee.Value.ID}, Name: {employee.Value.FirstName} {employee.Value.LastName}, Salary: {employee.Value.Salary}");
    }
    Console.WriteLine("");
}

void AddEmployee()
{
    Console.Write("\nFirst name: ");
    var fName = Console.ReadLine();
    Console.Write("Last name: ");
    var lName = Console.ReadLine();
    Console.Write("Salary: ");
    int salary;
    if (int.TryParse(Console.ReadLine(), out salary) && fName != null && lName != null)
    {
        employeeRegister.Add(employeeId ,new Employee(employeeId, fName, lName, salary));
        employeeId++;
        Console.Clear();
        MenuMessage();
        Console.WriteLine("Employee added successfully");
    }
    else
    {
        Exit();
    }
}

void Exit()
{
    Console.WriteLine("Invalid input, exiting.");
    menuChoice = MenuChoices.Exit;
}

void EditEmployee()
{
    Console.Write("Enter employee ID: ");
    var result = ValidateID(Console.ReadLine());
    //if (int.TryParse(Console.ReadLine(), out id) && employeeRegister.ContainsKey(id))
    if(result.valid)
    {
        Console.Write("\nNew first name: ");
        var newFname = Console.ReadLine();
        Console.Write("New last name: ");
        var newLname = Console.ReadLine();
        Console.Write("New salary: ");
        int newSalary;
        if (int.TryParse(Console.ReadLine(), out newSalary) && newFname != null && newLname != null)
        {
            employeeRegister[result.id].FirstName = newFname;
            employeeRegister[result.id].LastName = newLname;
            employeeRegister[result.id].Salary = newSalary;
            Console.Clear();
            MenuMessage();
            Console.WriteLine("Employee edited successfully");
        }
        else
        {
            Exit();
        }
    }
    else
    {
        Exit();
    }
}

void RemoveEmployee()
{
    Console.Write("Enter ID of employee to remove: ");
    var input = Console.ReadLine();
    var result = ValidateID(input);
    if(result.valid) 
    {
        employeeRegister.Remove(result.id);
        Console.Clear();
        MenuMessage();
        Console.WriteLine("Employee removed successfully");
    }
    else
    {
        Exit();
    }
}

(bool valid, int id) ValidateID(string? input)
{
    int id = -1;
    return ((input != null && int.TryParse(input, out id) && employeeRegister.ContainsKey(id)), id);
}


void MenuMessage()
{
    Console.WriteLine("-- Employee Register --");
    Console.WriteLine("[0] - View employees");
    Console.WriteLine("[1] - Add employee");
    Console.WriteLine("[2] - Edit employee");
    Console.WriteLine("[3] - Remove employee");
    Console.WriteLine("[9] - Exit\n");
}

enum MenuChoices { View, Add, Edit, Remove, Exit = 9 };
