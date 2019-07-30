using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMReader
{
    static public class consts
    {
        public static void invokeControlText(Control control, object o)
        {
            if (o == null)
            {

            }
            else
            {
                if (control.InvokeRequired) control.Invoke(new Action<string>(s => control.Text = s), (string)o);
                else control.Text = (string)o;
            }

        }
        public static void AddItemToListBox(Control control, object o)
        {
            if (o == null)
            {

            }
            else
            {
                if (control.InvokeRequired) control.Invoke(new Action<string>(s => ((ListBox)control).Items.Add(s)), (string)o);
                else ((ListBox)control).Items.Add((string)o);
            }

        }
    }
}
