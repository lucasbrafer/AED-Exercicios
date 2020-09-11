using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabelaDaVerdade
{
    class Program
    {
        static void Main(string[] args)
        {
            string letras = "abcdefghijklmnopqrstuvwxyz";
            int n = 0;

            Console.Write("Digite o número de termos da sua tabela: ");
            n = int.Parse(Console.ReadLine());

            Console.Clear();

            for (int i = 0; i < n; i++)
            {
                Console.Write(" | "+ letras[i]);
            }
            Console.Write(" | ^ | v ");
            Console.WriteLine();

            TabelaVerdade(n);            

            Console.ReadKey();
        }

        //função recursiva para expressão or "v"
        public static int TabelaOU(int[] tabela, int n, int x)
        {
            //se "x" vier com o valor 1 quer dizer que a expressão or será verdadeira, pois ela apenas necessita de apenas um 1(true) para ser verdadeira 
            if (n == tabela.Length || x == 1)
            {
                return x;
            }
            else
            {
                if (tabela[n] == 1)
                {
                    x = 1;
                    return TabelaOU(tabela, n + 1, x);
                }
                else
                {
                    x = 0;
                    return TabelaOU(tabela, n + 1, x);
                }
            }
        }

        //função recursiva para a expressão and "^"
        public static int TabelaE(int[] tabela, int n, int x)
        {
            //se n ja estiver com o tamanho do length - 1 ou x == 0 ja retorna o x, pois se ouver um 0 na linha a expressão ja será falsa
            if(n == tabela.Length - 1 || x == 0) 
            {
                return x;
            }
            else
            {
                if (tabela[n] == 1 && tabela[n + 1] == 1)
                {
                    x = 1;
                    return TabelaE(tabela, n + 1, x);
                }
                else
                {
                    x = 0;
                    return TabelaE(tabela, n + 1, x);
                }
            }
        }

        //função recursiva para gerar a tabela da verdade
        public static void TabelaVerdadeRec(int[] tabela, int j)
        {
            //se a tabela ja estiver completa
            if (j == tabela.Length)
            {
                //exibe a tabela
                for (int i = 0; i < tabela.Length; i++)
                {
                    Console.Write(" | " + tabela[i]);
                }
                //exibe os resultados da função da tabela "and" e "or"
                Console.Write(" | " + TabelaE(tabela, 0, 1) + " | " + TabelaOU(tabela, 0, 0));
                Console.WriteLine();
            }
            else
            {
                //preenche a posição atual "j" com 0 e chama recursivamente a função para novamente preencher o vetor na proxima posição
                tabela[j] = 0;
                TabelaVerdadeRec(tabela, j + 1);

                //preenche com 1
                tabela[j] = 1;
                TabelaVerdadeRec(tabela, j + 1);
            }

        }

        //função auxilar para criar vetor e chamar a função
        public static void TabelaVerdade(int n)
        {
            int i = 0;
            int[] tabela = new int[n];
            TabelaVerdadeRec(tabela, i);

        }
    }
}
