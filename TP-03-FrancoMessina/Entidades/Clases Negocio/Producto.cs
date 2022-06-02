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

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine($"\tMarca: {Marca}\tModelo: {Modelo}\t");
            datos.AppendLine(MostrarFallas());
            return datos.ToString();
        }
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
        public abstract float CalcularCosto();
    }
}
