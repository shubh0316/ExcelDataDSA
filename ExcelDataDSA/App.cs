
using ExcelDataDSA.DataStructures;
using ExcelDataDSA.DataStructures.MyLinkedList;
using System;

namespace ExcelDataDSA
{
    internal static class App
    {

        internal static void Start()
        {
            Console.WriteLine("\t\tWelcome to SORT-TIMER\t\t");
            Console.WriteLine("\t\tDiscription\t\t");
            Console.WriteLine("In this project you can check the duration of sorting algorithms in different data structures mentioned below...\t\t");
            Console.WriteLine("\t\t1) Array\t\t");
            Console.WriteLine("\t\t2) LinkedList\t\t");
            Console.WriteLine("\t\t3) DoublyLinkedList\t\t");
            Console.WriteLine("\t\t4) Stack\t\t");
            Console.WriteLine("\t\t5) Queue\t\t");
         
                while (true)
                {
                Console.WriteLine("Please enter");
                var input = int.Parse(Console.ReadLine());
                 
                    if (input == 1)
                    {
                     Console.WriteLine("Loading...\nDon't get bored");
                     MyArray<Person>.Sorting();                       
                    }
                    else if (input == 2)
                    {
                    Console.WriteLine("Loading...\nDon't get bored");
                    MySinglyLinkedList<Person>.AllSortAlgorithm();
                        
                    }
                    else if (input == 3)
                    {
                    Console.WriteLine("Loading...\nDon't get bored");
                    MyDoublyLinkedList<Person>.SortAllAlgorithmForDoublyLinkedList();
                       
                    }
                    else if (input == 4)
                    {
                    Console.WriteLine("Loading...\nDon't get bored");
                    MyStack<Person>.AllSortingOfStack();
                       
                    }
                    else if (input == 5)
                    {
                    Console.WriteLine("Loading...\nDon't get bored");
                    MyQueue<Person>.SortInQueue();
                       
                    }               
                }
            }
        }
    }



