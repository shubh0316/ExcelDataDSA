using System;
using System.Collections.Generic;
namespace ExcelDataDSA.DataStructures
{
    internal class MyList
    {
        List<Person> listOfData = new List<Person>();
        public void AddingDataInList()
        {
            IEnumerable<Person> result = FetchData.GetData();
            if(result == null)
            {
                Console.WriteLine("the file is empty");
            }     
            listOfData.AddRange(result);
            foreach (var items in listOfData)
            {
                Console.WriteLine($"\t\t\tId:{items.Id}\n\t\t\tName:{items.Name}\n\t\t\tAge:{items.Age}\n\t\t\tCity:{items.City}\n\t\t\tState:{items.State}\n\n\n");
                Console.WriteLine("\t\t\tThe data is printed through list");
            }
        }
    }
}
