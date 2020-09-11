using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07__Lucas_Braga_
{
    class Site
    {
        public string URL { get; set; }
        public Site prox { get; set; }
    }

    class Lista
    {
        protected Site Inicio;
        protected Site Fim;
        protected int Tam;

        public Lista()
        {
            Tam = 0;
            Inicio = new Site();
            Fim = Inicio;
            Inicio.prox = null;
        }

        public bool Vazia()
        {
            return Inicio == Fim;
        }

        public int Tamanho()
        {
            return Tam;
        }

        public bool ValidaExistencia(string URL)
        {
            bool v = false;

            Site temp = Inicio.prox;

            while (temp != null)
            {
                if (URL == temp.URL)
                {
                    v = true;
                    break;
                }
                temp = temp.prox;
            }

            return v;
        }

        public void CadastraSite(string URL)
        {
            if (!ValidaExistencia(URL))
            {
                Site temp = new Site();
                temp.URL = URL;
                temp.prox = null;
                Fim.prox = temp;
                Fim = temp;
                Tam++;
            }
            else
            {
                Console.WriteLine("Site ja Cadastrado!");
            }

        }

        public int Pesquisar(string URL)
        {
            int cont = 1;

            Site temp = Inicio;

            //se existir é removido da sua posição original
            if (ValidaExistencia(URL))
            {
                while (temp.prox != null)
                {
                    if (URL == temp.prox.URL)
                    {
                        break;
                    }
                    else
                    {
                        cont++;
                        temp = temp.prox;
                    }
                }

                if (temp.prox.prox == null)
                {
                    Fim = temp;
                    Fim.prox = null;
                }
                else
                {
                    temp.prox = temp.prox.prox;
                }
            }
            //fim da remoção


            //inserir o Site na primeira posição
            Site aux = new Site();
            aux.URL = URL;

            aux.prox = Inicio.prox;
            Inicio.prox = aux;


            return cont;
        }

        public void Listar()
        {
            Site temp = Inicio.prox;

            while (temp != null)
            {
                Console.WriteLine(temp.URL);
                temp = temp.prox;
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Lista list = new Lista();

            string opc = "";
            string URL = "";

            do
            {
                Console.WriteLine("1 - Cadastrar Site");
                Console.WriteLine("2 - Listar Sites cadastrados");
                Console.WriteLine("3 - Quantidade de Sites cadastrados");
                Console.WriteLine("4 - Pesquisar Site");
                Console.WriteLine("5 - Sair");
                Console.Write("Opção =>  ");
                opc = Console.ReadLine();

                switch (opc)
                {
                    case "1":
                        Console.Write("Digite a URL: ");
                        URL = Console.ReadLine();
                        list.CadastraSite(URL);
                        break;

                    case "2":
                        list.Listar();
                        break;

                    case "3":
                        Console.WriteLine("Quantidade de Sites Cadastrados => " + list.Tamanho());
                        break;

                    case "4":
                        Console.Write("Digite a URL: ");
                        URL = Console.ReadLine();
                        Console.WriteLine("quantidade de acessos na list =>  " + list.Pesquisar(URL)); ;
                        break;

                }



                Console.WriteLine("\n\nAperte qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();


            } while (opc != "5");
        }
    }
}
