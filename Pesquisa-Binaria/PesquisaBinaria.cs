using System;
using System.IO;

namespace PesquisaBinaria
{
    class Contato
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

    }
    class Lista
    {
        protected int Max;
        protected Contato[] Dados;
        protected int Primeiro, Ultimo;
        protected int tam;

        public byte Ordenado;

        public Lista(int n)
        {
            Max = n + 1;
            Dados = new Contato[Max];

            Primeiro = 0;
            Ultimo = 0;
            tam = 0;
            Ordenado = 0;
        }

        public bool Vazia()
        {
            return Primeiro == Ultimo;
        }

        public void Inserir(Contato dado)
        {
            int pos = (Ultimo + 1) % Max;
            if (pos == Primeiro)
                Console.WriteLine("Lista Cheia!");
            else
            {

                Ultimo = pos;
                Dados[Ultimo] = dado;
                tam++;

                FileStream arquivo = new FileStream("Agenda.txt", FileMode.Append);
                StreamWriter escrita = new StreamWriter(arquivo);

                escrita.Write("{0};{1};{2};{3};{4}",dado.Codigo, dado.Nome, dado.DataNascimento, dado.Telefone, dado.Email);
                escrita.Close();
            }

        }

        public Contato Remover(int pos)
        {
            if (Vazia() || pos > Max || pos < 0)
            {
                return null;
            }

            tam--;

            pos = pos % Max;
            Contato dado = Dados[pos];

            int i = (pos - 1) % Max;
            int j = 0;
            do
            {
                i = (i + 1) % Max;
                j = (i + 1) % Max;

                Dados[i] = Dados[j];

            } while (j != Ultimo);

            Ultimo = (Ultimo - 1) % Max;

            if (tam > 0)
            {
                //reescrever
                FileStream arquivo = new FileStream("Agenda.txt", FileMode.Create);
                StreamWriter escrita = new StreamWriter(arquivo);

                int p = Primeiro;
                do
                {
                    p = (p + 1) % Max;
                    escrita.WriteLine("{0};{1};{2};{3};{4}", Dados[p].Codigo, Dados[p].Nome, Dados[p].DataNascimento, Dados[p].Telefone, Dados[p].Email);
                } while (p != Ultimo);

                escrita.Close();
                arquivo.Close();
            }

            return dado;
               
        }

        public int Tamanho()
        {
            return tam;
        }

        public void ImprimirNome()
        {
            //atualiza arquivo se nao tiver todos elementos
            if (Ordenado != 2)
                OrdenarAlfabetico();

            int i = Primeiro;
            do
            {
                i = (i + 1) % Max;
                Console.WriteLine("{0};{1};{2};{3};{4}", Dados[i].Codigo, Dados[i].Nome, Dados[i].DataNascimento.ToShortDateString(), Dados[i].Telefone, Dados[i].Email);
            } while (i != Ultimo);
        }

        public void ImprimirData()
        {
            //atualiza arquivo se nao tiver todos elementos
            if (Ordenado != 3)
                OrdenarData();

            int i = Primeiro;
            do
            {
                i = (i + 1) % Max;
                Console.WriteLine("{0};{1};{2};{3};{4}", Dados[i].Codigo, Dados[i].Nome, Dados[i].DataNascimento.ToShortDateString(), Dados[i].Telefone, Dados[i].Email);
        } while (i != Ultimo);
        }

        //1
        public void OrdenarCodigo()
        {
            if (tam > 1)
            {
                for (int c = 0; c < tam; c++)
                {
                    int i = Primeiro;
                    int j = 0;

                    do
                    {
                        i = (i + 1) % Max;
                        j = (i + 1) % Max;
                        if (Dados[j] != null)
                        {
                            if (Dados[i].Codigo > Dados[j].Codigo)
                            {
                                Contato aux = Dados[i];
                                Dados[i] = Dados[j];
                                Dados[j] = aux;
                            }
                        }

                    } while (i != Ultimo);
                }

            }
                FileStream arquivo = new FileStream("Agenda1.txt", FileMode.Create);
                StreamWriter escrita = new StreamWriter(arquivo);

                int p = Primeiro;
                do
                {
                    p = (p + 1) % Max;
                    escrita.WriteLine("{0};{1};{2};{3};{4}", Dados[p].Codigo, Dados[p].Nome, Dados[p].DataNascimento, Dados[p].Telefone, Dados[p].Email);
                } while (p != Ultimo);

                escrita.Close();
                arquivo.Close();

                Ordenado = 1;
            
        }

        //2
        public void OrdenarAlfabetico()
        {
            if (tam > 1)
            {
                for (int c = 0; c < tam; c++)
                {
                    int i = Primeiro;
                    int j = 0;

                    do
                    {
                        i = (i + 1) % Max;
                        j = (i + 1) % Max;
                        if (Dados[j] != null)
                        {
                            int v = Dados[i].Nome.CompareTo(Dados[j].Nome);
                            if (v == 1)
                            {
                                Contato aux = Dados[i];
                                Dados[i] = Dados[j];
                                Dados[j] = aux;
                            }
                        }

                    } while (i != Ultimo);
                }

            }

                FileStream arquivo = new FileStream("Agenda2.txt", FileMode.Create);
                StreamWriter escrita = new StreamWriter(arquivo);

                int p = Primeiro;
                do
                {
                    p = (p + 1) % Max;
                    escrita.WriteLine("{0};{1};{2};{3};{4}", Dados[p].Codigo, Dados[p].Nome, Dados[p].DataNascimento, Dados[p].Telefone, Dados[p].Email);
                } while (p != Ultimo);

                escrita.Close();
                arquivo.Close();

                Ordenado = 2;
            
        }

        //3
        public void OrdenarEmail()
        {
            if (tam > 1)
            {
                for (int c = 0; c < tam; c++)
                {
                    int i = Primeiro;
                    int j = 0;

                    do
                    {
                        i = (i + 1) % Max;
                        j = (i + 1) % Max;
                        if (Dados[j] != null)
                        {
                            int v = Dados[i].Email.CompareTo(Dados[j].Email);
                            if (v == 1)
                            {
                                Contato aux = Dados[i];
                                Dados[i] = Dados[j];
                                Dados[j] = aux;
                            }
                        }

                    } while (i != Ultimo);
                }

            }

                FileStream arquivo = new FileStream("Agenda3.txt", FileMode.Create);
                StreamWriter escrita = new StreamWriter(arquivo);

                int p = Primeiro;
                do
                {
                    p = (p + 1) % Max;
                    escrita.WriteLine("{0};{1};{2};{3};{4}", Dados[p].Codigo, Dados[p].Nome, Dados[p].DataNascimento, Dados[p].Telefone, Dados[p].Email);
                } while (p != Ultimo);

                escrita.Close();
                arquivo.Close();

                Ordenado = 3;
            
        }
       
        //4
        public void OrdenarData()
        {
            if (tam > 1)
            {
                for (int c = 0; c < tam; c++)
                {
                    int i = Primeiro;
                    int j = 0;

                    do
                    {
                        i = (i + 1) % Max;
                        j = (i + 1) % Max;
                        if (Dados[j] != null)
                        {
                            if (Dados[i].DataNascimento > Dados[j].DataNascimento)
                            {
                                Contato aux = Dados[i];
                                Dados[i] = Dados[j];
                                Dados[j] = aux;
                            }
                        }

                    } while (i != Ultimo);
                }

            }

                FileStream arquivo = new FileStream("Agenda4.txt", FileMode.Create);
                StreamWriter escrita = new StreamWriter(arquivo);

                int p = Primeiro;
                do
                {
                    p = (p + 1) % Max;
                    escrita.WriteLine("{0};{1};{2};{3};{4}", Dados[p].Codigo, Dados[p].Nome, Dados[p].DataNascimento, Dados[p].Telefone, Dados[p].Email);
                } while (p != Ultimo);

                escrita.Close();
                arquivo.Close();

                Ordenado = 4;
            
        }

        public Contato[] ListaDados()
        {
            return Dados;
        }

    }

    class Pesquisa
    {
        private Lista List;

        public Pesquisa(ref Lista list)
        {
            List = list;
        }
        public Contato PesquisaCod(int dado)
        {
            List.OrdenarCodigo();

            FileStream arquivo1 = new FileStream("Agenda1.txt", FileMode.Open);
            StreamReader ler = new StreamReader(arquivo1);

            string linha;
            string[] resultado;
            Contato[] MeusContatos = new Contato[1600];
            int i = 0;

            do
            {
                linha = ler.ReadLine();
                if (linha != null)
                {
                    resultado = linha.Split(';');

                    Contato x = new Contato();

                    x.Codigo = int.Parse(resultado[0]);

                    x.Nome = resultado[1];

                    //converte a data
                    DateTime data = DateTime.Parse(resultado[2]);
                    x.DataNascimento = data;


                    x.Telefone = resultado[3];

                    x.Email = resultado[4];

                    MeusContatos[i] = x;

                    i++;
                }

            } while (linha != null);

            //new
            arquivo1.Close();

            int Inicio = 0;
            //new
            int Fim = i - 1;

            while (Inicio <= Fim)
            {
                int Meio = (Inicio + Fim) / 2;
 

                if (MeusContatos[Meio].Codigo == dado)
                    return MeusContatos[Meio];

                if (MeusContatos[Meio].Codigo > dado)
                    Fim = Meio - 1;
                else
                    Inicio = Meio + 1;
            }

            return null;

        }

        public Contato PesquisaNome(string dado)
        {
            List.OrdenarAlfabetico();

            FileStream arquivo1 = new FileStream("Agenda2.txt", FileMode.Open);
            StreamReader ler = new StreamReader(arquivo1);

            string linha;
            string[] resultado;
            Contato[] MeusContatos = new Contato[1600];
            int i = 0;

            do
            {
                linha = ler.ReadLine();
                if (linha != null)
                {
                    resultado = linha.Split(';');

                    Contato x = new Contato();

                    x.Codigo = int.Parse(resultado[0]);

                    x.Nome = resultado[1];

                    //converte a data
                    DateTime data = DateTime.Parse(resultado[2]);
                    x.DataNascimento = data;

                    x.Telefone = resultado[3];

                    x.Email = resultado[4];

                    MeusContatos[i] = x;

                    i++;
                }

            } while (linha != null);

            arquivo1.Close();

            int Inicio = 0;
            int Fim = i - 1;

            while (Inicio <= Fim)
            {
                int Meio = (Inicio + Fim);

                int v = MeusContatos[Meio].Nome.CompareTo(dado);

                if (MeusContatos[Meio].Nome == dado)
                    return MeusContatos[Meio];

                if (v == 1)
                    Fim = Meio - 1;
                else
                    Inicio = Meio + 1;
            }

            return null;

        }

        public Contato PesquisaData(DateTime dado)
        {
            List.OrdenarData();

            FileStream arquivo1 = new FileStream("Agenda4.txt", FileMode.Open);
            StreamReader ler = new StreamReader(arquivo1);

            string linha;
            string[] resultado;
            Contato[] MeusContatos = new Contato[1600];
            int i = 0;

            do
            {
                linha = ler.ReadLine();
                if (linha != null)
                {
                    resultado = linha.Split(';');

                    Contato x = new Contato();

                    x.Codigo = int.Parse(resultado[0]);

                    x.Nome = resultado[1];

                    //converte a data
                    DateTime data = DateTime.Parse(resultado[2]);
                    x.DataNascimento = data;

                    x.Telefone = resultado[3];

                    x.Email = resultado[4];

                    MeusContatos[i] = x;

                    i++;
                }

            } while (linha != null);

            arquivo1.Close();

            int Inicio = 0;
            int Fim = i - 1;

            while (Inicio <= Fim)
            {
                int Meio = (Inicio + Fim);

                if (MeusContatos[Meio].DataNascimento == dado)
                    return MeusContatos[Meio];

                if (MeusContatos[Meio].DataNascimento > dado)
                    Fim = Meio - 1;
                else
                    Inicio = Meio + 1;
            }

            return null;

        }

        public Contato PesquisaEmail(string dado)
        {
            List.OrdenarEmail();

            FileStream arquivo1 = new FileStream("Agenda3.txt", FileMode.Open);
            StreamReader ler = new StreamReader(arquivo1);

            string linha;
            string[] resultado;
            Contato[] MeusContatos = new Contato[1600];
            int i = 0;

            do
            {
                linha = ler.ReadLine();
                if (linha != null)
                {
                    resultado = linha.Split(';');

                    Contato x = new Contato();

                    x.Codigo = int.Parse(resultado[0]);

                    x.Nome = resultado[1];

                    //converte a data
                    DateTime data = DateTime.Parse(resultado[2]);
                    x.DataNascimento = data;


                    x.Telefone = resultado[3];

                    x.Email = resultado[4];

                    MeusContatos[i] = x;

                    i++;
                }

            } while (linha != null);

            arquivo1.Close();

            int Inicio = 0;
            int Fim = i - 1;

            while (Inicio <= Fim)
            {
                int Meio = (Inicio + Fim);

                int v = MeusContatos[Meio].Email.CompareTo(dado);

                if (MeusContatos[Meio].Email == dado)
                    return MeusContatos[Meio];

                if (v == 1)
                    Fim = Meio - 1;
                else
                    Inicio = Meio + 1;
            }

            return null;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string opc = "";
            Lista lista = new Lista(16000);
            int cod = 0;
            Contato dado;
            Pesquisa MP;
            do
            {
                Console.WriteLine("1 - Inserir Contato");
                Console.WriteLine("2 - Remover Contato");
                Console.WriteLine("3 - Imprimir ordenado por Nome");
                Console.WriteLine("4 - Imprimir ordenado por Data de Nascimento");
                Console.WriteLine("5 - Pesquisar pelo Código");
                Console.WriteLine("6 - Pesquisar pelo Nome");
                Console.WriteLine("7 - Pesquisar pela Data de Nascimento");
                Console.WriteLine("8 - Pesquisar pelo Email");
                Console.WriteLine("9 - Sair");


                Console.Write("\nOpção => ");
                opc = Console.ReadLine();


                switch (opc)
                {
                    case "1":
                        Contato x = new Contato();
                        x.Codigo = cod;

                        Console.Write("Nome: ");
                        x.Nome = Console.ReadLine();

                        Console.Write("Data de nascimento (??/??/????): ");
                        DateTime data = DateTime.Parse(Console.ReadLine());

                        x.DataNascimento = data;

                        Console.Write("Telefone: ");
                        x.Telefone = Console.ReadLine();

                        Console.Write("Email: ");
                        x.Email = Console.ReadLine();

                        lista.Inserir(x);

                        cod++;
                        break;

                    case "2":
                        Console.Write("Índice: ");
                        int ind = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nRemovido => " + lista.Remover(ind));
                        break;

                    case "3":
                        lista.ImprimirNome();
                        break;

                    case "4":
                        lista.ImprimirData();
                        break;

                    case "5":
                        MP = new Pesquisa(ref lista);

                        Console.Write("Código para pesquisar: ");
                        int cinco = int.Parse(Console.ReadLine());

                        dado = MP.PesquisaCod(cinco);

                        if (dado != null)
                        {
                            Console.WriteLine("{0};{1};{2};{3};{4}", dado.Codigo, dado.Nome, dado.DataNascimento.ToShortDateString(), dado.Telefone, dado.Email);
                        }
                        else
                        {
                            Console.WriteLine("Não Encontrado!");
                        }

                        break;

                    case "6":
                        MP = new Pesquisa(ref lista);

                        Console.Write("Nome para pesquisar: ");
                        string seis = Console.ReadLine();

                        dado = MP.PesquisaNome(seis);

                        if (dado != null)
                        {
                            Console.WriteLine("{0};{1};{2};{3};{4}", dado.Codigo, dado.Nome, dado.DataNascimento.ToShortDateString(), dado.Telefone, dado.Email);
                        }
                        else
                        {
                            Console.WriteLine("Não Encontrado!");
                        }

                        break;

                    case "7":
                        MP = new Pesquisa(ref lista);

                        Console.Write("para pesquisar Data de nascimento (??/??/????): ");
                        DateTime data6 = DateTime.Parse(Console.ReadLine());

                        dado = MP.PesquisaData(data6);
                        if (dado != null)
                        {
                            Console.WriteLine("{0};{1};{2};{3};{4}", dado.Codigo, dado.Nome, dado.DataNascimento.ToShortDateString(), dado.Telefone, dado.Email);
                        }
                        else
                        {
                            Console.WriteLine("Não Encontrado!");
                        }

                        break;

                    case "8":
                        MP = new Pesquisa(ref lista);

                        Console.Write("Email para pesquisar: ");
                        string oito = Console.ReadLine();

                        dado = MP.PesquisaEmail(oito);

                        if (dado != null)
                        {
                            Console.WriteLine("{0};{1};{2};{3};{4}", dado.Codigo, dado.Nome, dado.DataNascimento.ToShortDateString(), dado.Telefone, dado.Email);
                        }
                        else
                        {
                            Console.WriteLine("Não Encontrado!");
                        }

                        break;
                }


                Console.WriteLine("\n\nAperte Enter para continua...");
                Console.ReadKey();
                Console.Clear();
            } while (opc != "9");

        }
    }
}

