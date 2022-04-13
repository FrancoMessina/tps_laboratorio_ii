using System;
using System.Text;
namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando(double numero)
        {
            this.numero = numero;
        }
        public Operando() : this(0)
        {

        }
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        public string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }
        private double ValidarOperando(string strNumero)
        {
            double numero;//Number
            bool esNumero; //Is Number

            esNumero = Double.TryParse(strNumero, out numero);
            if (esNumero)
                return numero;
            return 0;
        }

        private bool EsBinario(string binario)
        {
            foreach (char valor in binario)
            {
                if (valor != '0' && valor != '1')
                    return false;
            }
            return true;
        }

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
        public string DecimalBinario(string numero)
        {
            string errorMensaje = "Valor inválido";
            if (Double.TryParse(numero, out double numeroRetorno))
                return DecimalBinario(numeroRetorno);

            return errorMensaje;
        }
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
                return Double.MinValue;
            return n1.numero / n2.numero;
        }
    }
}
