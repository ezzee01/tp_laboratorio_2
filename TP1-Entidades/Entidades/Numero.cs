using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Setea el numero validado
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Constructores
        /// </summary>
        public Numero() : this(0)
        { }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }


        /// <summary>
        /// Convierte numero binario A decimal
        /// </summary>
        /// <param name="binario">Numero a convertir</param>
        /// <returns>retorna numero binario en string</returns>
        public string BinarioDecimal(string binario)
        {
            int numeroDecimal = 0;
            string resultado = "Valor inválido";

            if (EsBinario(binario))
            {
                resultado = "";
                for (int i = 1; i <= binario.Length; i++)
                {
                    if (binario.ElementAt(i - 1) == '1')
                    {
                        numeroDecimal += (int)Math.Pow(2, binario.Length - i);
                    }
                }
                resultado = numeroDecimal.ToString();
                return resultado;
            }
            else return resultado;
        }


        /// <summary>
        /// Convierte un double a binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Retorna numero binario en string</returns>
        public string DecimalBinario(double numero)
        {
            string binario = "";
            int numeroEntero = Math.Abs((int)numero);
        
            while (numeroEntero > 0)
            {
                binario = (numeroEntero % 2).ToString() + binario;
                numeroEntero = numeroEntero / 2;
            }

            return binario;
        }


        /// <summary>
        /// Convierte un numero en string a binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>Retorna numero binario en string</returns>
        public string DecimalBinario(string numero)
        {
            string resultado = "Valor inválido";
            double numeroDouble;

            if (double.TryParse(numero, out numeroDouble))
            {
                resultado = DecimalBinario(numeroDouble);
                return resultado;
            }
            else return resultado;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            bool esBinario = false;

            foreach (var num in binario)
            {
                if (num == '1' || num == '0')
                {
                    esBinario = true;
                }
            }
            return esBinario;
        }


        /// <summary>
        /// Resta dos objetos Numero
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>Retorna el resultado en double</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }


        /// <summary>
        /// Suma dos objetos Numero
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>Retorna el resultado en double</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }


        /// <summary>
        /// Multiplica dos objetos Numero
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>Retorna el resultado en double</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }


        /// <summary>
        /// Divide dos objetos Numero solo si numero2 no es cero, de lo contrario retorna el valor minimo double
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero</param>
        /// <returns>Retorna el resultado en double</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;
            }
            else return double.MinValue;
        }


        /// <summary>
        /// Valida que el numero en string sea correcto, de lo contrario retorna 0
        /// </summary>
        /// <param name="strNumero">Numero a validar</param>
        /// <returns>Retorna el numero en double</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero = 0;
            bool esNumero = false;

            foreach (var item in strNumero)
            {
                if (item > 47 && item < 58 || double.TryParse(strNumero, out numero))
                {
                    esNumero = true;
                }
            }

            if (esNumero)
            {
                numero = double.Parse(strNumero);
            }

            return numero;
        }
    }
}
