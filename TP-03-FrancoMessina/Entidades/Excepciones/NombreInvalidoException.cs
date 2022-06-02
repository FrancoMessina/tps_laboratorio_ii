using System;


namespace Entidades.Excepciones
{
    public class NombreInvalidoException : Exception
    {
        public NombreInvalidoException(string mensaje) : base(mensaje)
        {

        }
    }
}
