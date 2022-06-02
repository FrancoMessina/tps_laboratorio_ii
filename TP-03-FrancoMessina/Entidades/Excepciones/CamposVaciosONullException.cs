using System;

namespace Entidades.Excepciones
{
    public class CamposVaciosONullException : Exception
    {
        public CamposVaciosONullException(string mensaje) : base(mensaje)
        {

        }
    }
}
