using System;

namespace Entidades.Excepciones
{
    public  class NumeroInvalidoExcepcion : Exception
    {
        public NumeroInvalidoExcepcion(string mensaje) : base(mensaje)
        {

        }
    }
}
