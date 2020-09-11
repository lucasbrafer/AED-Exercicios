using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distancia
{
    public class Ponto
    {
        public int x { get; set; }
        public int y { get; set; }
    }


    class Program
    {

        // MÉTODO PARA GERAR UM VETOR DE PONTOS ALEATORIOS
        public static List<Ponto> getPontosAleatorios(int N)
        {
            // CRIA UM VETOR DE N PONTOS
            List<Ponto> pontos = new List<Ponto>();
            Ponto P;

            // PREENCHE O VETOR DE PONTOS DE FORMA ALEATÓRIA
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                P = new Ponto();
                P.x = (random.Next(0, N));
                P.y = (random.Next(0, N));
                pontos.Add(P);
            }

            // RETORNA O VETOR DE PONTOS
            return pontos;
        }

        static double DistanciaPontos(Ponto p1, Ponto p2)
        {
            return Math.Sqrt(Math.Pow(p1.x - p2.x,2) + Math.Pow(p1.y - p2.y,2));
        }

        static double DistanciaVet(List<Ponto> v, Ponto p, ref Ponto pmenor, int posicaop)
        {
            double menor = double.MaxValue;
            int i = 0;

            foreach (Ponto ponto in v)
            {
                //para não se comparar com ele mesmo e os anteriores para evitar esforço
                if (i > posicaop)
                {
                    //se existir alguma distancia menor
                    if (DistanciaPontos(ponto, p) < menor)
                    {
                        //valores são substituidos
                        menor = DistanciaPontos(ponto, p);
                        pmenor = ponto;
                    }
                }
                //para cada ponto p no vetor
                i++;
            }

            
            Console.WriteLine("\n\nPonto mais proximo de P no vetor: "+menor);
            Console.WriteLine("P  = x:{0} - y:{1}  Pvetor = x:{2} - y:{3}",p.x,p.y,pmenor.x,pmenor.y);
            

            return menor;
        }
                
        static void MenorDpontos(List<Ponto> vet)
        {
            //inicializando um ponto com valores aleatorios para que ele possa entrar na condicional
            //pmenor vai ser mandado como ref para sempre ter os ponto que contem a distância menor do ponto que está no vetor
            Ponto pmenor = new Ponto();
            //p1 e p2 para armazenar os pontos com menor distância
            Ponto p1 = new Ponto();
            Ponto p2 = new Ponto();

            double menor = double.MaxValue;

            int i = 0;

            foreach (Ponto ponto in vet)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                if (DistanciaVet(vet, ponto, ref pmenor, i) < menor)
                {
                    //menor recebe o valor retornado da função que calculou a menor distância entre os ponto e os pontos vetor
                    menor = DistanciaVet(vet, ponto, ref pmenor, i);

                    //ponto com a menor distancia é armazenado em p1
                    p1 = ponto;

                    //vai receber o ponto que está no List onde possui menor distancia com o ponto do vetor atual
                    p2 = pmenor;

                }

                //saber posição atual 
                i++;

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                Console.WriteLine("Tempo Gasto : " + elapsedMs + " segundos ");

                var ramUsage = System.Diagnostics.Process.GetCurrentProcess().PeakWorkingSet64;
                var allocationInMB = ramUsage / (1024 * 1024);
                Console.Write(" - Memória utilizada : " + allocationInMB + "MB");

            }

            Console.WriteLine("\n\nMenor distância entre os pontos do vetor: ");
            Console.WriteLine("\nponto 1:");
            Console.WriteLine("x: {0} - y:{1}", p1.x, p1.y);

            Console.WriteLine("\nponto 2: " );
            Console.WriteLine("x: {0} - y:{1}", p2.x, p2.y);

            Console.Write("\n\nA Distância entre os pontos: " + menor);

        }


        static void Main(string[] args)
        {
            List<Ponto> Pontos = new List<Ponto>();

            // ir de N = 1.000 até 100.000
            var watch1 = System.Diagnostics.Stopwatch.StartNew();

            for (int N = 1000; N <= 100000; N += 1000)
            {

                Pontos = getPontosAleatorios(N);

                var watch = System.Diagnostics.Stopwatch.StartNew();

                MenorDpontos(Pontos);

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds / 1000.0;
                Console.Write(" - Tempo Gasto : " + elapsedMs + " segundos ");

                var ramUsage = System.Diagnostics.Process.GetCurrentProcess().PeakWorkingSet64;
                var allocationInMB = ramUsage / (1024 * 1024);
                Console.Write(" - Memória utilizada : " + allocationInMB + "MB\n\n");


            }

            Console.WriteLine("-----------------------------------------------------------------------------------");
            var elapsedMs1 = watch1.ElapsedMilliseconds / 1000.0;
            Console.Write("Tempo Total Gasto : " + elapsedMs1 + " segundos ");

            var ramUsage1 = System.Diagnostics.Process.GetCurrentProcess().PeakWorkingSet64;
            var allocationInMB1 = ramUsage1 / (1024 * 1024);
            Console.Write(" - Memória utilizada : " + allocationInMB1 + "MB\n");
            Console.WriteLine("-----------------------------------------------------------------------------------");


            Console.ReadKey();
        }
    }
}
