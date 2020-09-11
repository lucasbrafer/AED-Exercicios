using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_06____Lucas_Braga_
{
    class Celula
    {
        public int Dado { get; set; }
        public Celula Prox { get; set; }
    }

    class Pilha
    {
        Celula Topo;
        private int Tam;

        public Pilha()
        {
            Tam = 0;
            Topo = null;
        }

        public bool Vazia()
        {
            return Tam == 0;
        }

        public int Tamanho()
        {
            return Tam;
        }

        public void Empilhar(int dado)
        {
            Celula temp = new Celula();
            temp.Dado = dado;
            temp.Prox = Topo;
            Topo = temp;
            Tam++;
        }

        public int Desempilhar()
        {
            if (Vazia())
            {
                Console.WriteLine("Pilha Vazia!");
                return ' ';
            }

            int dado = Topo.Dado;

            Topo = Topo.Prox;
            Tam--;
            return dado;
        }

        public void Imprimir()
        {
            Celula temp = Topo;
            while(temp != null)
            {
                Console.WriteLine(temp.Dado);
                temp = temp.Prox;
            }
        }
    }

    class Fila
    {
        protected Celula Primeiro;
        protected Celula Ultimo;
        protected int Tam;

        public Fila()
        {
            Tam = 0;
            Primeiro = new Celula();
            Ultimo = Primeiro;
            Primeiro.Prox = null;
        }

        public bool Vazia()
        {
            return Primeiro == Ultimo;
        }

        public int Tamanho()
        {
            return Tam;
        }

        public void Enfileirar(int dado)
        {
            Celula temp = new Celula();
            temp.Dado = dado;
            temp.Prox = null;
            Ultimo.Prox = temp;
            Ultimo = temp;
            Tam++;

        }

        public int Desenfileirar()
        {
            if (Vazia())
            {
                Console.WriteLine("Fila Vazia!");
                return ' ';
            }

            Primeiro = Primeiro.Prox;
            Tam--;
            return Primeiro.Dado;

        }

        public void Imprimir()
        {
            Celula temp = Primeiro.Prox;

            while (temp != null)
            {
                Console.WriteLine(temp.Dado);
                temp = temp.Prox;
            }
        }


    }

    class FilaPrioridade:Fila
    {
        public void EnfileirarPrioridade(int dado)
        {
            Celula temp = Primeiro;

            Celula aux = new Celula();
            aux.Dado = dado;
            aux.Prox = null;

            while(temp.Prox != null && temp.Prox.Dado > aux.Dado)
            {
                temp = temp.Prox;
            }

            aux.Prox = temp.Prox;
            temp.Prox = aux;

            if (aux.Prox == null)
                Ultimo = aux;

            Tam++;



        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            int n;
            string opc;
            n = int.Parse(Console.ReadLine());

            Pilha pilha = new Pilha();
            Fila fila = new Fila();
            FilaPrioridade filaP = new FilaPrioridade();

            int validator = 0;
            bool stack = false;
            bool queue = false;
            bool queueP = false;

            for (int i = 0; i < n; i++)
            {
                opc = Console.ReadLine();
                int exp_opc = int.Parse(opc.Split(' ')[0]);
                int exp_num = int.Parse(opc.Split(' ')[1]);

                if (exp_opc == 1)
                {
                    pilha.Empilhar(exp_num);
                    fila.Enfileirar(exp_num);
                    filaP.EnfileirarPrioridade(exp_num);
                }
                else if (exp_opc == 2)
                {
                    if (exp_num == pilha.Desempilhar())
                        stack = true;

                    if (exp_num == fila.Desenfileirar())
                        queue = true;

                    if (exp_num == filaP.Desenfileirar())
                        queueP = true;

                }
            }

            if (stack == true)
                validator++;

            if (queue == true)
                validator++;

            if (queueP == true)
                validator++;


            if (validator <= 1)
            {
                if (stack == true)
                    Console.WriteLine("stack");

                if (queue == true)
                    Console.WriteLine("queue");

                if (queueP == true)
                    Console.WriteLine("priority queue");

                if(validator == 0)
                    Console.WriteLine("impossible");
            }
            else
            {
                Console.WriteLine("not sure");
            }

            Console.ReadKey();

        }
    }
}
