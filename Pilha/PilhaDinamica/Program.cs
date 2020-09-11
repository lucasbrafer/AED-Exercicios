using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento
{
    class Program
    {
        static void EstacionarCarro(Pilha estacionamento)
        {
            string placa;
            Console.Write("Digite a placa do Carro..: ");
            placa = Console.ReadLine();
            Console.WriteLine();
            Carro car = new Carro(placa);

            estacionamento.Empilhar(car);

        }

        static void RetirarCarro(Pilha estacionamento, Pilha rua) 
        {
            string placa;
            Console.Write("Digite a placa do Carro..: ");
            placa = Console.ReadLine();
            Console.WriteLine();

            while (!estacionamento.Vazia())
            {
                Carro c = estacionamento.Desempilhar();

                if (c.VerificaPlaca(placa))
                {
                    Console.WriteLine("Carro {0} retirado! ",placa);
                    c.Imprimir();
                    break;
                }

                c.AumetarManobra();
                rua.Empilhar(c);
            }

            while (!rua.Vazia())
            {
                estacionamento.Empilhar(rua.Desempilhar());
            }

            Console.WriteLine("\naperte ENTER para continuar...");
            Console.ReadKey();

        }

        static void ExibirEstacionamento(Pilha estacionamento)
        {
            estacionamento.Imprimir();
            Console.WriteLine("\naperte ENTER para continuar...");
            Console.ReadKey();
        }


        static void Main(string[] args)
        {
            Pilha estacionamento = new Pilha();
            Pilha rua = new Pilha();

            string opc;

            do
            {
                Console.Clear();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("|  1- Estacionar Carro         |");
                Console.WriteLine("|  2- Retirar Carro            |");
                Console.WriteLine("|  3- Exibir Estacionamento    |");
                Console.WriteLine("|  4- Sair                     |");
                Console.WriteLine("--------------------------------");
                Console.Write("Opção => ");
                opc = Console.ReadLine();

                switch (opc)
                {
                    case "1":
                        EstacionarCarro(estacionamento);
                        break;

                    case "2":
                        RetirarCarro(estacionamento, rua);
                        break;

                    case "3":
                        ExibirEstacionamento(estacionamento);
                        break;

                    case "4":
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        break;

                }

            } while (opc != "4");

        }
    }
}
