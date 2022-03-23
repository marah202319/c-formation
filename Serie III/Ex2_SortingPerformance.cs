using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_III
{
    public struct SortData
    {
        /// <summary>
        /// Moyenne pour le tri par insertion
        /// </summary>
        public long InsertionMean { get; set; }
        /// <summary>
        /// Écart-type pour le tri par insertion
        /// </summary>
        public long InsertionStd { get; set; }
        /// <summary>
        /// Moyenne pour le tri rapide
        /// </summary>
        public long QuickMean { get; set; }
        /// <summary>
        /// Écart-type pour le tri rapide
        /// </summary>
        public long QuickStd { get; set; }
    }

    public static class SortingPerformance
    {
        public static void DisplayPerformances(List<int> sizes, int count)
        {
            Console.WriteLine("n ;MeanInsertion ;StdInsertion ;MeanQuick ;StdQuick");
            List<SortData> list = PerformancesTest(sizes, count);
            for(int i = 0; i < sizes.Count; i++)
            {
               // Console.WriteLine(list[i].InsertionMean + ";"+list[i].InsertionStd+';'+list[i].QuickMean+';'+list[i].QuickStd);
                Console.WriteLine($"{sizes[i]};{list[i].InsertionMean};{list[i].InsertionStd};{list[i].QuickMean};{list[i].QuickStd}");
            }
        }

        public static List<SortData> PerformancesTest(List<int> sizes, int count)
        {
            var l1 = new List<SortData>();
            for (int i = 0; i < sizes.Count(); i++)
            {
                l1.Add(PerformanceTest(sizes[i], count));
            }
            return l1;
        }

        public static SortData PerformanceTest(int size, int count)
        {
            SortData s = new SortData();
            long sumInsertion = 0;
            long sumQuick = 0;
            double stdInsertion = 0;
            double stdQuick = 0;

            for (int i = 0; i < count; i++)
            {
                List<int[]> l1 = ArraysGenerator(size);

                sumInsertion += UseInsertionSort(l1[0]);
                sumQuick += UseQuickSort(l1[1]);
            }
            s.InsertionMean = sumInsertion / count;
            s.QuickMean = sumQuick / count;
            stdInsertion = (sumInsertion * sumInsertion / count) - (s.InsertionMean * s.InsertionMean);
            stdQuick = (sumQuick * sumQuick / count) - (s.QuickMean * s.QuickMean);
            s.InsertionStd = (long)(Math.Sqrt(stdInsertion));
            s.QuickStd = (long)(Math.Sqrt(stdQuick));

            return s;
        }

        private static List<int[]> ArraysGenerator(int size)
        {
            List<int[]> l1 = new List<int[]>();
            int[] i1 = new int[size];
            int[] i2 = new int[size];
            Random randNum = new Random();

            for (int i = 0; i < size; i++)
            {
                int rand = randNum.Next(-1000, 1000);
                i1[i] = rand;
                i2[i] = rand;

            }
            l1.Add(i1);
            l1.Add(i2);
            return l1;
        }

        public static long UseInsertionSort(int[] array)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            InsertionSort(array);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static long UseQuickSort(int[] array)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            QuickSort(array, 0, array.Length - 1);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private static void InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int tmp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = tmp;
                    }
                }
            };
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);
                QuickSort(array, left, pivot - 1);
                QuickSort(array, pivot + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right) 
        {
            int pivot = array[right];
            int i = left;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                }
            }
            int tmp = array[i];
            array[i] = array[right];
            array[right] = tmp;
            return i;
        }
    }
}
