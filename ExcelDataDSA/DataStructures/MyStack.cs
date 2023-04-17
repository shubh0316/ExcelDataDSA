
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ExcelDataDSA.DataStructures
{
    internal class MyStack<T> where T : IComparable<T>, new()
    {
        private int _size;
        private T[] _arr;
        private int _index;

        public int Count { get; private set; }

        public MyStack()
        {
            Count = 0;
            _size = 20;
            _index = -1;
            _arr = new T[_size];

        }
        public MyStack(IEnumerable<T> data)
        {
            Count = 0;
            _index = -1;
            _size = data.Count();
            _arr = new T[_size];
            foreach (T item in data)
            {
                Push(item);
            }
        }

        public void Push(T value)
        {
            if(_index == _size - 1)
            {
                Array.Resize(ref _arr, _size*=2);
            }
            Count++;
            _arr[++_index] = value;
        }
        public T Pop()
        {
            if (_index == -1)
            {
                Console.WriteLine("Empty stack");
                return default;
            }

            T value = _arr[_index];
            _arr[_index--] = default;
            Count--;
            return value;
        }
        public T Top()
        {
            if (_index == -1)
            {
                Console.WriteLine("Your Stack is Empty");
                return default(T);
            }

            T value = _arr[_index];
            return value;
        }
        public void Print()
        {
            for (int i = _arr.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(_arr[i]);
            }
        }
        public void BubbleSort(MyStack<T> myStack)
        {
            MyStack<T> tempStack = new MyStack<T>();
            for (int i = 0; i < myStack.Count; i++)
            {
                for (int j = 0; j < myStack.Count - i - 1; j++)
                {
                    T firstElement = myStack.Pop();
                    T secondElement = myStack.Pop();


                    if (firstElement.CompareTo(secondElement) >= 0)
                    {
                        tempStack.Push(firstElement);
                        myStack.Push(secondElement);
                    }
                    else
                    {
                        tempStack.Push(firstElement);
                        myStack.Push(firstElement);
                    }
                }
                while (tempStack.Count > 0)
                {
                    myStack.Push(tempStack.Pop());
                }
            }
        }
        public void InsertionSort(MyStack<T> stack)
        {
            MyStack<T> tempStack = new MyStack<T>();

            while (stack.Count > 0)
            {
                T current = stack.Top();
                stack.Pop();

                while (tempStack.Count > 0 && tempStack.Top().CompareTo(current) > 0)
                {
                    stack.Push(tempStack.Top());
                    tempStack.Pop();
                }
                tempStack.Push(current);
            }
        }
        public void QuickSort(MyStack<T> myStack)
        {
            if (myStack.Count < 2)
                return;

            T pivot = myStack.Pop();
            MyStack<T> leftStack = new MyStack<T>();
            MyStack<T> rightStack = new MyStack<T>();


            while (myStack.Count > 0)
            {
                T presentElement = myStack.Pop();
                if (presentElement.CompareTo(pivot) <= 0)
                {
                    leftStack.Push(presentElement);
                }
                else
                {
                    rightStack.Push(presentElement);
                }
            }
            QuickSort(leftStack);
            QuickSort(rightStack);

            while (myStack.Count > 0)
            {
                myStack.Pop();
            }
            while (rightStack.Count > 0)
            {
                myStack.Push(rightStack.Pop());
            }
            myStack.Push(pivot);
            while (leftStack.Count > 0)
            {
                myStack.Push(leftStack.Pop());
            }
        }
        public void MergeSort(MyStack<T> myStack)
        {
            if (myStack.Count <= 1)
                return;

            int mid = myStack.Count / 2;

            MyStack<T> leftStack = new MyStack<T>();
            MyStack<T> right = new MyStack<T>();



            for (int i = 0; i < mid; i++)
                leftStack.Push(myStack.Pop());



            while (myStack.Count > 0)
                right.Push(myStack.Pop());



            MergeSort(leftStack);
            MergeSort(right);



            while (leftStack.Count > 0 && right.Count > 0)
            {
                if (leftStack.Top().CompareTo(right.Top()) < 0)
                    myStack.Push(leftStack.Pop());
                else
                    myStack.Push(right.Pop());
            }


            while (leftStack.Count > 0)
                myStack.Push(leftStack.Pop());


            while (right.Count > 0)
                myStack.Push(right.Pop());
        }
        public static void AllSortingOfStack()
        {
            var result = FetchData.GetData();
            MyStack<Person> objectStack = new MyStack<Person>(result);
            Stopwatch sw = Stopwatch.StartNew();
            objectStack.BubbleSort(new MyStack<Person>(result));
            sw.Stop();
            TimeSpan time = sw.Elapsed;
            Console.WriteLine(" The time for Bubble sort in stack :{0}", time.TotalSeconds + "Seconds");

            Stopwatch sw1 = Stopwatch.StartNew();
            objectStack.QuickSort(new MyStack<Person>(result));
            sw1.Stop();
            TimeSpan timeOne = sw1.Elapsed;
            Console.WriteLine(" The time for Quick sort in stack  :{0}", timeOne.TotalSeconds + "Seconds");


            Stopwatch sw2 = Stopwatch.StartNew();
            objectStack.InsertionSort(new MyStack<Person>(result));
            sw2.Stop();
            TimeSpan timeTwo = sw2.Elapsed;
            Console.WriteLine(" The time for Insertion  sort in stack :{0}", timeTwo.TotalSeconds + "Seconds");


            Stopwatch sw3 = Stopwatch.StartNew();
            objectStack.MergeSort(new MyStack<Person>(result));
            sw3.Stop();
            TimeSpan timeThree = sw3.Elapsed;
            Console.WriteLine(" The time for merge sort in stack :{0}", timeThree.TotalSeconds + "Seconds");
        }
    }
}
