using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IArchivos<T> where T : class
    {
        /// <summary>
        /// Metodo que va a escribir un dato generico.
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo que vamos a Escribi</param>
        /// <param name="elemento">nombre del Elemento a escribir</param>
        /// <returns>Retornará un mensaje dependiendo el caso</returns>
        string Escribir(string nombreArchivo, T elemento);
    }
}
