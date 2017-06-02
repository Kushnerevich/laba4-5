using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serialization.ClassOfAnimals;
using System.Windows.Forms;
using Serialization;

namespace Serialization
{
    public class PluginApi
    {
        Form1 frm;

        public PluginApi(Form1 frm)
        {
            this.frm = frm;
        }

        public Form1 getForm()
        {
            return frm;
        }

        public TabControl getControlPages()
        {
            return frm.tabControl1;
        }

        public List<Animals> getList()
        {
            return frm.Animals;
        }

        public DataGridView GetTable()
        {
            return frm.dataGridView1;
        }

        public Button CreateButton(int x, int y)
        {
            Button btn = new Button();
            frm.Controls.Add(btn);
            btn.Location = new System.Drawing.Point(x, y);
            return btn;
        }
    }
}
