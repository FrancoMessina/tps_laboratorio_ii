using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Televisor)), XmlInclude(typeof(Control)), XmlInclude(typeof(AireAcondicionado))]
    public abstract class Producto
    {
        private string marca;
        private string modelo;
        private List<string> listaFallas;

        public Producto(string marca, string modelo, List<string> listaFallas)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.listaFallas = listaFallas;
        }
        public Producto()
        {

        }
        /// <summary>
        /// Propiedad publica: Retornará la Marca y se seteara la Marca.
        /// </summary>
        public string Marca 
        { 
            get 
            { 
                return this.marca; 
            }
            set
            {
                this.marca = value;
            }
        }
        /// <summary>
        /// Propiedad publica: Retornará el Modelo y se seteara el Modelo.
        /// </summary>
        public string Modelo 
        { 
            get 
            { 
                return this.modelo; 
            }
            set
            {
                this.modelo = value;
            }
        }
        /// <summary>
        /// Propiedad publica: Retornará el una lista de string con las fallas y se seteara las fallas en una lista de string.
        /// </summary>
        public List<string> ListaFallas
        { 
            get 
            { 
                return this.listaFallas; 
            }
            set
            {
                this.listaFallas = value;
            }
        }
        /// <summary>
        /// Override de ToString que vamos a utilizar para mostrar todos los datos que comparten los productos.
        /// </summary>
        /// <returns>Un string con los datos del Producto</returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine($"\t\nMarca: {Marca}\t\nModelo: {Modelo}\t");
            datos.AppendLine(MostrarFallas());
            return datos.ToString();
        }
        /// <summary>
        /// Muestra todas las fallas del producto.
        /// </summary>
        /// <returns>Retorna un string con todas las fallas</returns>
        public string MostrarFallas()
        {
            StringBuilder datosFallas = new StringBuilder();
            datosFallas.AppendLine("Fallas: ");
            foreach (var item in listaFallas)
            {
                datosFallas.AppendLine($"{item} ");
            }
            return datosFallas.ToString();
        }
        /// <summary>
        /// Metodo abstracto donde voy a utilizar en las clases derivadas en el cual voy a calcular el costo del servicio.
        /// </summary>
        /// <returns>Retorna el costo(float)</returns>
        public abstract float CalcularCosto();
    }
}
