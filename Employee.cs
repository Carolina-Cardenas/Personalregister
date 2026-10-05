namespace Personalregister;

/// <summary>
/// Representerar en anställd med namn och lön.
/// </summary>
public sealed class Employee
{
    public string Name { get; }
    public decimal Salary { get; }

    public Employee(string name, decimal salary)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "Namn krävs.",
                nameof(name));
        }

        if (salary < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(salary),
                "Lönen får inte vara negativ.");
        }

        Name = name.Trim();
        Salary = salary;
    }
}