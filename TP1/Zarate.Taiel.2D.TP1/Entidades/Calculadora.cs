using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Calculadora
    {
        private static char ValidarOperador(char operador)
        {
            char retornoAux;

            switch (operador)
            {
                case '-':
                    retornoAux = operador;
                    break;
                case '*':
                    retornoAux = operador;
                    break;
                case '/':
                    retornoAux = operador;
                    break;
                default:
                    retornoAux = '+';
                    break;
            }

            return retornoAux;
        }

        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado;
            char operdorAux = ValidarOperador(operador);
            switch (operdorAux)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                default:
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }
    }
}
