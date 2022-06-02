using System;

namespace Entidades.Excepciones
{
    public class ServicioNoExistenteException : Exception
    {
        public ServicioNoExistenteException(string mensaje):base(mensaje)
        {

        }
    }
}
