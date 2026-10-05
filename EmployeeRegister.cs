
namespace Personalregister;

/// <summary>
/// Lagrar och hämtar anställda i minnet.
/// </summary>
public sealed class EmployeeRegister
{
    private readonly List<Employee> employees = new List<Employee>();

    public void Add(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);
        employees.Add(employee);
    }

    public IReadOnlyList<Employee> GetAll()
    {
        return employees.AsReadOnly();
    }
}