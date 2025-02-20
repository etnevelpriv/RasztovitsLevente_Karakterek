using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public static void atlagSzint(List<Karakter> karakterek)
        {
            int osszeg = 0;
            foreach (var karakter in karakterek)
            {
                osszeg += karakter.Szint;
            }

            double atlagSzint = osszeg / karakterek.Count;
            Console.WriteLine($"\nÁtlag szint: {atlagSzint}");
        }

        public static void rendezesEro(List<Karakter> karakterek)
        {
            Console.WriteLine("\nRendezett karakterek erő szerint:");
            var rendezett = karakterek.OrderByDescending(k => k.Ero).ToList();
            foreach (var karakter in rendezett)
            {
                Console.WriteLine(karakter);
            }
        }

        public bool eroNagyobbMint(int ertek)
        {
            return Ero > ertek;
        }

        public override string ToString()
        {
            return $"Név: {Nev}, Szint: {Szint}, Életerő: {Eletero}, Erő: {Ero}";
        }
    }
}
