namespace Calculadora.Exceptiones
{
    public class OperacionInvalidaException : Exception
    {
        public OperacionInvalidaException()
            : base("Operacion no valida.") { }
    }
}
