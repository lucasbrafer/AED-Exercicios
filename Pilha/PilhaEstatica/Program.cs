using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoE
{
    class Pilha
    {
        private Carro[] Vagas = new Carro[10];
        private int Topo;
        private int MAX;

        public Pilha()
        {
            Topo = 0;
            MAX = 10;
        }

        public void Empilha(Carro car)
        {
            if (Topo < MAX)
            {
                Vagas[Topo] = car;
                Topo++;
            }
            else
            {
                Console.WriteLine("Estacionamento Cheio!");
            }
        }

        public Carro Desempilhar()
        {
            if(!Vazia())
            {
                Topo--;
                return Vagas[Topo];                
            }

            else
            {
                Console.WriteLine("Estacionamento Vazio!");
                return null;
            }
        }
        

        public bool Vazia()
        {
            return Topo == 0;
        }

        public void Imprimir()
        {
            for (int i = 0; i < Topo; i++)
            {
                Vagas[i].Exibe();                
            }
        }

    }

    class Carro
    {
        private string Placa;
        private int Manobras;

        public Carro(string placa)
        {
            Placa = placa;
            Manobras = 0;
        }

        public void AumentaManobras()
        {
            Manobras++;
        }

        public void Exibe()
        {
            Console.WriteLine("Placa -> {0}",Placa);
            Console.WriteLine("Manobras -> {0}",Manobras);
        }

        public bool VerificaPlaca(string placa)
        {
            return Placa == placa;
        }

    }

    class Program
    {
        static void EstacionarCarro(Pilha estacionamento)
        {
            string placa;
            Console.Write("Digite a placa do Carro..: ");
            placa = Console.ReadLine();
            Console.WriteLine();
            Carro car = new Carro(placa);

            estacionamento.Empilha(car);
        }

        static void RetirarCarro(Pilha estacionamento, Pilha rua)
        {
            
            
            string placa;
            Console.Write("Digite a placa do Carro..: ");
            placa = Console.ReadLine();

            while (!estacionamento.Vazia())
            {
                Carro c = estacionamento.Desempilhar();

                if (c.VerificaPlaca(placa))
                {
                    break;
                }

                c.AumentaManobras();
                rua.Empilha(c);
            }

            while (!rua.Vazia())
            {
                estacionamento.Empilha(rua.Desempilhar());
            }
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
