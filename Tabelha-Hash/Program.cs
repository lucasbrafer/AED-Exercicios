using System;
using System.IO;
using System.Collections;

namespace Binaria
{
    class Contato
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }

    class Arvore
    {
        class No
        {
            public Contato Dado;
            public No Esq, Dir;
            public No(Contato _dado)
            {
                Dado = _dado;
                Esq = Dir = null;
            }
        }

        private No Raiz;

        public Arvore()
        {
            Raiz = null;
        }

        public bool Vazia()
        {
            return Raiz == null;
        }

        public void Inserir(Contato _dado)
        {
            Raiz = Inserir(Raiz, _dado);
        }

        private No Inserir(No no, Contato _dado)
        {
            if (no == null)
                no = new No(_dado);
            else if (_dado.Codigo < no.Dado.Codigo) no.Esq = Inserir(no.Esq, _dado);
            else if (_dado.Codigo > no.Dado.Codigo) no.Dir = Inserir(no.Dir, _dado);
            else Console.WriteLine("Erro: Registro ja existente");
            return no;
        }

        public void Remover(int _chave)
        {
            Raiz = Remover(Raiz, _chave);
        }

        private No Remover(No no, int _chave)
        {
            if (no == null) Console.WriteLine("Erro: Registro nao encontrado");
            else if (_chave < no.Dado.Codigo) no.Esq = Remover(no.Esq, _chave);
            else if (_chave > no.Dado.Codigo) no.Dir = Remover(no.Dir, _chave);
            else
            {
                if (no.Dir == null) no = no.Esq;
                else if (no.Esq == null) no = no.Dir;
                else no.Esq = Antecessor(no, no.Esq);
            }
            return no;
        }

        private No Antecessor(No no, No ant)
        {
            if (ant.Dir != null) ant.Dir = Antecessor(no, ant.Dir);
            else
            {
                no.Dado = ant.Dado;
                ant = ant.Esq;
            }
            return ant;
        }

        public void Pesquisar(int _cod)
        {
            Contato temp = Pesquisar(Raiz, _cod);
            Console.WriteLine("{0} - {1} - {2} - {3}",temp.Codigo,temp.Nome,temp.DataNascimento,temp.Email);
            Console.WriteLine();
        }

        private Contato Pesquisar(No no, int cod)
        {
            if (no == null) Console.WriteLine("Erro: Registro não encontrado");

            if (cod > no.Dado.Codigo) return Pesquisar(no.Dir, cod);
            else if (cod < no.Dado.Codigo) return Pesquisar(no.Esq, cod);
            else return no.Dado;

        }

        public void PesquisarNome(string _nome)
        {
            Contato temp = PesquisarNome(Raiz, _nome);
            Console.WriteLine("{0} - {1} - {2} - {3}", temp.Codigo, temp.Nome, temp.DataNascimento, temp.Email);
            Console.WriteLine();
        }

        private Contato PesquisarNome(No no, string nome)
        {

            if (no.Dado.Nome == nome)
                return no.Dado;

            return PesquisarNome(no.Esq, nome);
            return PesquisarNome(no.Dir, nome);

        }

        public void PesquisarData(string _data)
        {
            Contato temp = PesquisarData(Raiz, _data);
            Console.WriteLine("{0} - {1} - {2} - {3}", temp.Codigo, temp.Nome, temp.DataNascimento, temp.Email);
            Console.WriteLine();
        }

        private Contato PesquisarData(No no, string data)
        {
            if (no != null)
            {
                if (no.Dado.DataNascimento == data)
                    return no.Dado;

                PesquisarNome(no.Esq, data);
                PesquisarNome(no.Dir, data);
            }

            return null;

        }

        public void PesquisarEmail(string _email)
        {
            Contato temp = PesquisarEmail(Raiz, _email);
            Console.WriteLine("{0} - {1} - {2} - {3}", temp.Codigo, temp.Nome, temp.DataNascimento, temp.Email);
            Console.WriteLine();
        }

        private Contato PesquisarEmail(No no, string email)
        {
            if (no != null)
            {
                if (no.Dado.Email == email)
                    return no.Dado;

                PesquisarNome(no.Esq, email);
                PesquisarNome(no.Dir, email);
            }

            return null;

        }

    }

    class Lista
    {
        class Celula
        {
            public Contato Dado { get; set; }
            public Celula prox { get; set; }
        }

        private Celula Inicio;
        private Celula Fim;
        private int Tam;

        public Lista()
        {
            Tam = 0;
            Inicio = new Celula();
            Fim = Inicio;
            Inicio.prox = null;
        }

        public bool Vazia()
        {
            return Tam == 0;
        }

        public int Tamanho()
        {
            return Tam;
        }

        public void Inserir(Contato _dado)
        {
            Celula temp = new Celula();
            temp.Dado = _dado;
            temp.prox = null;
            Fim.prox = temp;
            Fim = temp;
            Tam++;
        }

        public Contato Remover(int pos)
        {
            if (pos < 0 || pos > (Tam - 1))
            {
                return null;
            }

            Celula Ant = Inicio;
            for (int i = 0; i < pos; i++)
                Ant = Ant.prox;

            Celula temp = Ant.prox;
            Ant.prox = temp.prox;

            if (temp.prox == null)
                Fim = Ant;

            Tam--;

            return temp.Dado;
        }

        public Contato PesquisarCod(int Reg)
        {
            Celula aux = Inicio.prox;

            while (aux != null)
            {
                if (aux.Dado.Codigo == Reg)               
                    return aux.Dado;
   
                aux = aux.prox;
            }
            return null;
        }

        public Contato PesquisarNome(string Reg)
        {
            Celula aux = Inicio.prox;

            while (aux != null)
            {
                if (aux.Dado.Nome == Reg)
                    return aux.Dado;

                aux = aux.prox;
            }
            return null;
        }

        public Contato PesquisarEmail(string Reg)
        {
            Celula aux = Inicio.prox;

            while (aux != null)
            {
                if (aux.Dado.Email == Reg)
                    return aux.Dado;

                aux = aux.prox;
            }
            return null;
        }

        public Contato PesquisarData(string Reg)
        {
            Celula aux = Inicio.prox;

            while (aux != null)
            {
                if (aux.Dado.DataNascimento == Reg)
                    return aux.Dado;

                aux = aux.prox;
            }
            return null;
        }

        public void ImprimirNome()
        {
            Celula aux = Inicio.prox;

            //ordena
            while (aux != null)
            {
                if(aux.Dado.Nome.CompareTo(aux.prox.Dado.Nome) >= 1)
                {
                    Contato temp = aux.Dado;
                    aux.Dado = aux.prox.Dado;
                    aux.prox.Dado = temp;
                }

                aux = aux.prox;
            }

            Imprimir();

        }

        public void ImprimirData()
        {
            Celula aux = Inicio.prox;

            //ordena
            while (aux != null)
            {
                if (aux.Dado.DataNascimento.CompareTo(aux.prox.Dado.DataNascimento) >= 1)
                {
                    Contato temp = aux.Dado;
                    aux.Dado = aux.prox.Dado;
                    aux.prox.Dado = temp;
                }

                aux = aux.prox;
            }

            Imprimir();

        }

        public void Imprimir()
        {
            Celula aux = Inicio.prox;

            //ordena
            while (aux != null)
            {

                Console.WriteLine("{0} - {1}", aux.Dado.Nome, aux.Dado.Email);
                aux = aux.prox;
            }
            
        }

    }

    class TabelaHash
    {
        Lista[] tabela;
        int Max;

        public TabelaHash(int _max)
        {
            Max = _max;
            tabela = new Lista[Max];

            for (int i = 0; i < Max; i++)
                tabela[i] = new Lista();
        }

        private int h(int _chave)
        {
            return _chave % Max;
        }

        public void Inserir(Contato reg)
        {
            int pos = h(reg.Codigo);
            tabela[pos].Inserir(reg);
        }

        public Contato PesquisarCod(int chave)
        {
            int pos = h(chave);
            Contato r = tabela[pos].PesquisarCod(chave);

            return r;

        }

        public Contato PesquisarNome(string chave)
        {
            int _key = 0;

            for (int i = 0; i < chave.Length; i++)
                _key += chave[i];

            int pos = h(_key);
            Contato r = tabela[pos].PesquisarNome(chave);

            return r;
        }

        public Contato PesquisarEmail(string chave)
        {
            int _key = 0;

            for (int i = 0; i < chave.Length; i++)
                _key += chave[i];

            int pos = h(_key);
            Contato r = tabela[pos].PesquisarEmail(chave);


            return r;
        }

        public Contato PesquisarData(string chave)
        {
            int _key = 0;

            for (int i = 0; i < chave.Length; i++)
                _key += chave[i];

            int pos = h(_key);
            Contato r = tabela[pos].PesquisarData(chave);

            return r;
        }
    }


    class Program
    {
        //--> ler contato
        static Contato GeraContato(string[] linhasplit)
        {
            Contato x = new Contato();
            x.Codigo = int.Parse(linhasplit[0]);
            x.Nome = linhasplit[1];
            x.DataNascimento = linhasplit[2];
            x.Telefone = linhasplit[3];
            x.Email = linhasplit[4];
            return x;
        }

        static void LerArquivo(ref Lista dados)
        {
            FileStream arq = new FileStream("dados.txt", FileMode.OpenOrCreate);
            StreamReader read = new StreamReader(arq);
            read.ReadLine();
            string linha = "";
            string[] linhasplit;

            while (linha != null)
            {
                linha = read.ReadLine();
                if (linha != null)
                {
                    linhasplit = linha.Split(';');
                    dados.Inserir(GeraContato(linhasplit));
                }
            }
            read.Close();
            arq.Close();

        }

        //--> inserir no arquivo
        static void InserirArquivo(Contato x)
        {
            FileStream arq = new FileStream("dados.txt", FileMode.Append);
            StreamWriter write = new StreamWriter(arq);

            write.WriteLine("{0};{1};{2};{3};{4}", x.Codigo, x.Nome, x.DataNascimento, x.Telefone, x.Email);


            write.Close();
            arq.Close();
        }

        //--> Atualizar Arquivo
        static void AtualizarArquivo(Lista temp)
        {
            FileStream arq = new FileStream("dados.txt", FileMode.Create);
            StreamWriter write = new StreamWriter(arq);

            for (int i = 0; i < temp.Tamanho(); i++)
            {
                Contato x = temp.Remover(i);
                write.WriteLine("{0};{1};{2};{3};{4}", x.Codigo, x.Nome, x.DataNascimento, x.Telefone, x.Email);
            }

            write.Close();
            arq.Close();

        }


        static void Main(string[] args)
        {
            Lista MyList = new Lista();
            LerArquivo(ref MyList);
            TabelaHash hash = new TabelaHash(MyList.Tamanho() + 23);
            Arvore arvore = new Arvore();
            Contato temp;


            string opc = "";
            do
            {
                Console.WriteLine("1 - Inserir Contato");
                Console.WriteLine("2 - Remover Contato da Lista");
                Console.WriteLine("3 - Imprimir ordenado por Nome");
                Console.WriteLine("4 - Imprimir ordenado por Email");
                Console.WriteLine("5 - Pesquisar Arvore");
                Console.WriteLine("6 - Pesquisar Hash");
                Console.WriteLine("7 - Sair");
                Console.Write("Opção: ");
                opc = Console.ReadLine();

                switch (opc)
                {
                    case "1":
                        Contato x = new Contato();
                        Console.WriteLine("Codigo: ");
                        x.Codigo = int.Parse(Console.ReadLine());

                        Console.WriteLine("Nome: ");
                        x.Nome = Console.ReadLine();

                        Console.WriteLine("Telefone: ");
                        x.Telefone = Console.ReadLine();

                        Console.WriteLine("Email: ");
                        x.Email = Console.ReadLine();

                        arvore.Inserir(x);
                        hash.Inserir(x);
                        InserirArquivo(x);
                        MyList.Inserir(x);

                        break;

                    case "2":
                        Console.WriteLine("indice para remoção: ");
                        int ind = int.Parse(Console.ReadLine());
                        MyList.Remover(ind);
                        break;

                    case "3":
                        MyList.ImprimirNome();
                        break;

                    case "4":
                        MyList.ImprimirData();
                        break;

                    case "6":
                        Console.WriteLine();
                        Console.WriteLine();
                        string op1 = "";
                        do
                        {
                            Console.WriteLine("1 - Pesquisar Nome");
                            Console.WriteLine("2 - Pesquisar Nome");
                            Console.WriteLine("3 - Pesquisar Data");
                            Console.WriteLine("4 - Pesquisar Email");
                            Console.WriteLine("5 - Sair");
                            Console.WriteLine("opc: ");
                            op1 = Console.ReadLine();

                            switch (op1)
                            {
                                case "1":
                                    Console.WriteLine("Codigo: ");
                                    int t = int.Parse(Console.ReadLine());
                                    temp = hash.PesquisarCod(t);
                                    Console.WriteLine("{0} - {1} - {2} - {3}", temp.Codigo, temp.Nome, temp.DataNascimento, temp.Email);
                                    break;

                                case "2":
                                    Console.WriteLine("Nome: ");
                                    string u = Console.ReadLine();
                                    temp = hash.PesquisarNome(u);
                                    Console.WriteLine("{0} - {1} - {2} - {3}", temp.Codigo, temp.Nome, temp.DataNascimento, temp.Email);
                                    break;

                                case "3":
                                    Console.WriteLine("Data: ");
                                    string e = Console.ReadLine();
                                    temp = hash.PesquisarData(e);
                                    Console.WriteLine("{0} - {1} - {2} - {3}", temp.Codigo, temp.Nome, temp.DataNascimento, temp.Email);
                                    break;

                                case "4":
                                    Console.WriteLine("Email: ");
                                    string ll = Console.ReadLine();
                                    temp = hash.PesquisarEmail(ll);
                                    Console.WriteLine("{0} - {1} - {2} - {3}", temp.Codigo, temp.Nome, temp.DataNascimento, temp.Email);
                                    break;


                            }

                        } while (opc != "5");

                        break;

                    case "5":
                        Console.WriteLine();
                        Console.WriteLine();

                        string op2 = "";


                        do
                        {
                            Console.WriteLine("1 - Pesquisar Cod");
                            Console.WriteLine("2 - Pesquisar Nome");
                            Console.WriteLine("3 - Pesquisar Data");
                            Console.WriteLine("4 - Pesquisar Email");
                            Console.WriteLine("5 - Sair");
                            Console.WriteLine("opc: ");
                            op2 = Console.ReadLine();

                            switch (op2)
                            {
                                case "1":
                                    Console.WriteLine("Codigo: ");
                                    int n = int.Parse(Console.ReadLine());
                                    arvore.Pesquisar(n);
                                    break;

                                case "2":
                                    Console.WriteLine("Nome: ");
                                    string s = Console.ReadLine();
                                    arvore.PesquisarNome(s);
                                    break;

                                case "3":
                                    Console.WriteLine("Data: ");
                                    string j = Console.ReadLine();
                                    arvore.PesquisarData(j);
                                    break;

                                case "4":
                                    Console.WriteLine("Email: ");
                                    string l = Console.ReadLine();
                                    arvore.PesquisarEmail(l);
                                    break;


                            }

                        } while (opc != "5");

                        break;

                }


                AtualizarArquivo(MyList);

            } while (opc != "7");
       
        }
    }
}
