using System.Collections.Generic;
namespace Entidades
{   
    public class Televisor : Producto 
    {
        private ETipoTv tipo;
        public Televisor(string marca, string modelo, List<string> listaFallas, ETipoTv tipo) : this(marca, modelo, listaFallas)
        {
            this.tipo = tipo;
        }
        private Televisor(string marca, string modelo, List<string> listaFallas): base(marca, modelo, listaFallas)
        {

        }
        public Televisor()
        {

        }
        /// <summary>
        /// Propiedad publica: Retornará el tipo y se seteara el tipo.
        /// </summary>
        public ETipoTv Tipo { get { return this.tipo; } set { this.tipo = value; } }
        /// <summary>
        /// Override de ToString que vamos a utilizar para mostrar el Tipo de Televisor y los datos de la clase base.
        /// </summary>
        /// <returns>Un string con los datos del Televisor</returns>
        public override string ToString()
        {
            return $"Tipo: {this.Tipo}\t{base.ToString()}"; 
        }
        /// <summary>
        /// Se calcula el costo del servicio analizando la cantidad de fallas que tiene el producto.
        /// </summary>
        /// <returns>Retorna el costo del servicio.</returns>
        public override float CalcularCosto()
        {
            float precio = 0;
            foreach (string falla in this.ListaFallas)
            {
                switch (falla)
                {
                    case "PantallaRota":
                        if (this.Tipo == ETipoTv.LED)
                            precio += 19500;
                        else
                            precio += 13450;
                        break;
                    case "SinAudio":
                        if (this.Tipo == ETipoTv.LED)
                            precio += 8750;
                        else
                            precio += 5500;
                        break;
                    case "SinImagen":
                        if (this.Tipo == ETipoTv.LED)
                            precio += 12000;
                        else
                            precio += 7000;
                        break;
                }
            }
            return precio;
        }

    }
}
