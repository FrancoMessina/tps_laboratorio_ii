using System;

namespace Entidades.Excepciones
{
    public  class NumeroInvalidoExcepction : Exception
    {
        public NumeroInvalidoExcepction(string mensaje) : base(mensaje)
        {

        }
    }
}
