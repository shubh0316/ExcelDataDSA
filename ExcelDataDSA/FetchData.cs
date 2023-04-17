
using LinqToExcel;
using System.Collections.Generic;
using System.Linq;

namespace ExcelDataDSA
{
    internal  static class FetchData
    {
        public const string path = @"C:\Users\ssaxena\Downloads\Contacts.xlsx";
        static readonly ExcelQueryFactory factory = new ExcelQueryFactory(path);    
        public static IEnumerable<Person> GetData()
        {
            var worksheet = factory.Worksheet<Person>("Sheet1");
            var iteration = from details in worksheet
                            select details;
            return  iteration;        
        }    
    }
}
