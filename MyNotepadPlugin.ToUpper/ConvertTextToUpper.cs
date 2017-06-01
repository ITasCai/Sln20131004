using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyNotepadInterface;

namespace MyNotepadPlugin.ToUpper
{
    public class ConvertTextToUpper : IEditor
    {
        #region IEditor 成员

        public string Name
        {
            get { return "转换大写"; }
        }

        public void Run(System.Windows.Forms.TextBox txtBox)
        {
            txtBox.Text = txtBox.Text.ToUpper();
        }

        #endregion
    }
}
