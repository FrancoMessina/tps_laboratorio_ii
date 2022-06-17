using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Excepciones;
namespace Entidades.ValidacionesCliente
{
    public static class ValidarCliente
    {
        /// <summary>
        /// Valida todos los campos del cliente verificando si son null o vacios.
        /// </summary>
        /// <param name="nombre">Nombre del cliente</param>
        /// <param name="apellido">Apellido del cliente</param>
        /// <param name="dni">Dni del cliente</param>
        /// <param name="numeroTel">Numero del cliente</param>
        /// <returns>Retorna true si todos los datos estan correctos</returns>
        /// <exception cref="CamposVaciosONullException">Lanza la excepcion si algun cliente es null.</exception>
        public static bool ValidarCamposCliente(string nombre, string apellido, string dni, string numeroTel)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(dni)
                || string.IsNullOrWhiteSpace(numeroTel))
            {
                throw new CamposVaciosONullException("Cargar todos los datos del cliente!");
            }
            return true;

        }
        /// <summary>
        /// Valida nombre.
        /// </summary>
        /// <param name="nombre">Nombre del cliente</param>
        /// <returns>Retorna true si el nombre no contiene ningun error.</returns>
        /// <exception cref="NombreInvalidoException">Lanza la excepcion si el nombre tiene menos de 3 letras o más de 20
        /// o si el nombre contiene numeros</exception>
        public static bool ValidarNombre(string nombre)
        {
            if (nombre.Length > 20 || nombre.Length < 3)
            {
                throw new NombreInvalidoException("El nombre tiene que tener más de 3 letras y menos de 20");
            }
            else if (!nombre.VerificarContieneSoloLetras())
            {
                throw new NombreInvalidoException("El nombre tiene que contener solo letras.");
            }
            return true;
        }
        /// <summary>
        /// Valida Apellido.
        /// </summary>
        /// <param name="apellido">Apellido del cliente</param>
        /// <returns>Retorna true si el nombre no contiene ningun error.</returns>
        /// <exception cref="ApellidoInvalidoException">Lanza la excepcion si el apellido tiene menos de 3 letras o más de 20
        /// o si el apellido contiene numeros</exception>
        public static bool ValidarApellido(string apellido)
        {
            if (apellido.Length > 20 || apellido.Length < 3)
            {
                throw new ApellidoInvalidoException("El apellido tiene que tener más de 3 letras y menos de 20");
            }
            else if (!apellido.VerificarContieneSoloLetras())
            {
                throw new ApellidoInvalidoException("El apellido tiene que contener solo letras.");
            }
            return true;
        }
        /// <summary>
        /// Valida el DNI.
        /// </summary>
        /// <param name="dni">DNI del cliente</param>
        /// <returns>Retorna true si el nombre no contiene ningun error.</returns>
        /// <exception cref="DniInvalidoException">Lanza la excepcion si el dni contiene letras,si el numero es <= 0 o mayor a 999999999.</exception>
        public static bool ValidarDni(string dni)
        {
            if (!double.TryParse(dni, out double dniAux))
            {
                throw new DniInvalidoException("El Dni tiene que ser númerico!");
            }
            else if (dniAux <= 0 || dniAux > 999999999)
            {
                throw new DniInvalidoException("DNI INVALIDO!");
            }
            return true;
        }
        /// <summary>
        /// Valida el numero de Telefono.
        /// </summary>
        /// <param name="numeroTel">Numero de telefono del cliente.</param>
        /// <returns>Retornará true si no lanza ninguna excepcion.</returns>
        /// <exception cref="NumeroInvalidoExcepction">Lanza excepcion cuando el numero contiene letras o no son 10 numeros. </exception>
        public static bool ValidarNumeroTel(string numeroTel)
        {
            if (!double.TryParse(numeroTel, out double auxNumeroTel))
            {
                throw new NumeroInvalidoExcepction("El Número de telefono tiene que ser númerico!");
            }
            else if (numeroTel.Length != 10)
            {
                throw new NumeroInvalidoExcepction("Los numeros telefonicos tienen 10 digitos!");
            }
            return true;
        }
        /// <summary>
        /// Verifica que el string solo contenga letras o espacios. Esto ultimo mencionado 
        /// es para que el apellido pueda ser Del Potro
        /// </summary>
        /// <param name="dato">dato a analizar</param>
        /// <returns>Si contiene solo letras retornará true, caso contrario false.</returns>
        public static bool VerificarContieneSoloLetras(this String dato)
        {
            foreach (char letra in dato)
            {
                if (!Char.IsLetter(letra) && letra.ToString() != " ")
                    return false;
            }
            return true;
        }
    }
}
