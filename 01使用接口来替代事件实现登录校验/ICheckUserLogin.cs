using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01使用接口来替代事件实现登录校验
{
    public interface ICheckUserLogin
    {
        void ValidatingUserLogin(object sender, MyEventArgs e);
    }
}
