using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNotepadInterface
{
    public interface IEditor
    {
        /// <summary>
        /// 一个只读属性，用来显示插件的名称
        /// </summary>
        string Name
        {
            get;
        }
        //这个方法就是插件中运行插件的方法
        void Run(TextBox txtBox);
    }
}
