using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01使用接口来替代事件实现登录校验
{
    public class MyEventArgs
    {

        public string LoginId { get; set; }
        public string LoginPwd { get; set; }
        public bool IsValid { get; set; }
    }
}
