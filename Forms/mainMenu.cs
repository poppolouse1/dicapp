using System;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;

namespace DicApp
{
    public partial class mainMenu : Form
    {
        public string currentLanguage;
        private functions functions;
        public mainMenu()
        {
            InitializeComponent();
            this.functions = new functions();
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
            XmlDocument version = new();
            version.Load("settings.xml");
            this.currentLanguage = version.SelectSingleNode("//language").InnerText;

            if (currentLanguage == "TR")
            {
                Image trImage = Image.FromFile("tr.png");
                this.button4.Image = (Image)(new Bitmap(trImage, new Size(16, 16)));
            }
            else
            {
                Image trImage = Image.FromFile("eng.png");
                this.button4.Image = (Image)(new Bitmap(trImage, new Size(16, 16)));
            }

            if (int.Parse(version.SelectSingleNode("//isFirstTime").InnerText) == 1)
            {
                MessageBox.Show(functions.loadLanguageText(currentLanguage, 30), functions.loadLanguageText(currentLanguage, 31), MessageBoxButtons.OK, MessageBoxIcon.Information);
                version.SelectSingleNode("//isFirstTime").InnerText = "0";
                version.Save("settings.xml");
            }

            this.Icon = new System.Drawing.Icon("icon.ico");
            this.button4.Image = (Image)(new Bitmap(button4.Image, new Size(16,16)));

            this.button1.Text = functions.loadLanguageText(currentLanguage, 1);
            this.button2.Text = functions.loadLanguageText(currentLanguage, 2);
            label1.Text = functions.loadLanguageText(currentLanguage, 3);
            this.button3.Text = functions.loadLanguageText(currentLanguage, 4);

            label1.Text = label1.Text + " v" + version.SelectSingleNode("//currentVersion/major").InnerText+"."+ version.SelectSingleNode("//currentVersion/minor").InnerText+"."+ version.SelectSingleNode("//currentVersion/build").InnerText;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(functions.loadLanguageText(currentLanguage, 26), "Upcoming Features!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XmlDocument version = new XmlDocument();
            version.Load("settings.xml");

            if (currentLanguage == "TR")
            {
                this.currentLanguage = "EN";
                this.button1.Text = functions.loadLanguageText(currentLanguage, 1);
                this.button2.Text = functions.loadLanguageText(currentLanguage, 2);
                label1.Text = functions.loadLanguageText(currentLanguage, 3);
                this.button3.Text = functions.loadLanguageText(currentLanguage, 4);
                Image trImage = Image.FromFile("eng.png");
                this.button4.Image = (Image)(new Bitmap(trImage, new Size(16, 16)));
                label1.Text = label1.Text + " v" + version.SelectSingleNode("//currentVersion/major").InnerText + "." + version.SelectSingleNode("//currentVersion/minor").InnerText + "." + version.SelectSingleNode("//currentVersion/build").InnerText;
                version.SelectSingleNode("//language").InnerText = "EN";
                version.Save("settings.xml");

            }
            else
            {
                this.currentLanguage = "TR";
                this.button1.Text = functions.loadLanguageText(currentLanguage, 1);
                this.button2.Text = functions.loadLanguageText(currentLanguage, 2);
                label1.Text = functions.loadLanguageText(currentLanguage, 3);
                this.button3.Text = functions.loadLanguageText(currentLanguage, 4);
                Image trImage = Image.FromFile("tr.png");
                this.button4.Image = (Image)(new Bitmap(trImage, new Size(16, 16)));
                label1.Text = label1.Text + " v" + version.SelectSingleNode("//currentVersion/major").InnerText + "." + version.SelectSingleNode("//currentVersion/minor").InnerText + "." + version.SelectSingleNode("//currentVersion/build").InnerText;
                version.SelectSingleNode("//language").InnerText = "TR";
                version.Save("settings.xml");
            }


        }
    }
}
