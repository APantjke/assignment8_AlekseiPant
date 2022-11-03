using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment8_AlekseiPant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void searchButton(object sender, EventArgs e)
        {
            try
            {
                bool foundG = false, foundB = false;
                string[] girlsNamesArray = new string[200];
                string[] boysNamesArray = new string[200];
                StreamReader girlsfile, boysfile;
                girlsfile = File.OpenText("girls.txt");
                boysfile = File.OpenText("boys.txt");
                int girlsIndex = 0, boysIndex = 0;

                while (!girlsfile.EndOfStream && !foundG)
                {
                    girlsIndex++;
                    girlsNamesArray[girlsIndex] = girlsfile.ReadLine();

                    if (girlsNamesArray[girlsIndex] == girlsNameBox.Text)
                    {
                        foundG = true;
                        textBox1.Text = girlsNameBox.Text + ", your name is on the list" + "\r" + "\n" + "position: " + girlsIndex;
                    }
                    else
                    {
                        textBox1.Text = "Your name is not on the list";
                    }
                }
                girlsfile.Close();

                while (!boysfile.EndOfStream && !foundB)
                {
                    boysIndex++;
                    boysNamesArray[boysIndex] = boysfile.ReadLine();

                    if (boysNamesArray[boysIndex] == boysNameBox.Text)
                    {
                        foundB = true;
                        textBox2.Text = boysNameBox.Text + ", your name is on the list" + "\r" + "\n" + "position: " + boysIndex;
                    }
                    else
                    {
                        textBox2.Text = "Your name is not on the list";
                    }
                }
                boysfile.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Name was not found");
            }
        }
        private void clearButton(object sender, EventArgs e)
        {
            girlsNameBox.Text = "";
            boysNameBox.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void exitButton(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
