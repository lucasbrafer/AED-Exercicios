using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento
{
    class Celula
    {
        public Carro dado { get; set; }
        public Celula prox { get; set; }

    }

    class Pilha
    {
        private Celula topo;
        private int tam;

        public Pilha()
        {
            topo = null;
            tam = 0;
        }

        public void Empilhar(Carro dado)
        {
            Celula temp = new Celula();
            temp.dado = dado;
            temp.prox = topo;
            topo = temp;
            tam++;
        }

        public void Imprimir()
        {
            Celula temp = topo;

            while (temp != null)
            {
                temp.dado.Imprimir();
                temp = temp.prox;
            }
        }

        public bool Vazia()
        {
            return topo == null;
        }

        //retorna o que foi desempilhado e diminui o tamanho
        public Carro Desempilhar()
        {
            if (Vazia())
            {
                return null;
            }
            else
            {
                Carro dado = topo.dado;
                topo = topo.prox;
                tam--;
                return dado;
            }
        }


    }
}
