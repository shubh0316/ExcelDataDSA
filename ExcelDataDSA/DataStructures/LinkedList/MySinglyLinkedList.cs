
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ExcelDataDSA.DataStructures
{
    internal class MySinglyLinkedList<T> where T : IComparable<T>
    {
        public Node<T> FirstNode { get; set; }
        public Node<T> LastNodeNode { get; set; }

        public MySinglyLinkedList(IEnumerable<T> value)
        {
            if (FirstNode == null)
            {
                foreach (var person in value)
                {
                    Add(new Node<T>(person));
                }
            }
        }
        private void Add(Node<T> value)
        {
            if (FirstNode == null)
            {
                FirstNode = value;
                LastNodeNode = FirstNode;
            }
            else
            {
                LastNodeNode.NextValue = value;
                LastNodeNode = LastNodeNode.NextValue;
            }
        }
        public void PrintData()
        {
            Node<T> node = FirstNode;
            while (node != null)
            {
                Console.WriteLine(node.Value.ToString());
                node = node.NextValue;
            }
        }

        private void Swap(Node<T> a, Node<T> b)
        {
            var temp = b.Value;
            b.Value = a.Value;
            a.Value = temp;
        }
     
        public void BubbleSort()
        {

            bool swapped;
            Node<T> current;
            Node<T> last = null;
            do
            {
                swapped = false;
                current = FirstNode;

                while (current.NextValue != last)
                {
                    if (current.Value.CompareTo(current.NextValue.Value) > 0)
                    {
                        T temp = current.Value;
                        current.Value = current.NextValue.Value;
                        current.NextValue.Value = temp;
                        swapped = true;
                    }
                    current = current.NextValue;
                }
                last = current;
            }
            while (swapped);

        }
        internal void InsertionSort()
        {

            Node<T> sorted = null, current = FirstNode;

            while (current != null)
            {
                Node<T> temp = current.NextValue;
                if (sorted == null || sorted.Value.CompareTo(current.Value) >= 0)
                {
                    current.NextValue = sorted;
                    sorted = current;
                }
                else
                {
                    Node<T> sCurrent = sorted;
                    while (sCurrent.NextValue != null && sCurrent.NextValue.Value.CompareTo(current.Value) < 0)
                    {
                        sCurrent = sCurrent.NextValue;
                    }
                    current.NextValue = sCurrent.NextValue;
                    sCurrent.NextValue = current;
                }
                current = temp;
            }

            FirstNode = sorted;          
        }
        internal void SelectionSort()
        {
            Node<T> temp = FirstNode;
            while (temp != null)
            {
                Node<T> min = temp;
                Node<T> r = temp.NextValue;

                while (r != null)
                {
                    if ((min.Value.CompareTo(r.Value) > 0))
                        min = r;
                    r = r.NextValue;
                }
                Swap(temp, min);
                temp = temp.NextValue;
            }


        }
        private Node<T> Merge(Node<T> a, Node<T> b)
        {
            Node<T> result = null, temp = null;

            while (a != null && b != null)
            {
                if (a.Value.CompareTo(b.Value) <= 0)
                {
                    if (result == null)
                    {
                        result = a;
                        temp = a;
                    }
                    else
                    {
                        temp.NextValue = a;
                        temp = temp.NextValue;
                    }
                    a = a.NextValue;
                }
                else
                {
                    if (result == null)
                    {
                        result = b;
                        temp = b;
                    }
                    else
                    {
                        temp.NextValue = b;
                        temp = temp.NextValue;
                    }
                    b = b.NextValue;
                }
            }
            while (a != null)
            {
                temp.NextValue = a;
                temp = temp.NextValue;
                a = a.NextValue;
            }

            while (b != null)
            {
                temp.NextValue = b;
                temp = temp.NextValue;
                b = b.NextValue;
            }

            return result;
        }
        private Node<T> MergeSort(Node<T> head)
        {
            if (head == null || head.NextValue == null)
            {
                return head;
            }

            Node<T> middle = GetMiddle(head);
            Node<T> nextOfMiddle = middle.NextValue;

            middle.NextValue = null;

            Node<T> left = MergeSort(head);
            Node<T> right = MergeSort(nextOfMiddle);

            Node<T> sortedList = Merge(left, right);
            return sortedList;
        }
        private Node<T> GetMiddle(Node<T> head)
        {
            if (head == null)
                return head;
            Node<T> fastMove = head.NextValue;
            Node<T> slowMove = head;

            while (fastMove != null)
            {
                fastMove = fastMove.NextValue;
                if (fastMove != null)
                {
                    slowMove = slowMove.NextValue;
                    fastMove = fastMove.NextValue;
                }
            }
            return slowMove;
        }
        internal void MergeSort()
        {

            FirstNode = MergeSort(FirstNode);       
        }
        private Node<T> PartitionLast(Node<T> start, Node<T> end)
        {
            if (start == end || start == null || end == null)
                return start;

            Node<T> pivot_prev = start;
            Node<T> curr = start;
            var pivot = end.Value;

            T temp;
            while (start != end)
            {

                if (start.Value.CompareTo(pivot) < 0)
                {
                    pivot_prev = curr;

                    temp = curr.Value;
                    curr.Value = start.Value;
                    start.Value = temp;

                    curr = curr.NextValue;
                }
                start = start.NextValue;
            }

            temp = curr.Value;
            curr.Value = pivot;
            end.Value = temp;

            return pivot_prev;
        }
        private void QuickSort(Node<T> start, Node<T> end)
        {
            if (start == end)
                return;

            Node<T> pivot_prev = PartitionLast(start, end);
            QuickSort(start, pivot_prev);

            if (pivot_prev != null && pivot_prev == start)
                QuickSort(pivot_prev.NextValue, end);

            else if (pivot_prev != null && pivot_prev.NextValue != null)
                QuickSort(pivot_prev.NextValue.NextValue, end);
        }
        internal void QuickSort()
        {

            QuickSort(FirstNode, LastNodeNode);


        }
        internal static void AllSortAlgorithm()
        {
            var result = FetchData.GetData();
            MySinglyLinkedList<Person> linkedlist = new MySinglyLinkedList<Person>(result);

            Stopwatch sw = Stopwatch.StartNew();
            linkedlist.BubbleSort();
            sw.Stop();
            TimeSpan timeSpan = sw.Elapsed;
            Console.WriteLine("the time taking in Bubble sort is: {0}", timeSpan.TotalSeconds + "Seconds");


            Stopwatch sw1 = Stopwatch.StartNew();
            linkedlist.SelectionSort();
            sw1.Stop();
            TimeSpan time = sw1.Elapsed;
            Console.WriteLine("the time taking for Selection sort: {0}", time.TotalSeconds + "Seconds");


            Stopwatch time2 = Stopwatch.StartNew();
            linkedlist.MergeSort();
            time2.Stop();
            TimeSpan timeSpan1 = time2.Elapsed;
            Console.WriteLine("the time taking for Mergesort: {0}", timeSpan1.TotalSeconds + "Seconds");

            Stopwatch time3= Stopwatch.StartNew();
            linkedlist.QuickSort();
            time3.Stop();
            TimeSpan timespan2 = time3.Elapsed;
            Console.WriteLine("The time taking for Quicksort: {0}", timespan2.TotalSeconds + "Seconds");

            Stopwatch time4 = Stopwatch.StartNew();
            linkedlist.InsertionSort();
            time4.Stop();
            TimeSpan timespan3 = time4.Elapsed;
            Console.WriteLine("The time taking for Insertion sort: {0}",timespan3.TotalSeconds + "Seconds");

            
        }
    }
}
