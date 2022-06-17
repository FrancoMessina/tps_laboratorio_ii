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
        public event InformacionDeCostoFinal InformacionDeCostoFinal;
        public event InformacionDeTiempo InformacionDeTiempo;

        public void IniciarCalculo(List<Servicio> lista)
        {
            int tiempo = 4000;
            float precio;
            while (tiempo > 0)
            {
                if (this.InformacionDeTiempo is not null)
                {
                    this.InformacionDeTiempo.Invoke(tiempo);
                }
                Thread.Sleep(tiempo);
                tiempo -= 1000;
            }
            if (this.InformacionDeCostoFinal is not null)
            {
                precio = CalcularCosto(lista);
                this.InformacionDeCostoFinal.Invoke(precio);
            }
        }
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
