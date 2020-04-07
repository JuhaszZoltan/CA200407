using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200407
{
    struct Jatekos
    {
        public string Nev;
        public int[] Tippek;
    }
    class Program
    {
        static List<Jatekos> jatekosok;
        static int fi = 0;
        static int fsz;
        static void Main(string[] args)
        {
            F02();
            F03();
            F04();
            F05();
            F06();
            F07();
            Console.ReadKey();
        }

        private static void F07()
        {
            Console.Write("7. feladat: ");
            Console.Write($"Kérem a forduló sorszámát [1 - {fsz}]: ");
            int input = int.Parse(Console.ReadLine());

            if(input <= fsz && input >= 1) fi = input - 1;

        }

        private static void F06()
        {
            Console.Write("6. feladat: ");
            int maxv = int.MinValue;

            foreach (var j in jatekosok)
            {
                foreach (var t in j.Tippek)
                {
                    if (t > maxv) maxv = t;
                }
            }

            Console.WriteLine($"Legnagyobb tipp a fordulók során: {maxv}");
        }

        private static void F05()
        {
            Console.Write("5. feladat: ");
            int i = 0;
            while (i < jatekosok.Count && jatekosok[i].Tippek[0] != 1)
            {
                i++;
            }
            if (i < jatekosok.Count) Console.WriteLine("Az első fordulóban VOLT 1-es tipp!");
            else Console.WriteLine("Az első fordulóban NEM volt 1-es tipp!");
        }

        private static void F04()
        {
            Console.Write("4. feladat: ");
            fsz = jatekosok[0].Tippek.Length;
            Console.WriteLine($"Fordulók száma: {fsz}");
        }

        private static void F03()
        {
            Console.Write("3. feladat: ");
            Console.WriteLine($"játékosok: {jatekosok.Count}");
        }

        private static void F02()
        {
            jatekosok = new List<Jatekos>();

            var sr = new StreamReader(@"..\..\Res\egyszamjatek.txt", Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                var t = sr.ReadLine().Split(' ');

                var j = new Jatekos() 
                { 
                    Nev = t[t.Length - 1],
                    Tippek = new int[t.Length - 1],
                };

                for (int i = 0; i < t.Length - 1; i++)
                    j.Tippek[i] = int.Parse(t[i]);

                jatekosok.Add(j);
            }
        }
    }
}
