using System;

namespace Entidades.Excepciones
{
    public class ClienteNoExistenteException : Exception
    {
        public ClienteNoExistenteException(string mensaje): base(mensaje)
        {

        }
    }
}
