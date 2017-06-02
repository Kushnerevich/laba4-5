using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Serialization
{
    public class CheckerForEmptiness
    {
        public Boolean CheckTextBox(string TextInTextBox1, string TextInTextBox2, string TextInTextBox3, string TextInTextBox4, string TextInTextBox5)
        {
            if (TextInTextBox1 == "" || TextInTextBox2 == "" || TextInTextBox3 == "" || TextInTextBox4 == "" || TextInTextBox5 == "")
            {
                MessageBox.Show("Заполните все поля");
                return false;
            }
            return true;
        }
    }
}
