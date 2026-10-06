using System; // Permite usar Console.
using System.Collections.Generic; // Permite usar List.
using System.Globalization; // Permite elegir el formato de los números.

// namespace agrupa las clases del proyecto bajo un mismo nombre.
namespace Personalregister
{
    class Program
    {
        // Main es el punto de inicio del programa.
        // static permite llamarlo sin crear un objeto Program.
        // void significa que no devuelve un resultado.
        static void Main()
        {
            // Elegimos el formato sueco para escribir decimales con coma.
            CultureInfo.CurrentCulture = new CultureInfo("sv-SE");

            // new crea el registro. Lo creamos antes del bucle para conservarlo.
            EmployeeRegister register = new EmployeeRegister();

            // bool solo guarda true (verdadero) o false (falso).
            bool running = true;

            // while repite su bloque mientras running sea true.
            while (running)
            {
                // WriteLine escribe y pasa a la siguiente línea.
                Console.WriteLine();
                Console.WriteLine("1. Lägg till anställd");
                Console.WriteLine("2. Visa personalregistret");
                Console.WriteLine("0. Avsluta");
                // Write escribe sin pasar a la siguiente línea.
                Console.Write("Välj: ");

                // ReadLine lee texto hasta que pulsamos Enter.
                // string? permite texto o null (ausencia de valor).
                // choice solo se puede usar dentro de este bloque while.
                string? choice = Console.ReadLine();

                // if ejecuta su bloque si la condición es verdadera.
                // == compara valores. = asigna un valor a una variable.
                if (choice == "1")
                {
                    // Pasamos el registro existente al método.
                    AddEmployee(register);
                }
                else if (choice == "2")
                {
                    PrintEmployees(register);
                }
                else if (choice == "0" || choice == null)
                {
                    // || significa "o". null aparece si se cierra la entrada.
                    // running está declarada en Main: también se usa en el bucle.
                    running = false;
                }
                else
                {
                    // else se ejecuta si no se cumple ninguna condición anterior.
                    Console.WriteLine("Välj 1, 2 eller 0.");
                }
            }
        }

        // register es un parámetro que recibe el mismo objeto creado en Main.
        static void AddEmployee(EmployeeRegister register)
        {
            Console.Write("Namn: ");
            string? name = Console.ReadLine();

            // Comprueba si falta el nombre o si solo contiene espacios.
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Namnet får inte vara tomt.");
                // return termina este método y vuelve a quien lo llamó: Main.
                return;
            }

            Console.Write("Lön i SEK (exempel 25000,50): ");
            string? input = Console.ReadLine();

            // Variables locales: solo se usan dentro de AddEmployee.
            decimal salary;
            // TryParse intenta convertir texto a número sin cerrar el programa.
            // Devuelve true si funciona. out coloca el número en salary.
            bool validSalary = decimal.TryParse(input, out salary);

            // Comprobamos por separado si es un número y si es negativo.
            // == false significa que la conversión no funcionó.
            if (validSalary == false)
            {
                Console.WriteLine("Ange en giltig lön, till exempel 25000,50.");
                return;
            }

            // < significa "menor que".
            if (salary < 0)
            {
                Console.WriteLine("Lönen får inte vara negativ.");
                return;
            }

            // Creamos un empleado y después rellenamos sus dos campos.
            Employee employee = new Employee();
            // El punto permite acceder a un campo o método del objeto.
            // Trim elimina espacios al principio y al final del nombre.
            employee.Name = name.Trim();
            employee.Salary = salary;

            register.Add(employee);
            Console.WriteLine("Den anställda har lagts till.");
        }

        static void PrintEmployees(EmployeeRegister register)
        {
            List<Employee> employees = register.GetAll();

            // Count indica cuántos empleados tiene la lista.
            if (employees.Count == 0)
            {
                Console.WriteLine("Registret är tomt.");
                return;
            }

            // foreach recorre la lista, un empleado por vuelta.
            // Esta variable employee solo existe dentro del foreach.
            foreach (Employee employee in employees)
            {
                // + une textos. ToString("F2") muestra dos decimales.
                Console.WriteLine("Namn: " + employee.Name
                    + " | Lön: " + employee.Salary.ToString("F2") + " SEK");
            }
        }
    }
}
