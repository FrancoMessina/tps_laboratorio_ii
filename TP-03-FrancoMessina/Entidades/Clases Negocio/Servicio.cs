using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Televisor)), XmlInclude(typeof(Control)), XmlInclude(typeof(AireAcondicionado))]
    public class Servicio
    {
        private float precio; 
        private ETipoEntrega tipoEntrega;
        private Producto producto;

        public Servicio()
        {

        }
        public Servicio(ETipoEntrega tipoEntrega, Producto producto, float precio)
        {
            this.tipoEntrega = tipoEntrega;
            this.producto = producto;
            this.precio = precio;
        }

        public float Precio 
        { 
            get 
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }
        public ETipoEntrega TipoEntrega { get { return this.tipoEntrega; }  set { tipoEntrega = value; } }
        public Producto Producto { get { return this.producto; } set { producto = value; } }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine($"Producto: {producto.GetType().Name}\t{producto.ToString()}Precio: ${this.precio}\tTipo Entrega: {this.tipoEntrega}");
            return datos.ToString();
        }
        public static string GenerarFactura(Servicio servicio)
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("*******************************************************************************************************************************");
            datos.Append($"{servicio.ToString()}");
            datos.Append("***********************************************************************************************************************************");
            return datos.ToString();       
        }
        
    }
}
