using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace _01反射介绍
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 反射介绍

            //反射：通过动态获取程序集，并获取其中的类型元数据，然后访问该类型的过程。
            //反射中一个非常重要的类型就是 Type

            //1.如果获取Type 类型的对象？
            //获取Person类型的Type对象，Type对象中就是存放了一些关于某个类型的所有信息的内容。[某个类型的Type对象就是该类型“类型元数据”]

            //1>当没有对象的时候使用这种方式来获取某个类型的Type
            //Type type = typeof(Person);

            //2>//当已经获得对象后就可以使用对象的GetType();方法来获取指定对象的类型的Type对象了。
            //Person p = new Person();
            //Type personType = p.GetType();


            ////2.获取Person;类中的所有的方法
            //MethodInfo[] methods = personType.GetMethods();
            ////methods这个变量中存储了Person类中的所有的方法
            ////遍历输出每个方法的方法名
            //for (int i = 0; i < methods.Length; i++)
            //{
            //    //通过Type对象的GetMethods()可以获取指定类型的所有的方法其中包括编译器自动生成的方法以及从父类中继承来的方法，但是不包含private方法，要获取private方法，需要使用其他方式。
            //    Console.WriteLine(methods[i].Name);
            //}



            ////3.获取某个类型的所有属性
            //PropertyInfo[] properties = personType.GetProperties();
            //for (int i = 0; i < properties.Length; i++)
            //{
            //    Console.WriteLine(properties[i].Name);
            //}
            //Console.ReadKey();


            ////4.获取类中的所有字段,私有字段依然无法获取到。
            //FieldInfo[] fields = personType.GetFields();
            //for (int i = 0; i < fields.Length; i++)
            //{
            //    Console.WriteLine(fields[i].Name);
            //}
            //Console.ReadKey();


            ////获取所有成员，不包含私有成员。
            //MemberInfo[] members = personType.GetMembers();
            //for (int i = 0; i < members.Length; i++)
            //{
            //    Console.WriteLine(members[i].Name);
            //}
            //Console.ReadKey();
            #endregion


            #region 反射获取另外一个程序集中的类型


            ////1.动态加载02TestDll.dll文件
            ////Assembly

            ////动态加载一个程序集
            //Assembly assembly = Assembly.LoadFile(@"C:\Documents and Settings\Administrator\My Documents\visual studio 2010\Projects\Sln20131004\02TestDll\bin\Debug\02TestDll.dll");


            ////2.获取刚刚加载的程序集中的所有的类型
            ////assembly.GetType()  等价于  typeof(Assembly),不能获取某个程序集中国你的所有类型那个
            ////GetTypes()获取了所有的类型
            ////Type[] types = assembly.GetTypes();

            //////只获取那些public的类型
            ////Type[] types = assembly.GetExportedTypes();
            ////for (int i = 0; i < types.Length; i++)
            ////{
            ////    Console.WriteLine(types[i].Name);
            ////}


            ////只获取Person类的Type
            ////GetType()方法有重载，选择第二个重载，参数表示是要获取的类型的“完全限定名称”，即：命名空间.类名
            ////这里拿到了Type,其实就等价于typeof(Person)或者是：p.GetType();
            //Type personType = assembly.GetType("_02TestDll.Person");

            ////获取所有的方法：personType.GetMethods();

            ////调用一个无参数，无返回值的方法
            //#region 调用无参数无返回值的方法
            //////获取某个特定的方法(根据方法名):personType.GetMethod();

            ////MethodInfo method = personType.GetMethod("SayHi");
            //////Console.WriteLine(method.Name);

            //////通过反射来创建一个Person类型的对象{其实就是通过Person的Type来创建一个Person对象}

            ////object objPerson = Activator.CreateInstance(personType);


            //////调用这个方法
            ////method.Invoke(objPerson, null);
            //#endregion

            ////调用带参数，带返回值的方法
            //#region 调用带重载的方法
            //////1>找到对应的方法
            ////MethodInfo method = personType.GetMethod("Add");
            ////object obj = Activator.CreateInstance(personType);
            //////2>调用
            ////object result = method.Invoke(obj, new object[] { 102, 203 });
            ////Console.WriteLine("调用Add方法的返回值结果是：{0}", result);
            //#endregion


            //////调用重载的方法
            //#region 调用重载的方法

            //////1>找到对应的方法
            ////MethodInfo method = personType.GetMethod("Add", new Type[] { typeof(int), typeof(int), typeof(int) });
            ////object obj = Activator.CreateInstance(personType);

            //////2>调用
            ////int r = (int)method.Invoke(obj, new object[] { 1, 2, 3 });
            ////Console.WriteLine(r);
            //#endregion

            //#region  通过反射获取类的属性，并赋值

            //////1.获取Name属性
            ////PropertyInfo property = personType.GetProperty("Name");
            ////object obj = Activator.CreateInstance(personType);
            //////2.为属性赋值
            ////property.SetValue(obj, "闫刘盘", null);

            ////////3.获取属性
            //////string name = property.GetValue(obj, null).ToString();
            //////Console.WriteLine(name);

            ////MethodInfo method = personType.GetMethod("GetNameValue");
            ////method.Invoke(obj, null);
            ////Console.ReadKey();

            //#endregion


            //#region 手动查找类型的构造函数，并且调用该构造函数来创建类型的对象

            ////查找到了对应的构造函数，但是还没有调用
            //ConstructorInfo ctor = personType.GetConstructor(new Type[] { typeof(string), typeof(int), typeof(string) });

            ////开始调用构造函数
            //object obj = ctor.Invoke(new object[] { "hpp", 16, "hpp@yahoo.com" });
            //Console.WriteLine(obj.ToString());

            //MethodInfo method = personType.GetMethod("GetNameValue");
            //method.Invoke(obj, null);
            //Console.ReadKey();


            //#endregion





            //Console.ReadKey();



            #endregion


            #region 其他的反射中的一些方法

            ////动态加载一个程序集
            Assembly assembly = Assembly.LoadFile(@"C:\Documents and Settings\Administrator\My Documents\visual studio 2010\Projects\Sln20131004\02TestDll\bin\Debug\02TestDll.dll");

            //获取Person的Type 
            Type typePerson = assembly.GetType("_02TestDll.Person");

            Type typeStudent = assembly.GetType("_02TestDll.Student");

            Type typeIFlyable = assembly.GetType("_02TestDll.IFlyable");

            #region //bool IsAssignableFrom(Type c)：（直译：是否可以从c赋值）判断当前的类型的变量是不是可以接受c类型变量的赋值。


            ////表示可以将Student类型赋值给Person类型，因为Student类型继承自Person类
            ////bool b = typePerson.IsAssignableFrom(typeStudent); //true

            ////bool b = typeIFlyable.IsAssignableFrom(typeStudent);//true

            //bool b = typeIFlyable.IsAssignableFrom(typePerson);//false
            //Console.WriteLine(b);
            //Console.ReadKey();


            #endregion






            #region bool IsInstanceOfType(object o)：判断对象o是否是当前类的实例（当前类可以是o的类、父类、接口）

            ////Person
            //object objPerson = Activator.CreateInstance(typePerson);
            ////Student
            //object objStudent = Activator.CreateInstance(typeStudent);



            ////bool b = typePerson.IsInstanceOfType(objPerson);//true

            ////bool b = typePerson.IsInstanceOfType(objStudent);//true


            //bool b = typeStudent.IsInstanceOfType(objPerson);//false
            //Console.WriteLine(b);
            //Console.ReadKey();


            #endregion






            #region bool IsSubclassOf(Type c)：判断当前类是否是类c的子类。

            ////bool b = typeStudent.IsSubclassOf(typePerson);//true

            //// bool b = typePerson.IsSubclassOf(typeStudent);//false

            ////这个返回是false,只验证类与类之间的父子类关系，接口不包含。
            //bool b = typeStudent.IsSubclassOf(typeIFlyable);
            //Console.WriteLine(b);
            //Console.ReadKey();


            #endregion


            #region IsAbstract   判断是否为抽象的，含接口

            Type typeMyAbsClass = assembly.GetType("_02TestDll.MyAbstractClass");
            Type typeMyStaticClass = assembly.GetType("_02TestDll.MyStaticClass");

            Console.WriteLine(typePerson.IsAbstract);//false;
            Console.WriteLine(typeStudent.IsAbstract);//false
            Console.WriteLine(typeIFlyable.IsAbstract);//true
            Console.WriteLine(typeMyAbsClass.IsAbstract);//true
            Console.WriteLine(typeMyStaticClass.IsAbstract); //true
            Console.ReadKey();


            #endregion





            #endregion
        }
    }

    //class Person
    //{

    //    public int _height;

    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //    public string Email { get; set; }

    //    public void Say()
    //    {
    //        Console.WriteLine("Hello everyone!");
    //    }


    //    public void SayMorning()
    //    {
    //        Console.WriteLine("Good morning everybody!");
    //    }

    //    //私有的
    //    void Do()
    //    {
    //        Console.WriteLine("Just do it!");
    //    }
    //}
}
