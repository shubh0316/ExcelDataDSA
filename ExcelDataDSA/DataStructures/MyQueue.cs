using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ExcelDataDSA.DataStructures
{
    internal class MyQueue<T> where T : IComparable<T>
    {
        private T[] _items;
        private int _head;
        private int _tail;
        private int _size;
        public int Count
        {
            get; private set;

        }
        public MyQueue()
        {
            _size = 20;
            _items= new T[_size];
            _head = 0;
            _tail = -1;
            Count= 0;
        }
        public MyQueue(IEnumerable<T> data)
        {
            _size = data.Count();
            _items = new T[_size];
            _head = 0;
            _tail = -1;
            foreach (T item in data)
            {
                Enqueue(item);
            }
        }
        public void Enqueue(T rec)
        {
            {
                if (_tail == _size - 1)
                {
                    _size *= 2;
                    Array.Resize(ref _items, _size);
                }
                Count++;
                _items[++_tail] = rec;
            }
        }

        public T Dequeue()
        {
            if (_head < _tail)
            {
                Count--;
                T record = _items[_head];
                _items[_head++] = default;
                return record;
            }
            else if (_head == _tail)
            {
                Count--;
                T record = _items[_head];
                _items[_head] = default;

                _head = 0;
                _tail = -1;
                return record;

            }
            Console.WriteLine("Your Queue is Empty");
            return default;
        }

        public T Peek()
        {
            if (_head > _tail)
            {
                Console.WriteLine("Your Queue is Empty");
                return default;
            }

            return _items[_head];
        }
        public void Print()
        {
            foreach (T item in _items)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                }
                else
                {
                    Console.WriteLine("the queue is empty");
                }
            }
        }
        public void InsertionSort(MyQueue<T> queue)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int n = queue.Count;
            T[] tempArray = new T[n];
            for (int i = 0; i < n; i++)
            {
                tempArray[i] = queue.Dequeue();
            }

            for (int i = 1; i < n; i++)
            {
                T key = tempArray[i];
                int j = i - 1;

                while (j >= 0 && (tempArray[j] == null || tempArray[j].CompareTo(key) > 0))
                {
                    tempArray[j + 1] = tempArray[j];
                    j--;
                }

                tempArray[j + 1] = key;
            }
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(tempArray[i]);
            }
            sw.Stop();

        }     
        public  void SelectionSort(MyQueue<T> queue)
        {
            int n = queue.Count;
            for (int i = 0; i < n ; i++)
            {
                int minIndex = i;
                T minValue = queue.Dequeue();

                for (int j = i + 1; j < n; j++)
                {
                    T currValue = queue.Dequeue();
                    if (currValue.CompareTo(minValue) < 0)
                    {
                        minIndex = j;
                        minValue = currValue;
                    }
                    queue.Enqueue(currValue);
                }
                for (int k = i; k < minIndex; k++)
                {
                    T tempValue = queue.Dequeue();
                    queue.Enqueue(tempValue);
                }
                queue.Enqueue(minValue);
            }         
        }
        public static MyQueue<T> MergeSort(MyQueue<T> queue)
        {
            if (queue.Count <= 1)
            {
                return queue;
            }

            MyQueue<T> left = new MyQueue<T>();
            MyQueue<T> right = new MyQueue<T>();
            int middle = queue.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                left.Enqueue(queue.Dequeue());
            }

            while (queue.Count > 0)
            {
                right.Enqueue(queue.Dequeue());
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        public static MyQueue<T> Merge(MyQueue<T> left, MyQueue<T> right)
        {
            MyQueue<T> result = new MyQueue<T>();

            while (left.Count > 0 && right.Count > 0)
            {
                if (left.Peek().CompareTo(right.Peek()) < 0)
                {
                    result.Enqueue(left.Dequeue());
                }
                else
                {
                    result.Enqueue(right.Dequeue());
                }
            }

            while (left.Count > 0)
            {
                result.Enqueue(left.Dequeue());
            }

            while (right.Count > 0)
            {
                result.Enqueue(right.Dequeue());
            }

            return result;
        }
        public static void MergeSort(MyQueue<T> queue, out TimeSpan timeTaken)
        {
            Stopwatch sw = Stopwatch.StartNew();
            queue = MergeSort(queue);
            sw.Stop();
            timeTaken = sw.Elapsed;
        }

        private static MyQueue<T> QuickSort(MyQueue<T> queue)
        {
            if (queue.Count <= 1)
            {
                return queue;
            }

            T pivot = queue.Dequeue();
            MyQueue<T> left = new MyQueue<T>();
            MyQueue<T> right = new MyQueue<T>();

            while (queue.Count > 0)
            {
                T current = queue.Dequeue();
                if (current.CompareTo(pivot) < 0)
                {
                    left.Enqueue(current);
                }
                else
                {
                    right.Enqueue(current);
                }
            }

            left = QuickSort(left);
            right = QuickSort(right);

            MyQueue<T> sortedQueue = new MyQueue<T>();
            while (left.Count > 0)
            {
                sortedQueue.Enqueue(left.Dequeue());
            }
            sortedQueue.Enqueue(pivot);
            while (right.Count > 0)
            {
                sortedQueue.Enqueue(right.Dequeue());
            }

            return sortedQueue;
        }
        public static void QuickSort(MyQueue<T> queue, out TimeSpan timeTaken)
        {
            
            
            Stopwatch sw = Stopwatch.StartNew();
             queue = QuickSort(queue);
            sw.Stop();
            timeTaken = sw.Elapsed;
        }

        public static void SortInQueue()
        {
            var result = FetchData.GetData();
            MyQueue<Person> queue = new MyQueue<Person>(result);

            Stopwatch sw = Stopwatch.StartNew();
            queue.InsertionSort(new MyQueue<Person>(result));
            sw.Stop();
            TimeSpan time = sw.Elapsed;
            Console.WriteLine(" the time for Insertion sort in queue :{0}", time.TotalSeconds + "Seconds");

/*
            Stopwatch sw1 = Stopwatch.StartNew();
            queue.SelectionSort(new MyQueue<Person>(result));
            sw1.Stop();
            TimeSpan time1 = sw1.Elapsed;
            Console.WriteLine(" the time for selection sort  : {0}", time1.TotalSeconds + "Seconds");*/


            MyQueue<Person>.QuickSort(new MyQueue<Person>(result), out TimeSpan time3);
            Console.WriteLine(" the time for Quick sort in queue :{0}", time3.TotalSeconds + "Seconds");


            Stopwatch sw2 = Stopwatch.StartNew();
            MyQueue<Person>.MergeSort(new MyQueue<Person>(result));
            sw2.Stop();
            TimeSpan time2 = sw2.Elapsed;
            Console.WriteLine(" the time for merge sort in queue :{0}", time2.TotalSeconds + "Seconds");
        }
    }
}

       

    

