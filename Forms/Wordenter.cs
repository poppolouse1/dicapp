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
    public partial class Wordenter : Form
    {
        private mainMenu previousWindow;
        private RichTextBox help;

        public Wordenter(mainMenu preWin)
        {
            InitializeComponent();
            this.previousWindow = preWin;
        }

        private void Wordenter_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("icon.ico");
            string[] allFiles = System.IO.Directory.GetFiles(@"Dictionary/Deutsch");

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
                functions functions = new functions();
                functions.writeToFile(wordText.Text, desteComboBox.GetItemText(desteComboBox.SelectedItem));
                wordText.ResetText();
            }
            else
            {
                MessageBox.Show("You must choose a deck for the words to go in!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                help.Text = @"How to enter a word into a deck:

In the database, each line is reserved for one word. Everytime you use the ""OK"" button, the program uses 1 line.Here's how you should enter words with some examples;

In short:
--Noun--
N, Article, Singular Word, Plural Word, Main Meaning, Other Meaning1, Other Meaning2, ...

E.x.: N, der, Boden, Böden, ground, floor, bottom, base, land, soild, ground floor,

--Verb--
Normal Verb: V, Verb, NV, Main Meaning, Other Meaning1, Other Meaning2, ...
Seperable Verb: V, Verb, TV, Main Meaning, Other Meaning1, Other Meaning2, ...

E.x.;
Normal Verb: 
V, blicken, NV, to glance, to look, to gaze
V, an etw.(Dat.) kleben, NV, to be glued to sth., to cleave to sth., to adhere to sth.

Seperable Verb: 
V, umkreisen, TV, to orbit, to revolve, to circuit

--Adjective--
A, Adjective, Main Meaning, Other Meaning1, Other Meaning2,... 

Explanation for some nitpicks:
You might recognize that every line starts with either 'V' or 'N' or 'A'.This is for the program to understand what kind of word it is.

Also, in verb types there are two types of verbs. 'NV' and 'TV'.These are also for the program to use. 'NV' stands for ""Normal Verb"" and 'TV' stands for ""Trennbare Verb"".This feature doesn't have any use right now, but it will be in the future.";

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
    }
}
