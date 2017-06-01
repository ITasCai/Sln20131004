using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyNotepadInterface;

namespace MyNotepadPlugin.ChangeFont
{
    public class ChangeFont : IEditor
    {

        #region IEditor 成员

        public string Name
        {
            get { return "修改字体"; }
        }

        public void Run(System.Windows.Forms.TextBox txtBox)
        {
            frmChangeFont changeFont = new frmChangeFont(txtBox);
            changeFont.Show();
        }

        #endregion
    }
}
