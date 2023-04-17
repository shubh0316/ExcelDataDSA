using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace ExcelDataDSA.DataStructures
{
    internal class MyArray<T> where T : IComparable<T>
    {
        private T[] array;
        public T this[int i]
        {
            get
            {
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
        public MyArray(int n)
        {
            array = new T[n];
        }
        public MyArray(IEnumerable<T> data)
        {
            int n = data.Count();
            array = new T[n];
            int i = 0;
            foreach (var item in data)
            {
                array[i++] = item;
            }
        }
        private static MyArray<Person> CopyData(MyArray<Person> myarray)
        {
            var temp = new MyArray<Person>(myarray.Count);
            for (int i = 0; i < myarray.Count; i++)
            {
                temp[i] = myarray[i];
            }
            return temp;
        }
        private static void Swap(T[] array, int first, int second)
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
        public static void SelectionSort(T[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j].CompareTo(arr[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    T temp = arr[minIndex];
                    arr[minIndex] = arr[i];
                    arr[i] = temp;
                }
            }
        }
        private static void BubbleSort(T[] array, out TimeSpan timeTaken)
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
        private static void InsertionSort(T[] array, out TimeSpan timeTaken)
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
        private static void MergeSort(T[] array, out TimeSpan timeTaken)
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
        private static void QuickSort(T[] array, out TimeSpan timeTaken)
        {
            int n = array.Length;
            Stopwatch sw = Stopwatch.StartNew();

            QuickSort(array, 0, n - 1);

            sw.Stop();
            timeTaken = sw.Elapsed;
        }
   
        public static void Sorting()
        {
           
            var data = FetchData.GetData();
            Stopwatch sw = Stopwatch.StartNew();
            MyArray<Person> objarray = new MyArray<Person>(data);
            sw.Stop();
            Console.Write("\nTime Taken in loading: " + sw.ElapsedMilliseconds + " MilliSeconds\n");
            MyArray<Person> objSelection = CopyData(objarray);
            Console.WriteLine("Insertion Sort Started..");
            MyArray<Person>.InsertionSort(objSelection.objectOfArray, out TimeSpan timeInsertion);
            Console.WriteLine("The time for Insertion sort in array : " + timeInsertion.TotalSeconds + "seconds");

            MyArray<Person> objInsertion = CopyData(objarray);
            sw.Restart();
            Console.WriteLine("Selection Sort Started..");
            MyArray<Person>.SelectionSort(objInsertion.objectOfArray);
            sw.Stop();
            TimeSpan timeSelection = sw.Elapsed;
            Console.WriteLine("The time for selection sort in array: " + timeSelection.TotalSeconds + "seconds");
         
            MyArray<Person> ObjQuick = CopyData(objarray);
            Console.WriteLine("Quick sort Started..");
            Stopwatch stopwatch1 = Stopwatch.StartNew();
            MyArray<Person>.QuickSort(ObjQuick.objectOfArray, out TimeSpan timeOne);
            stopwatch1.Stop();
            Console.WriteLine("The time for Quick sort : " + timeOne.TotalSeconds + "seconds");

            MyArray<Person> arr2 = CopyData(objarray);
            Console.WriteLine("Merge sort Started..");
            Stopwatch stopwatch2 = Stopwatch.StartNew();
            MyArray<Person>.MergeSort(arr2.objectOfArray, out TimeSpan timeTwo);
            stopwatch2.Stop();
            Console.WriteLine("The time for Merge sort in array: " + timeTwo.TotalSeconds + "seconds");

            MyArray<Person> arr = CopyData(objarray);
            Console.WriteLine("Bubble sort Started..");
            Stopwatch stop1 = Stopwatch.StartNew();
            MyArray<Person>.BubbleSort(arr.objectOfArray, out TimeSpan time);
            stop1.Stop();
            Console.WriteLine("The time for Bubble sort in array : " + time.TotalSeconds + "seconds");
        }
    }
}


         
