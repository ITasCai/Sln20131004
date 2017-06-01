using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _01使用接口来替代事件实现登录校验
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ucLogin1.ValidLogin = new MyValidate();
        }
    }

    public class MyValidate : ICheckUserLogin
    {

        #region ICheckUserLogin 成员

        public void ValidatingUserLogin(object sender, MyEventArgs e)
        {
            if (e.LoginId == "admin" && e.LoginPwd == "888")
            {
                e.IsValid = true;
            }
        }

        #endregion
    }
}
