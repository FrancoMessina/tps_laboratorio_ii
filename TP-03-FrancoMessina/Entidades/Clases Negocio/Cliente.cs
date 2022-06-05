using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        private string dni;
        private string nombre;
        private string apellido;
        private string numeroTel;
        private bool dadoDeAlta;
        private List<Servicio> listaServicios;
        public Cliente()
        {
            listaServicios = new List<Servicio>();
        }
        public Cliente(string dni, string nombre, string apellido, string numeroTel):this()
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.numeroTel = numeroTel;
            this.DadoDeAlta = true;
        }

        /// <summary>
        /// Propiedad publica: Retornará el dni y se seteara el dni.
        /// </summary>
        public string Dni { get { return this.dni; } set { this.dni = value; } }
        /// <summary>
        /// Propiedad publica: Retornará el nombre y se seteara el nombre.
        /// </summary>
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        /// <summary>
        /// Propiedad publica: Retornará el apellido y se seteara el apellido.
        /// </summary>
        public string Apellido { get { return this.apellido; } set { this.apellido = value; } }
        /// <summary>
        /// Propiedad publica: Retornará el numero de Tel y se seteara el numero de Tel.
        /// </summary>
        public string NumeroTel { get { return this.numeroTel; } set { this.numeroTel = value; } }
        /// <summary>
        /// Propiedad publica: Retornará la lista de servicios del cliente y se seteara la lista de servicios del cliente.
        /// </summary>
        public List<Servicio> ListaServicios { get { return listaServicios; } set { this.listaServicios = value; } }
        /// <summary>
        /// Propiedad publica: Retornará el estado del cliente y se seteara el estado del cliente (true=activo,false=inactivo).
        /// </summary>
        public bool DadoDeAlta { get { return this.dadoDeAlta; } set { this.dadoDeAlta = value; } }

        /// <summary>
        /// Sobrecarga de == que compara dos clientes por DNI.
        /// </summary>
        /// <param name="a">Primer cliente</param>
        /// <param name="b">Segundo cliente</param>
        /// <returns>Si retorna true es el mismo cliente, si retorna false son distintos</returns>
        public static bool operator ==(Cliente a, Cliente b)
        {
            if(a is not null && b is not null)
            {
                return a.dni == b.dni;
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga de != que compara dos clientes por DNI.
        /// </summary>
        /// <param name="a">Primer cliente</param>
        /// <param name="b">Segundo cliente</param>
        /// <returns>Retorna un booleano dependiendo el caso</returns>
        public static bool operator !=(Cliente a, Cliente b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Verifica si el cliente es duplicado, es decir, si hay otro cliente con ese mismo DNI(que no sea el mismo) retornara true.
        /// Por ejemplo: Tenemos una Lista con dos clientes. Primer cliente (DNI: 41195823). Segundo cliente (DNI: 41195823)
        /// Retornara true. 
        /// Primer cliente (DNI: 41195823). Segundo cliente (DNI: 41195890) retornara false. (Metodo importante para poder modificar un cliente)
        /// </summary>
        /// <param name="lista">Lista de clientes</param>
        /// <param name="a">Cliente a analizar</param>
        /// <param name="index">Index del cliente</param>
        /// <returns>Retorna un booleano dependiendo el caso</returns>
        public static bool VerificarClienteDuplicado(List<Cliente> lista, Cliente a, int index)
        {
            if(lista is not null && a is not null)
            {
                for(int i = 0; i < lista.Count; i++)
                {
                    if (lista[i] == a && i != index)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// En formato string muestra los datos del cliente.
        /// </summary>
        /// <returns>Retornara un string con la información del cliente</returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine($"Nombre: {this.Nombre}\tApellido: {this.Apellido}\t NumTel: {this.NumeroTel}\t Dni: {this.Dni}");
            return datos.ToString();
        } 
    }
}
