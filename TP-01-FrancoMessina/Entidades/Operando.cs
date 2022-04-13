using System;
using System.Text;
namespace Entidades
{
    public class Operando
    {

        private double numero;

        /// <summary>
        /// Constructor que le asigna el valor pasado por parametro a numero.
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor vacio que asigna en numero el valor 0
        /// </summary>
        public Operando() : this(0)
        {

        }
        /// <summary>
        /// Constructor con parametro en string que usa la propiedad Numero para guardar
        /// un string en numero, es decir, lo convierte a double en la propiedad(Validando el operador).
        /// Asigna el numero si lo pudo transformar a double, caso contrario 0.
        /// </summary>
        /// <param name="strNumero">Numero en string</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        /// <summary>
        /// Propiedad donde se le asigna a numero el valor validado.
        /// </summary>
        public string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }
        /// <summary>
        /// Valida si el string pasado por parametro es un numero, si es un numero retorna el numero.
        /// Caso contrario retorna 0
        /// </summary>
        /// <param name="strNumero">String a validar</param>
        /// <returns>Retorna el numero validado o retorna 0</returns>
        private double ValidarOperando(string strNumero)
        {
            double numero;//Number
            bool esNumero; //Is Number

            esNumero = Double.TryParse(strNumero, out numero);
            if (esNumero)
                return numero;
            return 0;
        }
        /// <summary>
        /// Valiad que el numero sea un binario.
        /// </summary>
        /// <param name="binario">String a validar</param>
        /// <returns>False si no es binario, true si es binario.</returns>
        private bool EsBinario(string binario)
        {
            foreach (char valor in binario)
            {
                if (valor != '0' && valor != '1')
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Convierte el string binario a decimal.
        /// </summary>
        /// <param name="binario">String en binario</param>
        /// <returns>Si el string no es un binario retorna "Valor Invalido"
        /// Si es un binario retorna el valor convertido a decimal.
        /// </returns>
        public string BinarioDecimal(string binario)
        {
            double resultado = 0;
            char[] binarioInvertido = binario.ToCharArray();
            Array.Reverse(binarioInvertido);
            int largoBinario = binario.Length;
            int multiplicador = 1;
            string errorMensaje = "Valor inválido";
            if (EsBinario(binario))
            {
                for (int i = 0; i < largoBinario; i++)
                {
                    if (binarioInvertido[i] == '1')
                    {
                        int aux = (int.Parse(binarioInvertido[i].ToString())) * multiplicador;
                        resultado += aux;
                    }
                    multiplicador *= 2;
                }
                return resultado.ToString();
            }
            return errorMensaje;
        }
        /// <summary>
        /// Convierte el numero decimal a binario.
        /// </summary>
        /// <param name="numero">Numero decimal a convertir a binario</param>
        /// <returns>Retorna "Valor Invalido" o el decimal convertido a binario.</returns>
        public string DecimalBinario(double numero)
        {
            StringBuilder sbBinario = new StringBuilder();
            string binarioFinal;
            int numeroEntero = (int)Math.Abs(numero);
            char[] binarioInvertido;//En este char de array voy a invertir el binario
            string errorMensaje = "Valor inválido";
            if (numero == 0)
                return "0";
            else if (numero > 0)
            {
                do
                {
                    if (numeroEntero % 2 == 0)
                        sbBinario.Append($"0");
                    else
                        sbBinario.Append("1");
                    numeroEntero /= 2;

                } while (numeroEntero > 0);
                binarioInvertido = sbBinario.ToString().ToCharArray();//Paso el string builder a string y despues a  un array de char
                Array.Reverse(binarioInvertido);//Aca lo invierto asi me queda el binario Final
                binarioFinal = new string(binarioInvertido);//Por legibilidad creo una variable llamada binarioFinal
                return binarioFinal;
            }
            return errorMensaje;
        }
        /// <summary>
        /// Convierte decimal a binario recibiendo por parametro un numero en string.
        /// Se hace un tryParse verificando si es un numero. 
        /// </summary>
        /// <param name="numero">Numero en formato string</param>
        /// <returns>Si es un numero lo convierte a binario
        /// Caso contrario retorna "Valo inválido"
        /// </returns>
        public string DecimalBinario(string numero)
        {
            string errorMensaje = "Valor inválido";
            if (Double.TryParse(numero, out double numeroRetorno))
                return DecimalBinario(numeroRetorno);

            return errorMensaje;
        }
        /// <summary>
        /// Sobrecarga de operador + se  suma los atributos numero.
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Segundo Operando</param>
        /// <returns>Retorna  la suma de los atributos.(n1.numero,n2.numero)</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Sobrecarga de operador - se  suma los atributos numero.
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Segundo Operando</param>
        /// <returns>Retorna la resta de los atributos.(n1.numero,n2.numero)</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Sobrecarga de operador * se  suma los atributos numero.
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Segundo Operando</param>
        /// <returns>Retorna la multiplicacion los atributos (n1.numero,n2.numero).</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Sobrecarga de operador / se  suma los atributos numero.
        /// </summary>
        /// <param name="n1">Primer Operando</param>
        /// <param name="n2">Segundo Operando</param>
        /// <returns>Retorna la division los atributos (n1.numero,n2.numero).
        /// Si el segundo operador tiene como estado el valor 0 se retorna el double.MinValue</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
                return Double.MinValue;
            return n1.numero / n2.numero;
        }
    }
}
