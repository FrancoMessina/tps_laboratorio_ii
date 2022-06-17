using System;
using System.Collections.Generic;
namespace Entidades
{
    
    public class Control : Producto
    {

        private ETipoControl tipo;

        public Control(string marca, string modelo, List<string> listaFallas,ETipoControl tipo) : base(marca, modelo, listaFallas)
        {
            this.tipo = tipo;
        }
        public Control()
        {

        }
        /// <summary>
        /// Propiedad publica: Retornará el tipo de control (TV/AIRE) y se seteara el tipo de control.
        /// </summary>
        public ETipoControl Tipo { get { return this.tipo; } set { this.tipo = value; } }


        /// <summary>
        /// Se calcula el costo del servicio analizando la cantidad de fallas que tiene el producto y distintos
        /// tipos de fallo dependiendo de si ES TV/AIRE.
        /// </summary>
        /// <returns>Retorna el costo del servicio.</returns>
        public override float CalcularCosto()
        {
            float precio = 0;
            if (this.Tipo == ETipoControl.TV)
            {
                foreach (string falla in this.ListaFallas)
                {
                    switch (falla)
                    {
                        case "NoEmiteSenial":
                            precio += 600;
                            break;
                        case "NoFuncionaBoton":
                            precio += 400;
                            break;
                        case "PortaPilaSulfatado":
                            precio += 900;
                            break;
                    }
                }
            }
            else
            {
                foreach (string falla in this.ListaFallas)
                {
                    switch (falla)
                    {
                        case "DisplayRoto":
                            precio += 700;
                            break;
                        case "NoEmiteSenial":
                            precio += 600;
                            break;
                        case "BajaSenial":
                            precio += 300;
                            break;
                    }
                }
            }
            return precio;
        }
        /// <summary>
        /// Override de ToString que vamos a utilizar para mostrar el Tipo de Control y los datos de la clase base.
        /// </summary>
        /// <returns>Un string con los datos del Control</returns>
        public override string ToString()
        {
            return $"Tipo Control: {this.tipo}\t {base.ToString()}"; 
        }
    }
}
