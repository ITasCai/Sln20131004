using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02TestDll
{
    public class Class1
    {
    }

    class MyClass
    {
        public void SayHi()
        {
            Console.WriteLine("Hi~~");
        }
    }

    public abstract class MyAbstractClass
    {

    }

    public static class MyStaticClass
    {
    }


    public class Person
    {
        public Person()
        {

        }

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public void GetNameValue()
        {
            Console.WriteLine(this.Name + "     " + this.Age + "   " + this.Email);
        }


        public void SayHi()
        {
            Console.WriteLine("Hi~~");
        }

        public void SayHello()
        {
            Console.WriteLine("Hello");
        }

        public int Add(int n1, int n2)
        {
            return n1 + n2;
        }

        public int Add(int n1, int n2, int n3)
        {
            return n1 + n2 + n3;
        }
    }

    public class Student : Person, IFlyable
    {
        public string StudentNo { get; set; }

        #region IFlyable 成员

        public void Fly()
        {
            Console.WriteLine("学生翅膀硬了！");
        }

        #endregion
    }

    class Teacher : Person
    {

    }

    public delegate void MyDelegate();

    delegate void MyDelegate1();

    public enum GoodMan
    {
        高,
        富,
        帅
    }

    public interface IFlyable
    {
        void Fly();
    }
}
