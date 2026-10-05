using System.Globalization;


namespace Personalregister;

/// <summary>
/// Hanterar menyn samt inmatning och utskrift.
/// </summary>
internal static class Program
{
    private static readonly CultureInfo SalaryCulture =
        CultureInfo.GetCultureInfo("sv-SE");

    private static void Main()
    {
        var register = new EmployeeRegister();

        while (true)
        {
            Console.WriteLine("\n1. Lägg till anställd");
            Console.WriteLine("2. Visa personalregistret");
            Console.WriteLine("0. Avsluta");
            Console.Write("Välj: ");

            string? choice = Console.ReadLine();

            switch (choice?.Trim())
            {
                case "1":
                    if (!AddEmployee(register))
                    {
                        return;
                    }

                    break;

                case "2":
                    PrintEmployees(register);
                    break;

                case "0":
                case null:
                    return;

                default:
                    Console.WriteLine("Välj 1, 2 eller 0.");
                    break;
            }
        }
    }

    private static bool AddEmployee(EmployeeRegister register)
    {
        string? name;

        while (true)
        {
            Console.Write("Namn: ");
            name = Console.ReadLine();

            if (name is null)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                break;
            }

            Console.WriteLine("Namnet får inte vara tomt.");
        }

        decimal salary;

        while (true)
        {
            Console.Write("Lön i SEK (exempel 25000,50): ");
            string? input = Console.ReadLine();

            if (input is null)
            {
                return false;
            }

            bool valid = decimal.TryParse(
                input,
                NumberStyles.AllowLeadingSign |
                NumberStyles.AllowDecimalPoint |
                NumberStyles.AllowLeadingWhite |
                NumberStyles.AllowTrailingWhite,
                SalaryCulture,
                out salary);

            if (valid && salary >= 0)
            {
                break;
            }

            Console.WriteLine(
                "Ange ett giltigt belopp, minst 0. " +
                "Använd decimaltecken komma.");
        }

        var employee = new Employee(name, salary);
        register.Add(employee);

        Console.WriteLine("Den anställda har lagts till.");
        return true;
    }

    private static void PrintEmployees(EmployeeRegister register)
    {
        IReadOnlyList<Employee> employees = register.GetAll();

        if (employees.Count == 0)
        {
            Console.WriteLine("Registret är tomt.");
            return;
        }

        Console.WriteLine("\nPersonalregister");

        foreach (Employee employee in employees)
        {
            string formattedSalary =
                employee.Salary.ToString("F2", SalaryCulture);

            Console.WriteLine(
                $"Namn: {employee.Name} | Lön: {formattedSalary} SEK");
        }
    }
}