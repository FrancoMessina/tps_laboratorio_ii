using System;
using System.IO;
namespace Entidades.Gestor_de_Archivos
{
    public abstract class GestorDeArchivo
    {
        public enum ETipoArchivo { TXT, XML };
        protected string rutaBase;
        protected ETipoArchivo tipoArchivo;

        protected GestorDeArchivo(ETipoArchivo tipoArchivo)
        {
            string nombreCarpeta = "Archivos";
            DirectoryInfo ruta = Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\{nombreCarpeta}\\{tipoArchivo}\\");
            rutaBase = ruta.FullName;
            this.tipoArchivo = tipoArchivo;
        }
    }
}
