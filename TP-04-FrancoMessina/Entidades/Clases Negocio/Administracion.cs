using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Administracion
    {
        private List<Cliente> listaClientes;

        public List<Cliente> ListaClientes { get { return listaClientes; } set { listaClientes = value; } } 
        public Administracion():this(new List<Cliente>())
        {
        }
        public Administracion(List<Cliente> listaClientes)
        {
            this.listaClientes = listaClientes;
        }
        /// <summary>
        /// La sobrecarga del operador Administracion == clientes verifica si el cliente esta en la lista de cliente.
        /// </summary>
        /// <param name="clientes">Administración donde se accede a la lista de clientes</param>
        /// <param name="c">Cliente</param>
        /// <returns>Retorna true si el cliente esta en la lista de clientes y false cuando no se encuentre en la lista</returns>
        public static bool operator == (Administracion clientes, Cliente c)
        {
            if(clientes.ListaClientes is not null && c is not null)
            {
                foreach(Cliente cliente in clientes.ListaClientes)
                {
                    if(cliente == c)
                    {
                        return true;
                    }
                    
                }
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga de != que compara si un cliente se encuentra en la lista
        /// </summary>
        /// <param name="clientes"></param>
        /// <param name="c"></param>
        /// <returns>Retornara true si el cliente no se encuentra en la lista y false si se encuentra</returns>
        public static bool operator !=(Administracion clientes, Cliente c)
        {
            return !(clientes == c);
        }
        /// <summary>
        /// Se agregara el cliente a la lista de administracion.ListaClientes si el cliente no se encuentra en la lista.
        /// </summary>
        /// <param name="clientes">Administracion donde se encuentra la lista de clientes</param>
        /// <param name="c">Cliente a agregar</param>
        /// <returns>Retorna un string con un mensaje dependiendo el caso</returns>
        public static string operator +(Administracion clientes, Cliente c)
        {
            string mensaje = "Error!";
            if (clientes is not null && c is not null)
            {
                if (clientes != c)
                {
                    clientes.ListaClientes.Add(c);
                    mensaje = "Agregado exitosamente!";
                    return mensaje;
                }
                mensaje = "El cliente ya existe!";
                return mensaje;
            }
            return mensaje;
        }
        /// <summary>
        /// Se eliminara logicamente(Propiedad DadoDeAlta = false) el cliente de la lista de administracion.ListaClientes, si el cliente  se encuentra en la lista.
        /// </summary>
        /// <param name="clientes">Administracion donde se encuentra la lista de clientes</param>
        /// <param name="c">Cliente a eliminar</param>
        /// <returns>Retornara un string dependiendo el caso</returns>
        public static string operator -(Administracion clientes, Cliente c)
        {
            string mensaje = "ERROR";
            if (c is not null && c is not null)
            {
                if (clientes != c)
                    mensaje = "Cliente no encontrado.";
                else
                {
                    mensaje = "Cliente removido";
                    c.DadoDeAlta = false;
                }
            }
            return mensaje;
        }
        /// <summary>
        /// Basicamente consiste en recuperar el cliente que se dio de baja logicamente.Cambiando 
        /// el valor de la propiedad DadoDeAlta a true
        /// </summary>
        /// <param name="clientes">Administracion donde se encuentra la lista de clientes</param>
        /// <param name="c">Cliente</param>
        /// <returns>Retorna un string dependiendo el caso.</returns>
        public static string RehabilitarCliente(Administracion clientes, Cliente c)
        {
            string mensaje = "ERROR";
            if (c is not null && c is not null)
            {
                if (clientes != c)
                    mensaje = "Cliente no encontrado.";
                else
                {
                    mensaje = "Cliente dado de alta nuevamente";
                    c.DadoDeAlta = true;
                }
            }
            return mensaje;
        }
        /// <summary>
        /// Modifica un cliente en la lista y si cambia el DNI se verifica que otro cliente no contenga ese DNI.
        /// </summary>
        /// <param name="clientes">Administracion donde se encuentra la lista de clientes</param>
        /// <param name="clienteAModificar">Cliente a modificar sus datos</param>
        /// <param name="clienteModificado">Cliente con los datos nuevos cargados</param>
        /// <returns>Retorna un string con un mensaje dependiendo el caso</returns>
        public static string ModificarCliente (Administracion clientes, Cliente clienteAModificar, Cliente clienteModificado)
        {
            string mensaje = "No existe el cliente";
            if (clientes is not null && clienteAModificar is not null && clienteModificado is not null)
            {
                int index = clientes.listaClientes.IndexOf(clienteAModificar);
                if (!Cliente.VerificarClienteDuplicado(clientes.ListaClientes, clienteModificado,index))
                {
                    clienteAModificar.Nombre = clienteModificado.Nombre;
                    clienteAModificar.Apellido = clienteModificado.Apellido;
                    clienteAModificar.Dni = clienteModificado.Dni;
                    clienteAModificar.NumeroTel = clienteModificado.NumeroTel;
                    mensaje = "Cliente modificado con exito";
                }
                else
                    mensaje = "Ese DNI ya existe!";
            }
            else if(clienteAModificar is null)
            {
                mensaje = "No seleccionaste ningun cliente para modificar!";
            }
            return mensaje;
        }

        /// <summary>
        /// Agrega un servicio en el cliente.
        /// </summary>
        /// <param name="clientes">Administracion donde se encuentra la lista de clientes</param>
        /// <param name="cliente">Cliente al cual se le agrega el servicio</param>
        /// <param name="servicio">Servicio</param>
        /// <returns>Retorna un string con un mensaje dependiendo el caso</returns>
        public static string AgregarServicio(Administracion clientes, Cliente cliente, Servicio servicio)
        {
            string mensaje = "Error";
            if (clientes is not null && cliente is not null && servicio is not null)
            {
                if (clientes == cliente)
                {
                    int index = clientes.listaClientes.IndexOf(cliente);
                    clientes.listaClientes[index].ListaServicios.Add(servicio);
                    mensaje = "Servicio agregado correctamente!";
                    return mensaje;
                }
                mensaje = "No existe el cliente";
                return mensaje;
            }
            return mensaje;
        }
        /// <summary>
        /// Lista/filtra los clientes que tienen la propiedad DadaDeAlta en true
        /// </summary>
        /// <returns>Retorna la lista filtrada</returns>
        public List<Cliente> ListaClienteAlta()
        {
            List<Cliente> clientesDeAlta = new List<Cliente>();
            foreach (Cliente item in listaClientes)
            {
                if (item.DadoDeAlta)
                    clientesDeAlta.Add(item);
            }
            return clientesDeAlta;
        }
        /// <summary>
        /// Lista/filtra los clientes que tienen la propiedad DadaDeAlta en false
        /// </summary>
        /// <returns>Retorna la lista filtrada</returns>
        public List<Cliente> ListaClienteBaja()
        {
            List<Cliente> clientesDeAlta = new List<Cliente>();
            foreach (Cliente item in listaClientes)
            {
                if (!item.DadoDeAlta)
                    clientesDeAlta.Add(item);
            }
            return clientesDeAlta;
        }
        /// <summary>
        /// Muestra info de todos los clientes con sus datos
        /// </summary>
        /// <returns>Retorna un string con todos los datos</returns>
        private string MostrarInfoClientes()
        {
            StringBuilder datos = new StringBuilder();
            foreach (Cliente cliente in listaClientes)
            {
                cliente.ToString();
            }
            return datos.ToString();
        }
        /// <summary>
        /// Override de to string donde reutilizamos el codigo de MostrarInfoClientes para mostrar todos los datos.
        /// </summary>
        /// <returns>Retorna la información de todos los clientes.</returns>
        public override string ToString()
        {
            return MostrarInfoClientes();        
        }
    }
}
