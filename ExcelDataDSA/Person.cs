
using System;
using System.Security.Policy;

namespace ExcelDataDSA
{
    internal class Person : IComparable<Person>
    {
    /*    internal Person() { 
        
        }*/

       /* public Person(string id,string name, string age, string state,string city, string contact) {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.State = state;
            this.City = city;
            this.Contact = contact;
        
        }*/
        public string Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }

        public int CompareTo(Person other)
        {
            return Age.CompareTo(other.Age);
        }
        public override string ToString()
        {
            return $"{Id,-10}{Name,-12} {Age,-12}{Age,-5}{State,-12}{City,-12}{Contact, -12}";
        }
    }
}
