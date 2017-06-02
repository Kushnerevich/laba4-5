using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serialization;
using System.Windows.Forms;
using Serialization.ClassOfAnimals;
using System.Drawing;

namespace MyPlugin
{
    public class AddComponents
    {
        public List<Animals> animals = new List<Animals>();
        public List<TextBox> textBoxes = new List<TextBox>();
        public List<Label> label = new List<Label>();
        public DataGridView table = new DataGridView();
        public CheckerForEmptiness checker = new CheckerForEmptiness();

        public void Create_tabPage(PluginApi api)
        {
            this.table = api.GetTable();
            TabPage tb = new TabPage("Амфибии");
            this.animals = api.getList();

            label.Add(new Label());
            label.Last().Text = "Вес";
            tb.Controls.Add(label.Last());
            label.Last().Location = new System.Drawing.Point(92, 24);
            
            textBoxes.Add(new TextBox());
            tb.Controls.Add(textBoxes.Last());
            textBoxes.Last().Location = new System.Drawing.Point(63, 50);

            label.Add(new Label());
            label.Last().Text = "Тип питания";
            tb.Controls.Add(label.Last());
            label.Last().Location = new System.Drawing.Point(202, 24);

            textBoxes.Add(new TextBox());
            tb.Controls.Add(textBoxes.Last());
            textBoxes.Last().Location = new System.Drawing.Point(169, 50);

            label.Add(new Label());
            label.Last().Text = "Рост";
            tb.Controls.Add(label.Last());
            label.Last().Location = new System.Drawing.Point(92, 73);

            textBoxes.Add(new TextBox());
            tb.Controls.Add(textBoxes.Last());
            textBoxes.Last().Location = new System.Drawing.Point(63, 97);

            label.Add(new Label());
            label.Last().Text = "Цвет глаз";
            tb.Controls.Add(label.Last());
            label.Last().Location = new System.Drawing.Point(202, 73);

            textBoxes.Add(new TextBox());
            tb.Controls.Add(textBoxes.Last());
            textBoxes.Last().Location = new System.Drawing.Point(169, 97);

            label.Add(new Label());
            label.Last().Text = "Тип дыхания";
            tb.Controls.Add(label.Last());
            label.Last().Location = new System.Drawing.Point(117, 120);

            textBoxes.Add(new TextBox());
            tb.Controls.Add(textBoxes.Last());
            textBoxes.Last().Location = new System.Drawing.Point(118, 145);

            Button btn = new Button();
            btn.Location = new System.Drawing.Point(130, 173);
            btn.Text = "Добавить";
            btn.Click += new EventHandler(but_Click);

            tb.Controls.Add(btn);
            api.getControlPages().Controls.Add(tb);
           
        }

        public void but_Click(object sender, EventArgs e)
        {
            if (checker.CheckTextBox(textBoxes[0].Text, textBoxes[2].Text, textBoxes[1].Text, textBoxes[3].Text, textBoxes[4].Text))
            {
                animals.Add(new Amphibians(textBoxes[0].Text, textBoxes[2].Text, textBoxes[1].Text, textBoxes[3].Text, textBoxes[4].Text));
                UpdateTable(table, animals);
            }
        }

        public void UpdateTable(DataGridView dataGridView1,List<Animals> animals)
        {
            if (animals.Count != 0)
            {
                dataGridView1.ColumnCount = 5;
                dataGridView1.RowCount = animals.Count;

                dataGridView1.Columns[0].HeaderCell.Value = "Вес";
                dataGridView1.Columns[1].HeaderCell.Value = "Рост";
                dataGridView1.Columns[2].HeaderCell.Value = "Тип питания";
                dataGridView1.Columns[3].HeaderCell.Value = "Цвет глаз";
                dataGridView1.Columns[4].HeaderCell.Value = "Доп. свойство";
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    int j = 0;
                    List<string> info = new List<string>();
                    info = animals[i].GetInfo();
                    foreach (string item in info)
                    {
                        dataGridView1.Columns[j].Width = 75;
                        dataGridView1.Rows[i].Cells[j].Value = item;
                        j++;
                        }
                    }
                }
        }


      }  
}

