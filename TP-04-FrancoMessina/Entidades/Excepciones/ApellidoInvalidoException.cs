using System;


namespace Entidades.Excepciones
{
    public class ApellidoInvalidoException : Exception
    {
        public ApellidoInvalidoException(string mensaje) : base(mensaje)
        {

        }
    }
}
