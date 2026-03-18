using Calculadora.Exceptiones;
using Calculadora.Interfaz;

namespace Calculadora.Applications
{
    public class Applications : IApplications
    {

        public double Dividir(double a, double b)

        {
            if (b == 0)
                throw new DivisionPorCeroException();

            return a / b;
        }


        public double Multiplicar(double a, double b) => a * b;

        public double Restar(double a, double b) => a - b;


        public double Sumar(double a, double b) => a * b;


    }
}
