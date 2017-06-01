using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using MyNotepadInterface;

namespace MyNotepadMain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 主窗体加载的时候动态搜索addons目录下的所有插件，并加载
            LoadPlugins();
        }

        //加载插件
        private void LoadPlugins()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "addons");

            //搜索该目录下的所有的程序集文件，这里就只搜索*.dll文件
            string[] dlls = Directory.GetFiles(path, "*.dll");

            //动态加载每个dll 文件
            foreach (string dllPath in dlls)
            {
                //加载每个程序集
                Assembly assembly = Assembly.LoadFile(dllPath);

                //需要一个接口来进行约定
                Type typeIEditor = typeof(IEditor);

                //获取当前加载的程序集中的所有的public类型
                Type[] types = assembly.GetExportedTypes();

                //遍历判断哪个类型实现了该接口
                foreach (Type userType in types)
                {
                    //判断这个类型必须是实现了IEditor接口的类型，并且该类型必须不是抽象的。
                    if (typeIEditor.IsAssignableFrom(userType) && !userType.IsAbstract)
                    {
                        IEditor plugin = (IEditor)Activator.CreateInstance(userType);

                        //把插件名称加载到菜单栏上
                        //Add()方法的返回值就是刚刚增加的菜单项
                        ToolStripItem tsi = tsmiFormat.DropDownItems.Add(plugin.Name);
                        //为该菜单项增加一个单击事件
                        tsi.Click += new EventHandler(tsi_Click);
                        tsi.Tag = plugin;
                    }
                }
            }


        }

        void tsi_Click(object sender, EventArgs e)
        {
            //菜单项的单击事件
            ToolStripItem tsi = sender as ToolStripItem;
            if (tsi != null)
            {
                IEditor editorPlugin = tsi.Tag as IEditor;

                //运行该插件
                editorPlugin.Run(this.textBox1);
            }
        }
    }
}

