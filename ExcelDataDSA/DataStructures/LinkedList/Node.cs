
using System;

namespace ExcelDataDSA.DataStructures
{
    internal class Node<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public Node<T> NextValue { get; set; }
        public Node<T> previous { get; set; }  
        public Node()
        {

        }
       public Node(T data) {
            Value = data;
            NextValue = null;   
            previous= null;
        }
    }
}
