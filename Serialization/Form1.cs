using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Serialization.ClassOfAnimals;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Serialization;

namespace Serialization
{
    public partial class Form1 : Form
    {
        public List<Animals> Animals = new List<Animals>();
        CheckerForEmptiness checker = new CheckerForEmptiness();
        public PluginApi api;

        public Form1()
        {
            InitializeComponent();
            api = new PluginApi(this);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (checker.CheckTextBox(textBox1.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString(), textBox2.Text.ToString(), textBox6.Text.ToString()))
            {
                Animals.Add(new Mammals(textBox1.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString(), textBox2.Text.ToString(), textBox6.Text.ToString()));
                ShowTable();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checker.CheckTextBox(textBox7.Text.ToString(), textBox8.Text.ToString(), textBox10.Text.ToString(), textBox11.Text.ToString(), textBox12.Text.ToString()))
            {
                Animals.Add(new Birds(textBox7.Text.ToString(), textBox8.Text.ToString(), textBox10.Text.ToString(), textBox11.Text.ToString(), textBox12.Text.ToString()));
                ShowTable();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checker.CheckTextBox(textBox13.Text.ToString(), textBox14.Text.ToString(), textBox16.Text.ToString(), textBox17.Text.ToString(), textBox15.Text.ToString()))
            {
                Animals.Add(new Fishs(textBox13.Text.ToString(), textBox14.Text.ToString(), textBox16.Text.ToString(), textBox17.Text.ToString(), textBox15.Text.ToString()));
                ShowTable();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checker.CheckTextBox(textBox19.Text.ToString(), textBox20.Text.ToString(), textBox22.Text.ToString(), textBox23.Text.ToString(), textBox21.Text.ToString()))
            {
                Animals.Add(new Insects(textBox19.Text.ToString(), textBox20.Text.ToString(), textBox22.Text.ToString(), textBox23.Text.ToString(), textBox21.Text.ToString()));
                ShowTable();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checker.CheckTextBox(textBox25.Text.ToString(), textBox26.Text.ToString(), textBox28.Text.ToString(), textBox29.Text.ToString(), textBox27.Text.ToString()))
            {
                Animals.Add(new Reptiles(textBox25.Text.ToString(), textBox26.Text.ToString(), textBox28.Text.ToString(), textBox29.Text.ToString(), textBox27.Text.ToString()));
                ShowTable();
            }
        }

        public void ShowTable()
        {

            if (Animals.Count != 0)
            {
                dataGridView1.ColumnCount = 5;
                dataGridView1.RowCount = Animals.Count;

                dataGridView1.Columns[0].HeaderCell.Value = "Вес";
                dataGridView1.Columns[1].HeaderCell.Value = "Рост";
                dataGridView1.Columns[2].HeaderCell.Value = "Тип питания";
                dataGridView1.Columns[3].HeaderCell.Value = "Цвет глаз";
                dataGridView1.Columns[4].HeaderCell.Value = "Доп. свойство";
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    int j = 0;
                    List<string> info = new List<string>();
                    info = Animals[i].GetInfo();
                    foreach (string item in info)
                    {
                        dataGridView1.Columns[j].Width = 75;
                        dataGridView1.Rows[i].Cells[j].Value = item;
                        j++;
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog mySaveFileDialog = new SaveFileDialog();

            mySaveFileDialog.InitialDirectory = ".";
            mySaveFileDialog.Filter = "Animals files (*.txt)|*.txt|All files(*.*)|*.*";
            mySaveFileDialog.FilterIndex = 1;
            mySaveFileDialog.RestoreDirectory = true;
            mySaveFileDialog.FileName = "Animals";
            if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream mystream = mySaveFileDialog.OpenFile();
                BinaryFormatter serializer = new BinaryFormatter();
                try
                {
                    serializer.Serialize(mystream, Animals);
                }
                catch (Exception name)
                {
                    MessageBox.Show("Файл не сохранен" + name.Message);
                }
                finally
                {
                    mystream.Close();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();

            myOpenFileDialog.InitialDirectory = ".";
            myOpenFileDialog.Filter = "Animals files (*.txt)|*.txt|All files(*.*)|*.*";
            myOpenFileDialog.FilterIndex = 1;
            myOpenFileDialog.RestoreDirectory = true;

            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Animals.Clear();
                Stream mystream = myOpenFileDialog.OpenFile();
                try
                {
                    BinaryFormatter deserializer = new BinaryFormatter();
                    Animals = deserializer.Deserialize(mystream) as List<Animals>;
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось загрузить файл");
                }
                finally
                {
                    mystream.Close();
                    ShowTable();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Animals.Clear();
            dataGridView1.Rows.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Выберите строку которую хотите изменить в таблице.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButton1.Checked)
            {

                int numToChange = e.RowIndex;
                Edit ChangeForm = new Edit(Animals, numToChange, this);
                ChangeForm.Show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();
            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Plugin_Controller Controller = new Plugin_Controller();
                IPlugins plugin = Controller.Load_Plugin(this, myOpenFileDialog.FileName);
                plugin.Run(api);
            }
        }
   }
}

            
        

