using System;


namespace Entidades.Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException(string mensaje) : base(mensaje)
        {

        }
    }
}
