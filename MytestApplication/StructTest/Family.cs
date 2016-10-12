using System;
using System.Collections.Generic;
using System.Text;

namespace StructTest
{
    public struct Family : IPerson
    {
        public string name;
        public int age;
        public bool sex;
        public string country;
        public Person person;

        //不可以包含显式的无参构造函数和析构函数
        public Family(string name, int age, bool sex, string country, Person person)
        {
            this.name = name;
            this.age = age;
            this.sex = sex;
            this.country = country;
            this.person = person;
        }

        //不可以实现protected、virtual、sealed和override成员
        public void GetSex()
        {
            if (sex)
                Console.WriteLine(person.Name + " is a boy.");
            else
                Console.WriteLine(person.Name + " is a girl.");
        }

        public void ShowPerson()
        {
            Console.WriteLine("This is {0} from {1}", new Person(name, 22).Name, country);
        }

        //可以重载ToString虚方法
        public override string ToString()
        {
            return String.Format("{0} is {1}, {2} from {3}", person.Name, age, sex ? "Boy" : "Girl", country);
        }
    }
}
