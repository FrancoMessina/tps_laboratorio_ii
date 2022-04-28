using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(marca, chasis, color)
        {
        }
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("SUV");
            datos.AppendLine(base.Mostrar());
            datos.AppendLine($"TAMAÑO : {this.Tamanio}");
            datos.AppendLine("");
            datos.AppendLine("---------------------");

            return datos.ToString();
        }
    }
}
