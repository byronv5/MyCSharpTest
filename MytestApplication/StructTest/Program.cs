using System;
using System.Collections.Generic;
using System.Text;

namespace StructTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string asterisk = new string('*', 20);
            Console.WriteLine(asterisk);
            Family newFamily;//不用实例化
            newFamily.name = "bai";
            newFamily.sex = true;
            Console.WriteLine(newFamily.name);

            Family myFamily = new Family("bai", 26, true, "China", new Person("sherry", 26));
            myFamily.name = "white";
            myFamily.GetSex();
            Console.WriteLine(myFamily.name);

            Person person = new Person { Name = "byron" };
            Console.WriteLine(person.Name);
            person.Name = "Jen";
            Console.WriteLine(person.Name);
            Console.WriteLine(asterisk);            
        }        
    }
}
