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
        public static bool operator !=(Administracion clientes, Cliente c)
        {
            return !(clientes == c);
        }
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
                    clientes.listaClientes.Remove(c);
                }
            }
            return mensaje;
        }
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
        public static string EliminarServicio(Administracion clientes, Cliente cliente, Servicio servicio)
        {
            string mensaje = "Error";
            if (clientes is not null && cliente is not null && servicio is not null)
            {
                if (clientes == cliente)
                {
                    int indexCliente = clientes.listaClientes.IndexOf(cliente);
                    clientes.ListaClientes[indexCliente].ListaServicios.Remove(servicio);
                    mensaje = "Servicio Eliminado con Exito";
                    return mensaje;
                }
                mensaje = "Servicio no encontrado";
                return mensaje;
            }
            return mensaje;
        }
        private string MostrarInfoClientes()
        {
            StringBuilder datos = new StringBuilder();
            foreach (Cliente cliente in listaClientes)
            {
                cliente.ToString();
            }
            return datos.ToString();
        }
        public override string ToString()
        {
            return MostrarInfoClientes();        
        }
    }
}
