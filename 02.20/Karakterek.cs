using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._20
{
    internal class Karakter
    {
        public string Nev { get; set; }
        public int Szint { get; set; }
        public int Eletero { get; set; }
        public int Ero { get; set; }

        public Karakter(string nev, int szint, int eletero, int ero)
        {
            Nev = nev;
            Szint = szint;
            Eletero = eletero;
            Ero = ero;
        }

        public void ToString()
        {
            Console.WriteLine($"Név: {Nev}, Szint: {Szint}, Életerő: {Eletero}, Erő: {Ero}");
        }
    }
}
