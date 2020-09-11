using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_08_Lucas_Braga_
{

    class CelulaDupla
    {
        public int dado { get; set; }
        public CelulaDupla prox { get; set; }
        public CelulaDupla ant { get; set; }
    }

    class ListaDupla
    {
        private CelulaDupla Inicio;
        private CelulaDupla Fim;
        private int m, o;
        
        private int Tam;

        public ListaDupla(int n, int M, int O)
        {
            m = M;
            o = O;

            CelulaDupla temp = new CelulaDupla();
            temp.dado = 1;
            temp.ant = null;
            temp.prox = null;
            Tam = 1;

            Inicio = Fim = temp;

            for (int i = 2; i <= n; i++)
            {
                temp = new CelulaDupla();
                temp.dado = i;
                temp.prox = null;
                temp.ant = Fim;

                Fim.prox = temp;
                Fim = temp;
                Tam++;
            }

            Fim.prox = Inicio;
            Inicio.ant = Fim;

        }

        public int Tamanho()
        {
            return Tam;
        }

        public void Imprimir()
        {
            CelulaDupla temp = Inicio;
            int cont = 0;

            while (cont < Tam)
            {
                Console.WriteLine(temp.dado);
                temp = temp.prox;
                cont++;
            }

        }

        public int AcharLider()
        {
            //Iniciar por onde o usúario selecionou
            CelulaDupla Comeco = Inicio;

            for (int i = 1; i < m; i++)
            {
                Comeco = Comeco.prox;
            }

            int lider = 0;

            CelulaDupla Removido = Comeco;

            while (Tam > 1)
            {
                //Contagem começa do removido anterior
                CelulaDupla Anterior = Removido;

                //temp se encontra no elemnto anterior ao qual sera removido
                for (int i = 1; i < o; i++)
                    Anterior = Anterior.prox;

                Removido = Anterior.prox;

                //Proximo do elemnto que sera removido
                CelulaDupla Proxima = Anterior.prox.prox;

                //alteracoes nos ponteiros do anterior e posterior do que será removido
                Anterior.prox = Anterior.prox.prox;
                Proxima.ant = Anterior;

                lider = Anterior.dado;

                Tam--;
            }

            return lider;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int n, m, o, x;
            x = int.Parse(Console.ReadLine());

            int[] resultado = new int[x];

            for (int i = 0; i < x; i++)
            {
                string exp = Console.ReadLine();
                string[] spl = exp.Split(' ');
                n = int.Parse(spl[0]);
                m = int.Parse(spl[1]);
                o = int.Parse(spl[2]);

                ListaDupla lista = new ListaDupla(n, m, o);
                resultado[i] = lista.AcharLider();
            }

            Console.WriteLine();

            for (int i = 0; i < x; i++)
            {
                Console.WriteLine(resultado[i]);
            }

            Console.ReadKey();
        }
    }

}

