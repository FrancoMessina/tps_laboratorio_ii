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
        }

        public string Dni { get { return this.dni; } set { this.dni = value; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Apellido { get { return this.apellido; } set { this.apellido = value; } }
        public string NumeroTel { get { return this.numeroTel; } set { this.numeroTel = value; } }

        public List<Servicio> ListaServicios { get { return listaServicios; } set { this.listaServicios = value; } }

        public static bool operator ==(Cliente a, Cliente b)
        {
            if(a is not null && b is not null)
            {
                return a.dni == b.dni;
            }
            return false;
        }
        public static bool operator !=(Cliente a, Cliente b)
        {
            return !(a == b);
        }
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine($"Nombre: {this.Nombre}\tApellido: {this.Apellido}\t NumTel: {this.NumeroTel}\t Dni: {this.Dni}");
            return datos.ToString();
        } 
    }
}
