using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excecao_Personalizada
{
    class Program
    {

        public static List<int> numList = new List<int> { 10, 35, 48, 94 };

        public static void CheckNegativeNum(int num)
        {
            if (num < 0) throw new NumeroNegativoException(num);
        }

        static void Main(string[] args)
        {

            int numDigitados = 0;

            while(true)
            {
                try
                {
                    Console.WriteLine("Adicione um número à lista para calcular a média atualizada da mesma ou digite 0 para sair: ");
                    numDigitados = Convert.ToInt32(Console.ReadLine());

                    if (numDigitados != 0) CheckNegativeNum(numDigitados);
                    else break;

                    Console.WriteLine("\nO número digitado é positivo.\n");
                    numList.Add(numDigitados);
                }
                catch (NumeroNegativoException e)
                {
                    #region Observações sobre tratamento personalizado de exceções e hierarquia
                    /* BLOCO DE TRATAMENTO DE EXCEÇÃO ESPECÍFICO/PERSONALIZADO:
                     * 
                     * O bloco de exceção específica/pErsonalizada sempre tem prioridade,
                     * por isso, deve ser colocado acima/antes dos blocos de tratamento
                     * genérico.
                     * 
                     * Caso não houvesse este bloco, a exceção personalizada seria capturada
                     * pelo bloco genérico abaixo e produziria praticamente o mesmo resultado.
                    */
                    #endregion
                    // BLOCO DE TRATAMENTO DE EXCEÇÃO ESPECÍFICO/ PERSONALIZADO:

                    Console.WriteLine($"Captura de Exceção Personalizada: {e.Message}");
                }
                catch (Exception e)
                {
                    // BLOCO DE TRATAMENTO DE EXCEÇÃO GENÉRICO:

                    Console.WriteLine($"Captura de Exceção Genérica: {e.Message}");
                }
                finally
                {
                    Console.WriteLine($"Números da lista: {string.Join(", ", numList)}\n");
                    Console.WriteLine($"A média de todos os números da lista é: {numList.Average():F3}\n");
                }
            }

            Console.WriteLine("Você saiu do programa.");
            Console.ReadKey();
        }
    }
}
