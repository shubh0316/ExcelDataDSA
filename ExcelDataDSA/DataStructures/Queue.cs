using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelDataDSA.DataStructures
{
    internal class Queue
    {
        IEnumerable<Person> results = FetchData.GetData();
         
        public void AddDataInQueue()
        {
            Queue<Person> input = new Queue<Person>(results);

            foreach(var items in input)
            {

                Console.WriteLine($"\t\t\tId:{items.Id}\n\t\t\tName:{items.Name}\n\t\t\tAge:{items.Age}\n\t\t\tCity:{items.City}\n\t\t\tState:{items.State}\n\n\n");
                Console.WriteLine("\t\t\tThe data is printed through Queue");
            }
        }
    }
}
