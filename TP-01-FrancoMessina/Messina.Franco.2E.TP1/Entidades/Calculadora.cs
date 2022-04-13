using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
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
