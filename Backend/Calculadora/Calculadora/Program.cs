using Calculadora.Applications;
using Calculadora.Exceptiones;
using Calculadora.Interfaz;

internal class Program
{
    private static void Main(string[] args)
    {

        IApplications applications = new Applications();


        while (true)
        {
            try
            {
                Console.WriteLine("Ingrese el primer número:");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ingrese el segundo número:");
                double num2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ingrese operación (+, -, *, /):");
                char op = Convert.ToChar(Console.ReadLine());

                double resultado = 0;

                switch (op)
                {
                    case '+':
                        resultado = applications.Sumar(num1, num2);
                        break;
                    case '-':
                        resultado = applications.Restar(num1, num2);
                        break;
                    case '*':
                        resultado = applications.Multiplicar(num1, num2);
                        break;
                    case '/':
                        resultado = applications.Dividir(num1, num2);
                        break;
                    default:
                        Console.WriteLine("Operación no válida");
                        return;
                }

                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (DivisionPorCeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (OperacionInvalidaException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debes ingresar números válidos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }
    }
}