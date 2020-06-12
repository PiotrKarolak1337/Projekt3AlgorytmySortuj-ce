using System;
using System.Numerics;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp8
{
    class Program
    {
        static int[] TabLos(int rozmiar)
        {
            int[] tab = new int[rozmiar];

            for (int i = 0; i < rozmiar; i++)
            {
                tab[i] = Losuj();               

            }           
            return (tab); // zwraca tablicę
        }
        static int Losuj()
        {
            Random r = new Random();
            return r.Next(0, 100);
        }


        public static int[] TabVShape(int rozmiar)
        {

            int[] tab = new int[rozmiar];

            int count = 0;

            for (int i = rozmiar / 2; i > 0; i--)
            {
                tab[count++] = i;
            }

            for (int i = 0; i < rozmiar / 2; i++)
            {
                tab[count++] = i;
            }
            return (tab);
        }
        private static int[] TabRos(int rozmiar)
        {
            int count = 0;
            int[] tab = new int[rozmiar];

            for (int i = 0; i < rozmiar; i++)
            {
                tab[count++] = i;
            }

            return (tab);
        }
        private static int[] TabMal(int rozmiar)
        {
            int count = 0;
            int[] tab = new int[rozmiar];
            for (int i = rozmiar; i > 0; i--)
            {
                tab[count++] = i;
            }
            return (tab);

        }
        private static int[] TabStala(int rozmiar)
        {
            int count = 0;
            int[] tab = new int[rozmiar];

            for (int i = 0; i < rozmiar; i++)
            {
                tab[count++] = 0;
            }

            return (tab);
        }
        static int[] InsertionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;

                    }

                }
            }

            return inputArray;
        }
        static int[] SelectionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min_idx])
                        min_idx = j;
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
            return (arr);
        }

        static int[] CocktailSort(int[] a)
        {
            bool swapped = true;
            int start = 0;
            int end = a.Length;

            while (swapped == true)
            {

                swapped = false;

                for (int i = start; i < end - 1; ++i)
                {
                    if (a[i] > a[i + 1])
                    {
                        int temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                        swapped = true;
                    }
                }

                if (swapped == false)
                    break;

                swapped = false;

                end = end - 1;

                for (int i = end - 1; i >= start; i--)
                {
                    if (a[i] > a[i + 1])
                    {
                        int temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                        swapped = true;
                    }
                }
                start = start + 1;
            }
            return (a);
        }

        private static int[] HeapSort(int[] tab)
        {
            int left = tab.Length / 2;
            int right = tab.Length - 1;
            while (left > 0)
            {
                left--;
                Heapify(ref tab, left, right);
            }

            while (right > 0)
            {
                int temp = tab[left];
                tab[left] = tab[right];
                tab[right] = temp;
                right--;
                Heapify(ref tab, left, right);
            }
            return tab;
        }

        private static int[] Heapify(ref int[] tab, int left, int right)
        {
            int i = left,
                j = 2 * i + 1;
            int temp = tab[i];
            while (j <= right)
            {
                if (j < right)
                    if (tab[j] < tab[j + 1])
                        j++;
                if (temp >= tab[j]) break;
                tab[i] = tab[j];
                i = j;
                j = 2 * i + 1;
            }

            tab[i] = temp;
            return tab;
        }
        static void AddToFile(string type, BigInteger zapis)
        {
            string path = @"dane.txt";

            if (!File.Exists(path))
            {
                //Tworzenie pliku
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"{type}, {zapis}");
                }
            }

            //Wypełnianie pliku danymi
            using (StreamWriter sw = File.AppendText(path))
            {

                sw.WriteLine($"{type},{zapis}");
            }
        }
        static void Main(string[] args)
        {


            
            for (int j = 50_000; j < 200_000; j +=5_000)
                {                                    
                    Stopwatch stoper = new Stopwatch();
                    stoper.Reset();
                    stoper.Start();
                    int[] tab11 = InsertionSort(TabLos(j));//Tablica nr 1 po InsertionSort
                    stoper.Stop();
                    BigInteger czasWykonania = stoper.ElapsedTicks;
                    AddToFile("Zliczanie czasu InsertionSort Losowa", czasWykonania);
                    Console.WriteLine(j);
                }
               
            for (int j = 50_000; j < 200_000; j +=5000)
                {
                    Stopwatch stoper = new Stopwatch();
                    stoper.Reset();
                    stoper.Start();
                    int[] tab22 = InsertionSort(TabVShape(j));//Tablica nr 2 po InsertionSort 
                    BigInteger czasWykonania = stoper.ElapsedTicks;
                    AddToFile("Zliczanie czasu InsertionSort VShape", czasWykonania);
                    Console.WriteLine(j);
                }
                            
            for (int j = 50_000; j < 200_000; j += 5_000)
                {
                    
                    Stopwatch stoper = new Stopwatch();
                    stoper.Reset();
                    stoper.Start();
                    int[] tab33 = InsertionSort(TabRos(j));//Tablica nr 3 po InsertionSort
                    BigInteger czasWykonania = stoper.ElapsedTicks;
                    AddToFile("Zliczanie czasu InsertionSort TabRos", czasWykonania);
                    Console.WriteLine(j);
            }

            for (int j = 50_000; j < 200_000; j += 5_000)
                {
                    Stopwatch stoper = new Stopwatch();
                    stoper.Reset();
                    stoper.Start();
                    int[] tab44 = InsertionSort(TabMal(j));//Tablica nr 4 po InsertionSort
                    BigInteger czasWykonania = stoper.ElapsedTicks;
                    AddToFile("Zliczanie czasu InsertionSort TabMal", czasWykonania);
                    Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
                {
                    Stopwatch stoper = new Stopwatch();
                    stoper.Reset();
                    stoper.Start();
                    int[] tab55 = InsertionSort(TabStala(j));//Tablica nr 5 po InsertionSort
                    BigInteger czasWykonania = stoper.ElapsedTicks;
                    AddToFile("Zliczanie czasu InsertionSort TabStala", czasWykonania);
                    Console.WriteLine(j);
            }
            Console.WriteLine("Koniec InsertionSort");
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = SelectionSort(TabLos(j));//Tablica nr 1 po SelectionSort
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu SelectionSort TabLos", czasWykonania);
                Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = SelectionSort(TabVShape(j));//Tablica nr 2 po SelectionSort
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu SelectionSort TabVShape", czasWykonania);
                Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = SelectionSort(TabRos(j));//Tablica nr 3 po SelectionSort
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu SelectionSort TabRos", czasWykonania);
                Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = SelectionSort(TabMal(j));//Tablica nr 4 po SelectionSort
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu SelectionSort TabMal", czasWykonania);
                Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = SelectionSort(TabStala(j));//Tablica nr 5 po SelectionSort
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu SelectionSort TabStala", czasWykonania);
                Console.WriteLine(j);
            }
            Console.WriteLine("Koniec SelectionSort");
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = HeapSort(TabLos(j));//Tablica nr 1 po HeapSort
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu HeapSort TabLos", czasWykonania);
                Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = HeapSort(TabVShape(j));//Tablica nr 2 po HeapSort
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu HeapSort TabVShape", czasWykonania);
                Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = HeapSort(TabRos(j));//Tablica nr 3 po HeapSort
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu HeapSort TabRos", czasWykonania);
                Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = HeapSort(TabMal(j));//Tablica nr 4 po HeapSort
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu HeapSort TabMal", czasWykonania);
                Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = HeapSort(TabStala(j));//Tablica nr 5 po HeapSort
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu HeapSort TabStala", czasWykonania);
                Console.WriteLine(j);
            }
            Console.WriteLine("Koniec HeapSort");
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = CocktailSort(TabLos(j));//Tablica nr 1 po Cocktail
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu Cocktail TabLos", czasWykonania);
                Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = CocktailSort(TabVShape(j));//Tablica nr 2 po Cocktail
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu Cocktail TabVShape", czasWykonania);
                Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = CocktailSort(TabRos(j));//Tablica nr 3 po Cocktail
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu Cocktail TabRos", czasWykonania);
                Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = CocktailSort(TabMal(j));//Tablica nr 4 po Cocktail
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu Cocktail TabMal", czasWykonania);
                Console.WriteLine(j);
            }
            for (int j = 50_000; j < 200_000; j += 5_000)
            {
                Stopwatch stoper = new Stopwatch();
                stoper.Reset();
                stoper.Start();
                int[] tab111 = CocktailSort(TabStala(j));//Tablica nr 5 po Cocktail
                BigInteger czasWykonania = stoper.ElapsedTicks;
                AddToFile("Zliczanie czasu Cocktail TabStala", czasWykonania);
                Console.WriteLine(j);
            }
            Console.WriteLine("Koniec Cocktail");
            Console.WriteLine("Koniec");
            Console.ReadKey();
        }
    }
}
