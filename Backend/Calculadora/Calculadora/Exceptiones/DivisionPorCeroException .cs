namespace Calculadora.Exceptiones
{
    public class DivisionPorCeroException : Exception

    {
        public DivisionPorCeroException()
            : base("No se puede dividir entre cero.") { }
    }
}

