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
        private string dniCliente;
        public Servicio()
        {

        }
        public Servicio(ETipoEntrega tipoEntrega, Producto producto, float precio)
        {
            this.tipoEntrega = tipoEntrega;
            this.producto = producto;
            this.precio = precio;
        }
        public Servicio(ETipoEntrega tipoEntrega, Producto producto, float precio, string dniCliente):this(tipoEntrega,producto,precio)
        {
            this.dniCliente = dniCliente;
        }
        /// <summary>
        /// Propiedad publica: Retornará el precio del servicio y se seteara precio del servicio.
        /// </summary>
        public float Precio { get {  return this.precio; } set {  this.precio = value; } }
        /// <summary>
        /// Propiedad publica: Retornará el tipo de entrega y se seteara el tipo de entrega.
        /// </summary>
        public ETipoEntrega TipoEntrega { get { return this.tipoEntrega; }  set { tipoEntrega = value; } }
        /// <summary>
        /// Propiedad publica: Retornará el producto y se seteara el producto al que se le efectuará un servicio.
        /// </summary>
        public Producto Producto { get { return this.producto; } set { producto = value; } }

        public string DniCliente { get { return dniCliente; } set { dniCliente = value; } }

        /// <summary>
        /// Override de ToString que vamos a utilizar para mostrar el Tipo de Producto, Precio, Tipo de Entrega
        /// y los datos de la clase base.
        /// </summary>
        /// <returns>Un string con los datos del Servicio</returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine($"Producto: {producto.GetType().Name}\t{producto.ToString()}Precio: ${this.precio}\tTipo Entrega: {this.tipoEntrega}");
            return datos.ToString();
        }
        /// <summary>
        /// Metodo estatico donde se le pasa por parametro un Cliente y Servicio. En la cual se emite un ticket
        /// con todos los datos del cliente y del servicio.
        /// </summary>
        /// <param name="cliente">Clienteo</param>
        /// <param name="servicio">Servicio</param>
        /// <returns>Un string con todos los datos del ticket</returns>
        public static string GenerarTicket(Cliente cliente, Servicio servicio)
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("*******************************************************************************************************************************");
            datos.AppendLine($"Nombre y Apellido: {cliente.Nombre} {cliente.Apellido}");
            datos.AppendLine($"Dni: {cliente.Dni}");
            datos.AppendLine($"NumeroTel: {cliente.NumeroTel}");
            datos.Append($"{servicio.ToString()}");
            datos.Append("***********************************************************************************************************************************");
            return datos.ToString();       
        }
        
    }
}
