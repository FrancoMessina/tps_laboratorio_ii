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

        public string Escribir(string nombreArchivo, string contenido)
        {
            try
            {
                string ruta = $"{rutaBase}\\{nombreArchivo}{DateTime.Now.ToString("HH_mm_ss")}.txt";
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
