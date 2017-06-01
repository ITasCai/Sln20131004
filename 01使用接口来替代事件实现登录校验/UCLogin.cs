using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _01使用接口来替代事件实现登录校验
{
    public partial class UCLogin : UserControl
    {
        public UCLogin()
        {
            InitializeComponent();
        }

        private ICheckUserLogin _validLogin;

        public ICheckUserLogin ValidLogin
        {
            get { return _validLogin; }
            set { _validLogin = value; }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //实现校验代码
            //1.采集用户输入的信息
            string uid = txtUid.Text.Trim();

            string pwd = txtPwd.Text;

            if (this.ValidLogin != null)
            {
                MyEventArgs evt = new MyEventArgs();
                evt.LoginId = uid;
                evt.LoginPwd = pwd;
                evt.IsValid = false;
                ValidLogin.ValidatingUserLogin(this, evt);//多态
                if (evt.IsValid)
                {
                    this.BackColor = Color.Green;
                }
                else
                {
                    this.BackColor = Color.Red;
                }
            }
        }
    }
}
