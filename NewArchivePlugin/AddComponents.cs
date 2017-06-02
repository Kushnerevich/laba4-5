using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serialization;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace NewArchivePlugin
{
    public class AddComponents
    {
            public void Create_Button(PluginApi api)
            {   
                Button arcbtn = api.CreateButton(496, 260);
                arcbtn.Text = "Заархивировать";
                arcbtn.Width = 120;
                arcbtn.Height = 30;
                Button disarcbtn = api.CreateButton(496, 299);
                disarcbtn.Width = 120;
                disarcbtn.Height = 30;
                disarcbtn.Text = "Разархивировать";
                arcbtn.Click += new EventHandler(arc_Click);
                disarcbtn.Click += new EventHandler(dis_Click);


            }
            protected void arc_Click(object sender, EventArgs e)
            {
                OpenFileDialog myOpenFileDialog = new OpenFileDialog();


                if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream mystream = myOpenFileDialog.OpenFile();
                    string filepath = myOpenFileDialog.FileName;
                    string zippath = filepath.Replace(".txt", ".zip");
                    string dirpath = filepath.Replace(".txt", "");
                    string filename = "";

                    for (int i = dirpath.LastIndexOf("\\") + 1; i < dirpath.Length; i++)
                    {
                        filename += dirpath[i];
                    }
                    filename += ".txt";
                    string newpath = dirpath + "\\" + filename;

                    mystream.Close();
                    Directory.CreateDirectory(dirpath);
                    File.Move(filepath, newpath);



                    try
                    {
                        ZipFile.CreateFromDirectory(dirpath, zippath);
                        File.Delete(newpath);

                        Directory.Delete(dirpath);
                    }
                    catch (Exception name)
                    {

                        MessageBox.Show("Архивация не удалась" + name.Message);
                    }
                }
            }

            protected void dis_Click(object sender, EventArgs e)
            {

                OpenFileDialog myOpenFileDialog = new OpenFileDialog();

                if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Stream mystream = myOpenFileDialog.OpenFile();
                    try
                    {
                        string path = myOpenFileDialog.FileName;
                        string destPath = path.Replace(".zip", ".txt");
                        string dirPath = path.Replace(".zip", "");
                        string filename = "";

                        for (int i = dirPath.LastIndexOf("\\") + 1; i < dirPath.Length; i++)
                        {
                            filename += dirPath[i];
                        }
                        filename += ".txt";
                        string newpath = dirPath + "\\" + filename;
                        ZipFile.ExtractToDirectory(path, dirPath);

                        mystream.Close();
                        File.Move(newpath, destPath);
                        File.Delete(path);
                        Directory.Delete(dirPath);

                    }
                    catch (Exception name)
                    {

                        MessageBox.Show("Невозможно разархивировать" + name.Message);
                    }
                }
            }
     }
}

