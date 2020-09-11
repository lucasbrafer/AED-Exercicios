using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDC
{
    class Program
    {
        static void Main(string[] args)
        {
            string opc = " ";
            int x = 0, y = 0;
            do
            {
                Console.Clear();
                Console.Write("Digite o X: ");
                x = int.Parse(Console.ReadLine());
                Console.Write("Digite o Y: ");
                y = int.Parse(Console.ReadLine());

                Console.WriteLine("MDC: " + MDC(x, y));

                Console.WriteLine("\nquer repetir? (Sim para continuar, qualquer tecla para sair)");
                Console.Write("Opção: ");
                opc = Console.ReadLine().ToLower();

            } while (opc == "sim");

        }

        public static int MDC(int x, int y)
        {
            if(x == y)
            {
                return x;
            }

            if(x > y)
            {
               return MDC(x - y, y);
            }
            else
            {
                return MDC(y, x);
            }

        }

    }
}
