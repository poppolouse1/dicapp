using System;
using System.Xml;
using System.Windows.Forms;

namespace DicApp
{
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Forms.Wordenter wortender = new Forms.Wordenter(this);
            this.Hide();
            wortender.Location = this.Location;
            wortender.Show();
          
        }

        private void mainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forms.gWordSelection wordSel = new Forms.gWordSelection(this);
            this.Hide();
            wordSel.Location = this.Location;
            wordSel.Show();
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {
            this.Icon = new System.Drawing.Icon("icon.ico");
            

            XmlDocument version = new XmlDocument();
            version.Load("settings.xml");

            label1.Text = label1.Text + " v" + version.SelectSingleNode("//currentVersion/major").InnerText+"."+ version.SelectSingleNode("//currentVersion/minor").InnerText+"."+ version.SelectSingleNode("//currentVersion/build").InnerText;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"*Ability to create new decks
*Turkish Language support
*A new 'Guess the Plural Form' game
*Ability to only choose verbs, adjectives or nouns in 'Guess the Word'", "Upcoming Features!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
