using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DicApp.Forms
{
    public partial class gWordSelection : Form
    {
        private mainMenu previousScreen;
        public gWordSelection(mainMenu preWin)
        {
            InitializeComponent();
            this.previousScreen = preWin;
        }

        private void gWordSelection_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("icon.ico");

            string[] allFiles = System.IO.Directory.GetFiles(@"Dictionary/Deutsch");

            if (allFiles.Length == 0)
            {
                desteComboBox2.Enabled = false;
            }
            else
            {
                foreach (string item in allFiles)
                {
                    string[] satir = item.Split('\\');
                    desteComboBox2.Items.Add(satir[satir.Length - 1].Replace(".txt", ""));
                }
            }
        }

        private void gWordSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (desteComboBox2.GetItemText(desteComboBox2.SelectedItem) != "")
            {
                int wordcount = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
                gameScreen game = new gameScreen(wordcount, desteComboBox2.GetItemText(desteComboBox2.SelectedItem), this);
                game.Location = this.Location;
                game.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You must choose a deck for you to play with!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousScreen.Show();
        }
    }
}
