using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace ExcelDataDSA.DataStructures
{
    internal class GetArray<T> where T : IComparable<T>
    {
        private T[] array;
        public T this[int i]
        {
            get
            {
                if (i < 0 && i >= Count);
                return array[i];
            }
            set
            {
                array[i] = value;
            }
        }

        public T[] objectOfArray { get { return array ; } }
        public int Count
        {
            get { return array.Length; }
        }

        public GetArray(int n)
        {
            array = new T[n];
        }
        public GetArray(IEnumerable<T> data)
        {
            int n = data.Count();
            array = new T[n];
            int i = 0;
            foreach (var item in data)
            {
                array[i++] = item;
            }

        }
        private static GetArray<Person> CopyData(GetArray<Person> array)
        {
            var temp = new GetArray<Person>(array.Count);
            for (int i = 0; i < array.Count; i++)
            {
                temp[i] = array[i];
            }
            return temp;
        }

        public static void Swap(T[] array, int first, int second)
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
        public static void BubbleSort(T[] array, out TimeSpan timeTaken)
        {
            int n = array.Length;
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) <= 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }



            sw.Stop();
            timeTaken = sw.Elapsed;

        }
        public static void InsertionSort(T[] array, out TimeSpan timeTaken)
        {
            int n = array.Length;
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < n; i++)
            {
                var key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j].CompareTo(key) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }

            sw.Stop();
            timeTaken = sw.Elapsed;
        }
        private static void Merge(T[] array, int first, int middle, int last)
        {
            int i, j, k;
            int n1 = middle - first + 1;
            int n2 = last - middle;

            T[] L = new T[n1], R = new T[n2];

            for (i = 0; i < n1; i++)
                L[i] = array[first + i];
            for (j = 0; j < n2; j++)
                R[j] = array[middle + 1 + j];

            i = 0;
            j = 0;
            k = first;
            while (i < n1 && j < n2)
            {
                if (L[i].CompareTo(R[j]) <= 0)
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                array[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = R[j];
                j++;
                k++;
            }
        }
        private static void MergeSort(T[] array, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSort(array, l, m);
                MergeSort(array, m + 1, r);

                Merge(array, l, m, r);
            }
        }
        public static void MergeSort(T[] array, out TimeSpan timeTaken)
        {
            int n = array.Length;
            Stopwatch sw = Stopwatch.StartNew();

            MergeSort(array, 0, n - 1);

            sw.Stop();
            timeTaken = sw.Elapsed;
        }
  
        private static int Partition(T[] array, int low, int high)
        {
            var pivot = array[high];
            int i = (low - 1);

            for (int j = low; j <= high - 1; j++)
            {
                if (array[j].CompareTo(pivot) < 0)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, high);
            return (i + 1);
        }
        private static void QuickSort(T[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);
                QuickSort(array, low, pi - 1);
                QuickSort(array, pi + 1, high);
            }
        }
        public static void QuickSort(T[] array, out TimeSpan timeTaken)
        {
            int n = array.Length;
            Stopwatch sw = Stopwatch.StartNew();

            QuickSort(array, 0, n - 1);

            sw.Stop();
            timeTaken = sw.Elapsed;
        }
    /*    public static void QuickSortAlgorithm()
        {
            var result = FetchData.GetData();
            Stopwatch sw = Stopwatch.StartNew();

            GetArray<Person> array = new GetArray<Person>(result);
            sw.Stop();
            Console.WriteLine("Time taken total:{0}", sw.ElapsedMilliseconds);
            GetArray<Person> arr = CopyData(array);
            GetArray<Person>.QuickSort(arr.objectOfArray, out TimeSpan time);
            Console.WriteLine("bubble sort time: {0}", time.TotalSeconds);


        }*/
        public static void sorting()
        {
            var data = FetchData.GetData();
            Stopwatch sw = Stopwatch.StartNew();
            Console.Write("Binding records in array please wait...");
            GetArray<Person> array = new GetArray<Person>(data);
            sw.Stop();
            Console.Write("\nTime Taken in loading: " + sw.ElapsedMilliseconds);
            Console.ReadKey();
            Console.Clear();

            sw.Restart();
            GetArray<Person> arr3 = CopyData(array);
            Console.WriteLine("Insertion Sort Started..");
            GetArray<Person>.QuickSort(arr3.objectOfArray, out TimeSpan time3);
            sw.Stop();
            Console.WriteLine("Insertion sort Completed : " + time3.TotalSeconds + "seconds");
            Console.ReadKey();

            sw.Restart();
            GetArray<Person> arr2 = CopyData(array);
            Console.WriteLine("Merge sort Started..");
            GetArray<Person>.QuickSort(arr2.objectOfArray, out TimeSpan time2);
            sw.Stop();
            Console.WriteLine("Merge sort Completed : " + time2.TotalSeconds + "seconds");
            Console.ReadKey();

            sw.Restart();
            GetArray<Person> arr1 = CopyData(array);
            Console.WriteLine("Quick sort Started..");
            GetArray<Person>.MergeSort(arr1.objectOfArray, out TimeSpan time1);
            sw.Stop();
            Console.WriteLine("Quick sort Completed : " + time1.TotalSeconds+ "seconds");
            Console.ReadKey();

            sw.Restart();
            GetArray<Person> arr = CopyData(array);
            Console.WriteLine("Bubble sort Started..");      
            GetArray<Person>.BubbleSort(arr.objectOfArray, out TimeSpan time);
            sw.Stop();
            Console.WriteLine("Bubble sort Completed : " + time.TotalMilliseconds + "seconds");
        }




        //IEnumerable<Person> result = FetchData.GetData();
        /*     public static void BubbleSort<T>(T[] arr, Comparison<T> comparison)
             {
                 Stopwatch sw = Stopwatch.StartNew();
                 int n = arr.Length;
                 for (int i = 0; i < n - 1; i++)
                 {
                     for (int j = 0; j < n - i - 1; j++)
                     {
                         if (comparison(arr[j], arr[j + 1]) > 0)
                         {
                             T temp = arr[j];
                             arr[j] = arr[j + 1];
                             arr[j + 1] = temp;
                         }
                     }
                 }
             }*/
        /*   public static void InsertionSort<T>(T[] arr, Comparison<T> comparison)
           {
               int n = arr.Length;
               for (int i = 1; i < n; i++)
               {
                   T key = arr[i];
                   int j = i - 1;

                   while (j >= 0 && comparison(arr[j], key) > 0)
                   {
                       arr[j + 1] = arr[j];
                       j--;
                   }

                   arr[j + 1] = key;
               }
           }*/


        /*   public void SortFunction()
           {
               Comparison<Person> compareByAge = (p1, p2) => p1.Age.CompareTo(p2.Age);
               Person[] AllData = result.Select(row => row).ToArray();
               Console.WriteLine("enter sorting here....");
               var input = Console.ReadLine();
               if (input == "Bubble")
               {
                   BubbleSort(AllData, compareByAge);
                   Console.WriteLine("sdsdgf");
                   foreach (var items in AllData)
                   {

                       Console.WriteLine($"\t\t\tId:{items.Id}\n\t\t\tName:{items.Name}\n\t\t\tAge:{items.Age}\n\t\t\tCity:{items.City}\n\t\t\tState:{items.State}\n\n\n");
                   }
               }
               else if (input == "insertion")
               {
                   InsertionSort(AllData, compareByAge);
                   foreach (var items in AllData)
                   {
                       Console.WriteLine($"\t\t\tId:{items.Id}\n\t\t\tName:{items.Name}\n\t\t\tAge:{items.Age}\n\t\t\tCity:{items.City}\n\t\t\tState:{items.State}\n\n\n");

                   }
               }
           }*/
    }
}


         
