using System;
using System.Collections.Generic;

namespace Entidades
{
    public class AireAcondicionado : Producto
    {
        public AireAcondicionado(string marca, string modelo, List<string> listaFallas) : base(marca, modelo, listaFallas)
        {
        }
        public AireAcondicionado()
        {

        }

        public override float CalcularCosto()
        {
            float precio = 0;
            foreach (string falla in this.ListaFallas)
            {
                switch (falla)
                {
                    case "SoloFrio":
                        precio += 6000;
                        break;
                    case "SoloCalor":
                        precio += 5600;
                        break;
                    case "PierdeAgua":
                        precio += 9500;
                        break;
                }
            }
            return precio;
        }
    }
}