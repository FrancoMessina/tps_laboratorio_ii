using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color):base(marca,chasis,color)
        {
        }
        
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        /// 

        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("CICLOMOTOR");
            datos.AppendLine(base.Mostrar());
            datos.AppendLine($"TAMAÑO : {Tamanio}");
            datos.AppendLine("");
            datos.AppendLine("---------------------");
            return datos.ToString();
        }
    }
}
