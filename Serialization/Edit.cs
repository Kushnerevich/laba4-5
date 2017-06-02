using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Serialization.ClassOfAnimals;

namespace Serialization
{
    public partial class Edit : Form
    {
        List<Animals> Animals;
        int Number;
        Form1 MainForm;
        CheckerForEmptiness checker = new CheckerForEmptiness();
        
        public Edit(List<Animals> animals, int number, Form1 mainForm)
        {
            InitializeComponent();
            Animals = animals;
            Number = number;
            MainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checker.CheckTextBox(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString()))
            {
                List<string> info = new List<string>();
                info = Animals[Number].GetInfo();
                info[0] = textBox1.Text;
                info[1] = textBox2.Text;
                info[2] = textBox3.Text;
                info[3] = textBox4.Text;
                info[4] = textBox5.Text;
                Animals[Number].Change(info);
                MainForm.ShowTable();
                this.Dispose();
            }
        }
    }
}
