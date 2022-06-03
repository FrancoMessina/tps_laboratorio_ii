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

        public static bool ValidarCamposCliente(string nombre, string apellido, string dni, string numeroTel)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(numeroTel))
            {
                throw new CamposVaciosONullException("Cargar todos los datos del cliente!");
            }
            return true;

        }
        public static bool ValidarNombre(string nombre)
        {
            if (nombre.Length > 20 || nombre.Length < 3)
            {
                throw new NombreInvalidoException("El nombre tiene que tener más de 3 letras y menos de 20");
            }
            else if (!VerificarContieneSoloLetras(nombre))
            {
                throw new NombreInvalidoException("El nombre tiene que contener solo letras.");
            }
            return true;
        }
        public static bool ValidarApellido(string apellido)
        {
            if (apellido.Length > 20 || apellido.Length < 3)
            {
                throw new ApellidoInvalidoException("El apellido tiene que tener más de 3 letras y menos de 20");
            }
            else if (!VerificarContieneSoloLetras(apellido))
            {
                throw new ApellidoInvalidoException("El apellido tiene que contener solo letras.");
            }
            return true;
        }
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
        private static bool VerificarContieneSoloLetras(string nombre)
        {
            foreach (char letra in nombre)
            {
                if (!Char.IsLetter(letra))
                    return false;
            }
            return true;
        }
    }
}
