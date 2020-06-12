using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;

namespace Quick_Sort
{
    class Program
    {
        static void QsortItera(int[] t)
        {
            int i, j, l, p, sp;
            int[] stos_l = new int[t.Length],
            stos_p = new int[t.Length]; 
            sp = 0; stos_l[sp] = 0; stos_p[sp] = t.Length - 1; 
            do
            {
                l = stos_l[sp]; p = stos_p[sp]; sp--; 
                do
                {
                    int x;
                    i = l; j = p; x = t[(l + p) / 2]; 
                    do
                    {
                        while (t[i] < x) i++;
                        while (x < t[j]) j--;
                        if (i <= j)
                        {
                            int buf = t[i]; t[i] = t[j]; t[j] = buf;
                            i++; j--;
                        }
                    } while (i <= j);
                    if (i < p) { sp++; stos_l[sp] = i; stos_p[sp] = p; } 
                    p = j;
                } while (l < p);
            } while (sp >= 0); 
        }
        static int[] TabLos(int rozmiar)
        {
            int[] tab = new int[rozmiar];

            for (int i = 0; i < rozmiar; i++)
            {
                tab[i] = Losuj();
                

            }
            
            return (tab); 
        }
        static int Losuj()
        {
            Random r = new Random();
            return r.Next(0, 100);
        }

        static void AddToFile(string type, BigInteger zapis)
        {
            string path = @"dane.txt";

            if (!File.Exists(path))
            {
                
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"{type}, {zapis}");
                }
            }

            
            using (StreamWriter sw = File.AppendText(path))
            {

                sw.WriteLine($"{type},{zapis}");
            }
        }
        static void QsortReku(int[] t, int l, int p)
        {
            int i, j, x;
            i = l;
            j = p;
            x = t[(l + p) / 2]; 
            do
            {
                while (t[i] < x) i++; 
                while (x < t[j]) j--; 
                if (i <= j) 
                { 
                    int buf = t[i]; t[i] = t[j]; t[j] = buf;
                    i++; j--;
                }
            }
            while (i <= j);
            if (l < j) QsortReku(t, l, j); 
            if (i < p) QsortReku(t, i, p); 
        }
        static int[] TabAShape(int size)
        {
            int constant = size / 2;
            int[] table = new int[size];
            for (int i = 0; i < table.Length; i++)
            {
                if (i < table.Length / 2)
                {
                    table[i] = i;
                }
                else
                {
                    table[i] = table.Length - 1 - i;

                }
                
            }
            return table;
        }
        static void QuickSortIterativeMid(int[] tab)
        {
            int i, j, l, r, sp;
            int[] stackLeft = new int[tab.Length],
                stackRight = new int[tab.Length];
            sp = 0;
            stackLeft[sp] = 0;
            stackRight[sp] = tab.Length - 1;

            do
            {
                l = stackLeft[sp];
                r = stackRight[sp];
                sp--;

                do
                {
                    int x;
                    i = l;
                    j = r;
                    x = tab[(l + r) / 2];

                    do
                    {
                        while (tab[i] < x) i++;
                        while (x < tab[j]) j--;
                        if (i <= j)
                        {
                            int buf = tab[i];
                            tab[i] = tab[j];
                            tab[j] = buf;
                            i++;
                            j--;
                        }
                    } while (i <= j);

                    if (i < r)
                    {
                        sp++;
                        stackLeft[sp] = i;
                        stackRight[sp] = r;
                    }

                    r = j;
                } while (l < r);
            } while (sp >= 0);
        }
        static void QuickSortIterativeRight(int[] tab)
        {
            int i, j, l, r, sp;
            int[] stackLeft = new int[tab.Length],
                stackRight = new int[tab.Length];
            sp = 0;
            stackLeft[sp] = 0;
            stackRight[sp] = tab.Length - 1;

            do
            {
                l = stackLeft[sp];
                r = stackRight[sp];
                sp--;

                do
                {
                    int x;
                    i = l;
                    j = r;

                    x = tab[(r)];

                    do
                    {
                        while (tab[i] < x) i++;
                        while (x < tab[j]) j--;
                        if (i <= j)
                        {
                            int buf = tab[i];
                            tab[i] = tab[j];
                            tab[j] = buf;
                            i++;
                            j--;
                        }
                    } while (i <= j);

                    if (i < r)
                    {
                        sp++;
                        stackLeft[sp] = i;
                        stackRight[sp] = r;
                    }

                    r = j;
                } while (l < r);
            } while (sp >= 0);
        }
        static void QuickSortIterativeRandom(int[] tab)
        {
            
            Random random = new Random();
            int i, j, l, r, sp;
            int[] stackLeft = new int[tab.Length],
                stackRight = new int[tab.Length];
            sp = 0;
            stackLeft[sp] = 0;
            stackRight[sp] = tab.Length - 1;

            do
            {
                l = stackLeft[sp];
                r = stackRight[sp];
                sp--;

                do
                {
                    int x;
                    i = l;
                    j = r;
                    
                    x = tab[random.Next(0, tab.Length -1)];

                    do
                    {
                        while (tab[i] < x) i++;
                        while (x < tab[j]) j--;
                        if (i <= j)
                        {
                            int buf = tab[i];
                            tab[i] = tab[j];
                            tab[j] = buf;
                            i++;
                            j--;
                            
                        }
                    } while (i <= j);

                    if (i < r)
                    {
                        sp++;
                        stackLeft[sp] = i;
                        stackRight[sp] = r;
                    }

                    r = j;
                } while (l < r);
            } while (sp >= 0);
            Console.WriteLine("coś");
        }
        static void Tester()
        {
            for (int j = 130_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] arr = TabAShape(j);
                QsortReku(arr, 0, arr.Length - 1);
                stoper.Stop();
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu rekurencyjna AShape", czasWykonania);
                Console.WriteLine(j);
            }
            

            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] arr = TabAShape(j);
                QuickSortIterativeMid(arr);
                stoper.Stop();
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu rekurencyjna środkowa", czasWykonania);
                Console.WriteLine(j);
            }
            for(int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] arr = TabAShape(j);
                QuickSortIterativeRight(arr);
                stoper.Stop();
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu rekurencyjna prawa", czasWykonania);
                Console.WriteLine(j);
            }
            
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] arr = TabAShape(j);
                QuickSortIterativeRandom(arr);
                stoper.Stop();
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu rekurencyjna randomowa", czasWykonania);
                Console.WriteLine(j);
            }
        }
        static void Main(string[] args)
        {
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] arr = TabLos(j);
                QsortItera(arr);
                stoper.Stop();
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu iteracyjna losowa tab", czasWykonania);
                Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] arr = TabLos(j);
                QsortReku(arr,0,arr.Length -1);
                stoper.Stop();
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu rekurencyjna VShape", czasWykonania);
                Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] arr = TabAShape(j);
                QsortItera(arr);
                stoper.Stop();
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu iteracyjna AShape", czasWykonania);
                Console.WriteLine(j);
            }
            
            Thread TesterThread = new Thread(Program.Tester, 8 * 1024 * 1024); 
            TesterThread.Start(); 
            TesterThread.Join(); 





            Console.WriteLine();
        }
    }
}