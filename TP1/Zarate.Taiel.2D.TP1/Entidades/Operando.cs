using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        public Operando() : this(0)
        {
        }

        public Operando(double numero)
        {
        }

        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        /// <summary>
        /// Valida que el número ingresado sea un número
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>El número ingresado en formato double o 0 si no es un número lo ingresado</returns>
        private double ValidarOperando(string strNumero)
        {
            double retornoAux;
            bool verificar = double.TryParse(strNumero, out retornoAux);

            if (!verificar)
            {
                retornoAux = 0;
            }

            return retornoAux;
        }

        /// <summary>
        /// Valida que el número en lblResultado sea un número binario
        /// </summary>
        /// <param name="binario">Texto del lblResultado</param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            bool retornoAux = true;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    retornoAux = false;
                    break;
                }
            }

            return retornoAux;
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
            double resultado;
            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            else
            {
                resultado = double.MinValue;
            }
            return resultado;
        }

        /// <summary>
        /// Convierte el string recibido como parametro a decimal, primero verificando si es número binario 
        /// </summary>
        /// <param name="binario">Número binario en formato string</param>
        /// <returns>El número binario convertido a decimal o "Valor invalido" si ocurrío un error</returns>
        public string BinarioDecimal(string binario)
        {
            string resultado = "Valor invalido";
            int numero = 0;
            int reminder = 1;

            if (EsBinario(binario))
            {
                resultado = "";
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    if (binario[i] == '1')
                    {
                        numero = numero + reminder;
                    }
                    reminder = reminder * 2;
                }
                resultado = numero.ToString() + resultado;
            }

            return resultado;
        }

        /// <summary>
        /// Convierte un número decimal a binario
        /// </summary>
        /// <param name="numero">Número decimal</param>
        /// <returns>Número convertido a binario o "Valor invalido" si hubo un error</returns>
        public string DecimalBinario(double numero)
        {
            int remainder;
            string resultado = "Valor invalido";
            int entero;
            entero = (int)numero;
            if (numero >= 0)
            {
                if (numero == 0)
                {
                    resultado = "0";
                }
                else
                {
                    resultado = "";
                    while (entero > 0)
                    {
                        remainder = entero % 2;
                        entero /= 2;
                        resultado = remainder.ToString() + resultado;
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Convierte un número decimal a binario
        /// </summary>
        /// <param name="numero">Número decimal</param>
        /// <returns>Número convertido a binario o "Valor invalido" si hubo un error</returns>
        public string DecimalBinario(string numero)
        {
            string resultado;
            double numeroAux;
            Operando num = new Operando(numero);
            numeroAux = num.numero;

            resultado = DecimalBinario(numeroAux);

            return resultado;
        }
    }
}
