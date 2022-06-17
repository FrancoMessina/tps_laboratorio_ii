using System;
using Entidades.Excepciones;
using System.IO;
using Entidades.Interfaces;
namespace Entidades.Gestor_de_Archivos
{
    public class ArchivoTXT : GestorDeArchivo, IArchivos<string>
    {
        public ArchivoTXT() : base(ETipoArchivo.TXT)
        {
        }
        /// <summary>
        /// Escribir el contenido que se envia por parametro en formato TXT.
        /// </summary>
        /// <param name="nombreArchivo">nombre del archivo</param>
        /// <param name="contenido">string con todo el contenido a escribir</param>
        /// <returns>Retorna un mensaje.</returns>
        /// <exception cref="ArchivoTxtException">Lanza la excepcion si hay  guardar los datos en formato TXT</exception>
        public string Escribir(string nombreArchivo, string contenido)
        {
            try
            {
                string ruta = $"{rutaBase}\\{nombreArchivo}{DateTime.Now.ToString("D")}.txt";
                using (StreamWriter streamWriter = new StreamWriter(ruta))
                {
                    streamWriter.WriteLine(contenido);
                }
                return "Ticket generado correctamente";
            }
            catch (Exception)
            {
                throw new ArchivoTxtException("Error al guardar los datos en formato TXT");
            }
            
        }
    }
}
