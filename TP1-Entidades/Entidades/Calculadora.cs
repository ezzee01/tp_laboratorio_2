﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza la operación correspondiente
        /// </summary>
        /// <param name="numero1">Primer numero</param>
        /// <param name="numero2">Segundo numero</param>
        /// <param name="operador">Operación</param>
        /// <returns></returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;
            char operadorChar;

            if (char.TryParse(operador, out operadorChar))
            {
                switch (ValidarOperador(operadorChar))
                {
                    case "+":
                        resultado = numero1 + numero2;

                        break;
                    case "-":
                        resultado = numero1 - numero2;
                        break;
                    case "*":
                        resultado = numero1 * numero2;
                        break;
                    case "/":
                        resultado = numero1 / numero2;
                        break;
                }
            }

            return resultado;
        }


        /// <summary>
        /// Valida el operador y devuelve "+" si no es un operador correcto
        /// </summary>
        /// <param name="operador">Operación a validar</param>
        /// <returns>Retorna un operador valido</returns>
        private static string ValidarOperador(char operador)
        {
            if (operador.Equals('+') || operador.Equals('-') || operador.Equals('*') || operador.Equals('/'))
            {
                return operador.ToString();
            }
            else return "+";
        }
    }
}
