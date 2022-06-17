using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entidades;
namespace Entidades.Gestor_de_Costos
{
    public delegate void InformacionDeCostoFinal(float costoFinal);
    public delegate void InformacionDeTiempo(int tiempo);
    public class GestionCostos
    {
        public event InformacionDeCostoFinal InformarCostoFinal;
        public event InformacionDeTiempo InformarTiempo;

        /// <summary>
        /// Un while que la condicion es que corra mientras tiempo es mayor a 0
        /// Dentro del while si el evento InformacionDeTiempo no es nulo se invoca.
        /// Un Thread.Sleep con el tiempo y luego se resta el tiempo.
        /// Al finalizar el While se pregunta si el evento InformacionDeCostoFinal no es nulo
        /// En ese caso se calculca el costo total con su respectivo metodo y  se invoca al evento
        /// InformacionDeCostoFinal con su respectivo parametro.
        /// </summary>
        /// <param name="lista"></param>
        public void IniciarCalculo(List<Servicio> lista)
        {
            int tiempo = 4000;
            float precio;
            while (tiempo > 0)
            {
                if (this.InformarTiempo is not null)
                {
                    this.InformarTiempo.Invoke(tiempo);
                }
                Thread.Sleep(tiempo);
                tiempo -= 1000;
            }
            if (this.InformarCostoFinal is not null)
            {
                precio = CalcularCosto(lista);
                this.InformarCostoFinal.Invoke(precio);
            }
        }
        /// <summary>
        /// Calcula el costo total de una lista de servicio
        /// </summary>
        /// <param name="lista">Lista de servicio a analizar</param>
        /// <returns>Precio TOTAL</returns>
        public float CalcularCosto(List<Servicio> lista)
        {
            float precioFinal = 0;
            foreach (Servicio servicio in lista)
            {
                precioFinal += servicio.Precio;
            }
            return precioFinal;
        }
    }
}
