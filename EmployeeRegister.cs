using System.Collections.Generic; // Permite usar List.

namespace Personalregister
{
    public class EmployeeRegister
    {
        // List<Employee> es una lista de empleados. new crea la lista vacía.
        // private permite usar este campo solo dentro de esta clase.
        // Al ser un campo, está disponible en los métodos del objeto.
        private List<Employee> employees = new List<Employee>();

        // Un método es un bloque de código que realiza una tarea.
        // void significa que no devuelve un resultado.
        // employee es el parámetro: el empleado que recibe este método.
        public void Add(Employee employee)
        {
            employees.Add(employee);
        }

        // Este método devuelve la lista. Por eso su tipo es List<Employee>.
        public List<Employee> GetAll()
        {
            return employees;
        }
    }
}
