using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento
{
    class Carro
    {
        private string Placa;
        private int Manobras;

        public Carro(string placa)
        {
            Placa = placa;
            Manobras = 0;
        }

        public void AumetarManobra()
        {
            Manobras++;
        }

        public bool VerificaPlaca(string placa)
        {
            return Placa == placa;
        }

        public void Imprimir()
        {
            Console.WriteLine("Placa => {0} -  Manobras => {1}", Placa, Manobras);
        }
    }
}
