using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida que el operador pasado por parametro sea (* / -), caso contrario  retorna +.
        /// </summary>
        /// <param name="operador">Operador que valido a traves de un switch</param>
        /// <returns>Retorna + si el usuario ingresa cualquier operador al menos que sea * / - </returns>
        private static char ValidarOperador(char operador)
        {
            char retornoOperador;
            switch (operador)
            {
                case '*':
                    retornoOperador = '*';
                    break;
                case '/':
                    retornoOperador = '/';
                    break;
                case '-':
                    retornoOperador = '-';
                    break;
                default:
                    retornoOperador = '+';
                    break;
            }
            return retornoOperador;
        }
        /// <summary>
        /// Opera con dos objetos Operando, y hace la operacion que se le envia por operador. Reutilizo la funcion validarOperador
        /// </summary>
        /// <param name="num1">Primer Operando</param>
        /// <param name="num2">Segundo Operando</param>
        /// <param name="operador">Operador que indica el tipo de operacion.</param>
        /// <returns>Retorna el valor de la operacion realizada.</returns>
        public double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            switch (ValidarOperador(operador))
            {
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '+':
                    resultado = num1 + num2;
                    break;
            }
            return resultado;
        }
    }

}
