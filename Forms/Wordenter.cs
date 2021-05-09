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

namespace DicApp.Forms
{
    public partial class Wordenter : Form
    {
        private mainMenu previousWindow;
        private RichTextBox help;
        private functions function;

        public Wordenter(mainMenu preWin)
        {
            InitializeComponent();
            this.previousWindow = preWin;
        }

        private void Wordenter_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("icon.ico");
            string[] allFiles = System.IO.Directory.GetFiles(@"Dictionary/Deutsch");
            this.function = new functions();

            //REMOVED|| this.label1.Text = function.loadLanguageText(previousWindow.currentLanguage, 5);
            this.label4.Text = function.loadLanguageText(previousWindow.currentLanguage, 6);
            this.label2.Text = function.loadLanguageText(previousWindow.currentLanguage, 7);
            this.label3.Text = function.loadLanguageText(previousWindow.currentLanguage, 8);
            this.button1.Text = function.loadLanguageText(previousWindow.currentLanguage, 9);
            this.label5.Text = function.loadLanguageText(previousWindow.currentLanguage, 32);

            if (allFiles.Length == 0)
            {
                desteComboBox.Enabled = false;
            }
            else
            {
                foreach (string item in allFiles)
                {
                    string[] satir = item.Split('\\');
                    desteComboBox.Items.Add(satir[satir.Length - 1].Replace(".txt", ""));
                }
            }
            this.help = new RichTextBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (desteComboBox.GetItemText((desteComboBox.SelectedItem)) != "")
            {
                if (textBox1.Text != "")
                {
                    MessageBox.Show(function.loadLanguageText(previousWindow.currentLanguage, 34), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    function.writeToFile(wordText.Text, desteComboBox.GetItemText(desteComboBox.SelectedItem));
                    wordText.ResetText();
                }
                
            }
            else if (textBox1.Text != "")
            {
                if (File.Exists(@"Dictionary/Deutsch/" + textBox1.Text) == true)
                {
                    MessageBox.Show(function.loadLanguageText(previousWindow.currentLanguage, 35), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    function.writeToFile(wordText.Text, textBox1.Text);
                    wordText.ResetText();
                }
            }
            else
            {
                MessageBox.Show(function.loadLanguageText(previousWindow.currentLanguage, 33), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Wordenter_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (help.Visible)
            {
                this.Height = 154;
                help.Hide();
            }
            else
            {
                this.Height = 372;
                help.Text = this.function.loadLanguageText(previousWindow.currentLanguage, 10);

               help.Location = new Point(13, 113);
                help.Width = 429;
                help.Height = 208;
                Controls.Add(help);
                help.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousWindow.Show();
        }

        private void wordText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                wordText.Text = wordText.Text + ", ";
                wordText.SelectionStart = wordText.Text.Length;
            }
        }
    }
}
