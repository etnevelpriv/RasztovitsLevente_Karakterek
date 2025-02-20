namespace _02._20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Karakter> karakterek = new List<Karakter>();
            string[] sorok = File.ReadAllLines("karakterek.txt");
            foreach (string sor in sorok.Skip(1))
            {
                string[] adatok = sor.Split(';');
                Karakter karakter = new Karakter(adatok[0], int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3]));
                karakterek.Add(karakter);
            }

            Karakter legnagyobbEletero = karakterek[0];
            for (int i = 1; i < karakterek.Count; i++)
            {
                if (karakterek[i].Eletero > legnagyobbEletero.Eletero)
                {
                    legnagyobbEletero = karakterek[i];
                }
            }
            Console.WriteLine($"A legnagyobb életerővel rendelkező karakter neve: {legnagyobbEletero.Nev}, szintje: {legnagyobbEletero.Szint}, életereje: {legnagyobbEletero.Eletero}");
            
            Karakter.atlagSzint(karakterek);
            
            Karakter.rendezesEro(karakterek);
            
            Console.Write($"{karakterek[20].Nev} ereje nagyobb mint 50? A válasz: ");
            Console.WriteLine(karakterek[20].eroNagyobbMint(50) ? "Igen" : "Nem");
        }
    }
}
