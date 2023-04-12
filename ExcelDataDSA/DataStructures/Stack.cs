using System;
using System.Collections.Generic;
namespace ExcelDataDSA.DataStructures
{
 /*   internal class BaseStack
    {
        internal ExcelDataInputs data;
        internal BaseStack(ExcelDataInputs data)
        {
            BaseStack next = null;
            this.data = data;
        }
    }
    internal class CustomStack
    {
        BaseStack top;
        internal CustomStack()
        {
            top = null;
        }
        internal void Push(ExcelDataInputs data)
        {
            BaseStack stackNode = new BaseStack(data);
            stackNode.next = top;
            top = stackNode;
        }*/
        internal class Stack
        {
            public void AddingDataInStack()
        {
            IEnumerable<Person> results = FetchData.GetData();
            foreach(var items in results) 
            {      
                Console.WriteLine($"\t\t\tId:{items.Id}\n\t\t\tName:{items.Name}\n\t\t\tAge:{items.Age}\n\t\t\tCity:{items.City}\n\t\t\tState:{items.State}\n\n\n");
                Console.WriteLine("\t\t\tThe data is printed through stack");
            }
        }
    }
}
