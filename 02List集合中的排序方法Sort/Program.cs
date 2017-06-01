using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02List集合中的排序方法Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> list = new List<int>() { 6, 7, 8, 9, 1, 2, 3, 4, 5 };

            List<Person> list = new List<Person>() {
            new Person(){ Name="ylp", Age=19, Email="ylp@yahoo.com"},
            new Person(){ Name="bsy", Age=18, Email="bsy@yahoo.com"},
            new Person(){ Name="wcy", Age=17, Email="wcy@yahoo.com"},
            new Person(){ Name="fzh", Age=29, Email="fzh@yahoo.com"}
            };
            list.Sort(new SortByAgeDesc());
            for (int i = 0; i < list.Count; i++)
            {
                Person pp = list[i] as Person;
                Console.WriteLine(pp.Name);
            }
            Console.Read();

        }
    }

    class SortByAgeDesc : IComparer<Person>
    {

        #region IComparer<Person> 成员

        public int Compare(Person x, Person y)
        {
            return y.Age - x.Age;
        }

        #endregion
    }

    class Person : IComparable<Person>
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        #region IComparable<Person> 成员

        public int CompareTo(Person other)
        {
            return this.Age - other.Age;
        }

        #endregion
    }
}
