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

        public static void MentesCSV(List<Karakter> karakterek)
        {
            using (StreamWriter sw = new StreamWriter("karakterek.csv"))
            {
                sw.WriteLine("Nev,Szint,Eletero,Ero");
                foreach (var karakter in karakterek)
                {
                    sw.WriteLine($"{karakter.Nev},{karakter.Szint},{karakter.Eletero},{karakter.Ero}");
                }
            }
        }

        public static List<Karakter> BeolvasCSV()
        {
            List<Karakter> karakterek = new List<Karakter>();
            string[] sorok = File.ReadAllLines("karakterek.csv");
            foreach (string sor in sorok.Skip(1))
            {
                string[] adatok = sor.Split(',');
                Karakter karakter = new Karakter(adatok[0], int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3]));
                karakterek.Add(karakter);
            }
            return karakterek;
        }
        public static void legjobbHarom(List<Karakter> karakterek)
        {
            var topHarom = karakterek.OrderByDescending(k => k.Szint + k.Ero).Take(3).ToList();
            Console.WriteLine("\nA legjobb három karakter:");
            foreach (var karakter in topHarom)
            {
                Console.WriteLine($"Név: {karakter.Nev}, Szint: {karakter.Szint}, Erő: {karakter.Ero}");
            }
        }

        public class KarakterStats
        {
            private List<Karakter> karakterek;

            public KarakterStats(List<Karakter> karakterek)
            {
                this.karakterek = karakterek;
            }

            public List<Karakter> szint()
            {
                return karakterek.Where(k => k.Szint > 8).ToList();
            }
        }

        public class KarakterRangsorolas
        {
            private List<Karakter> karakterek;

            public KarakterRangsorolas(List<Karakter> karakterek)
            {
                this.karakterek = karakterek;
            }

            public void Rangsorol()
            {
                var rangsorolt = karakterek.OrderByDescending(k => k.Eletero + k.Ero).ToList();
                Console.WriteLine("\nRangsorolt karakterek életerő és erő alapján:");
                foreach (var karakter in rangsorolt)
                {
                    Console.WriteLine($"Név: {karakter.Nev}, Szint: {karakter.Szint}, Életerő: {karakter.Eletero}, Erő: {karakter.Ero}");
                }
            }
        }
    }

}
