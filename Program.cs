using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lottoPataky
{
    class Lotto
    {
        //89 24 34 11 64
        public string lottoszamokSor { get; set; }
        public int Sor { get; set; }
        public int[,] lottoszamok { get; set; }
        public Lotto(string lottoszamokSor, int sor, int[,] lottoszamok)
        {
            this.lottoszamokSor = lottoszamokSor;
            this.Sor = sor;
            this.lottoszamok = lottoszamok;
        }
    }
    class Program
    {
        static List<Lotto> Adat = new List<Lotto>();
        static Lotto lotto;
        static string megadottHet { get; set; }
        static int megadottSzam { get; set; }
        static string rendezett { get; set; }
        static void Main(string[] args)
        {
            F1();
            F2();
            F3();
            F4();
            F5();
            F6();
            F7();
            Console.ReadKey();
        }

        private static void F7()
        {
            StreamWriter ki = new StreamWriter(@"lotto52.txt");
            for (int i = 0; i < Adat.Count; i++)
            {
                ki.WriteLine(Adat[i].lottoszamokSor);
                ki.Flush();
            }
            ki.WriteLine(rendezett);
            ki.Flush();
            ki.Close();
        }

        private static void F6()
        {
            int paratlanSzamok = 0;
            for (int sor = 0; sor < lotto.lottoszamok.GetLength(0); sor++)
            {
                for (int oszlop = 0; oszlop < lotto.lottoszamok.GetLength(1); oszlop++)
                {
                    if (lotto.lottoszamok[sor, oszlop] % 2 != 0)
                        paratlanSzamok++;
                }
            }
            Console.WriteLine($"\n6. feladat: {paratlanSzamok}x volt páratlan szám!");
        }

        private static void F5()
        {
            int mennyi = 0;
            int[] szamok = new int[91];
            for (int sor = 0; sor < lotto.lottoszamok.GetLength(0); sor++)
            {
                for (int oszlop = 0; oszlop < lotto.lottoszamok.GetLength(1); oszlop++)
                {
                    if (lotto.lottoszamok[sor, oszlop] != 0)
                    {
                        szamok[lotto.lottoszamok[sor, oszlop]]++;
                    }
                }
            }
            for (int i = 0; i < 91; i++)
            {
                if (szamok[i] == 0)
                    mennyi++;
            }
            string isVolt = (mennyi >= 1) ? "\n5. feladat: Minden számot kihúztak!" : "\n5. feladat: Volt olyan szám, amit nem húztak ki!";
            Console.WriteLine(isVolt);
        }

        private static void F4() => Console.WriteLine($"\n4. feladat: {megadottSzam}. heti lottószámok: {Adat.Where(x => x.Sor == megadottSzam).Select(x => x.lottoszamokSor).First()}");

        public static void F3()
        {
            int sor = 0;
            int[,] matrix = new int[52, 5];
            using (StreamReader olvas = new StreamReader(@"lottosz.txt"))
            {
                while (!olvas.EndOfStream)
                {
                    sor++;
                    string lottoszamokSor = olvas.ReadLine();
                    string[] split = lottoszamokSor.Split(' ');
                    for (int i = 0; i < 5; i++)
                    {
                        matrix[sor, i] = Convert.ToInt32(split[i]);
                    }
                    lotto = new Lotto(lottoszamokSor, sor, matrix);
                    Adat.Add(lotto);
                }
            }
            Console.Write("\n3. feladat: Kérem adjon meg egy számot 1-51 között: ");
            megadottSzam = Convert.ToInt32(Console.ReadLine());
        }

        public static void F2()
        {
            string[] lottoszamok = megadottHet.Trim().Split().OrderByDescending(x => x).ToArray();
            string rendez = "";
            for (int i = 0; i < lottoszamok.Length; i++)
            {
                rendez += String.Concat(" ", lottoszamok[i]);
            }
            rendezett = rendez.Substring(1, rendez.Length - 1);
            Console.WriteLine($"\n2. feladat: Rendezett formában: {rendezett}");
        }

        public static void F1()
        {
            Console.Write("1. feladat: Kérem adja meg az 52. heti lottószámokat: ");
            megadottHet = Console.ReadLine();
        } 
    }
}
