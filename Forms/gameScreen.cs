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
    public partial class gameScreen : Form
    {
        public int amountOfWords;
        public string deck;

        private gWordSelection preWin;
        
        public float grade;
        public int right;
        public int wrong;
        public int pass;

        private string[] currentLine;
        private int currentCount;
        private string currentLanguage;

        private functions functions;

        private Button finishB;
        private RichTextBox textBoxNew;

        public gameScreen(int amountOfWords, string deck, gWordSelection preWin, string currentLanguage)
        {
            InitializeComponent();
            this.amountOfWords = amountOfWords;
            this.deck = deck;
            this.preWin = preWin;
            this.currentLanguage = currentLanguage;
        }

        private void gameScreen_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("icon.ico");
            refreshScreen();
            setNewWord();
            this.currentCount = 0;
            this.textBoxNew = new RichTextBox();
            this.functions = new functions();

            this.label1.Text = functions.loadLanguageText(currentLanguage, 13);
            this.label3.Text = functions.loadLanguageText(currentLanguage, 14);
            this.label13.Text = functions.loadLanguageText(currentLanguage, 15);
            this.label5.Text = functions.loadLanguageText(currentLanguage, 21);
            this.label6.Text = functions.loadLanguageText(currentLanguage, 22);
            this.label7.Text = functions.loadLanguageText(currentLanguage, 23);
            this.label8.Text = functions.loadLanguageText(currentLanguage, 24);

            this.button5.Text = functions.loadLanguageText(currentLanguage, 16);
            this.button3.Text = functions.loadLanguageText(currentLanguage, 17);
            this.button2.Text = functions.loadLanguageText(currentLanguage, 18);
            this.button4.Text = functions.loadLanguageText(currentLanguage, 19);
            this.button1.Text = functions.loadLanguageText(currentLanguage, 20);

            textBoxNew.Hide();
        }

        private void refreshScreen()
        {
            label10.Text = this.right.ToString();
            label11.Text = this.wrong.ToString();
            label12.Text = this.pass.ToString();
            label4.Text = "?";

            label9.Text = this.grade.ToString("0.0") + "/" + this.amountOfWords.ToString();
            listBox1.Items.Clear();
        }

        private void setNewWord()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Dictionary/Deutsch/" + this.deck);
            var r = new Random();
            var randomLineNumber = r.Next(1, lines.Length);
            string line = lines[randomLineNumber];
            

            string[] lineParts = line.Split(", ");
            this.currentLine = lineParts;

            switch (lineParts[0])
            {
                case "V":
                    label2.Text = lineParts[1];
                    break;
                case "N":
                    label2.Text = lineParts[1] + " " + lineParts[2];
                    break;
                case "A":
                    label2.Text = lineParts[1];
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switch (currentLine[0])
            {
                case "V":
                    label4.Text = currentLine[3];
                    if (currentLine.Length > 4)
                    {
                        for (int i = 4; i < currentLine.Length; i++)
                        {
                            listBox1.Items.Add(currentLine[i]);
                        }
                    }
                    break;
                case "N":
                    label4.Text = currentLine[4];
                    if (currentLine.Length > 5)
                    {
                        for (int i = 5; i < currentLine.Length; i++)
                        {
                            listBox1.Items.Add(currentLine[i]);
                        }
                    }
                    break;
                case "A":
                    label4.Text = currentLine[2];
                    if (currentLine.Length > 3)
                    {
                        for (int i = 3; i < currentLine.Length; i++)
                        {
                            listBox1.Items.Add(currentLine[i]);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(currentCount != amountOfWords & currentCount < amountOfWords)
            {
                this.right += 1;
                this.grade += 1;
                this.currentCount += 1;
                
                refreshScreen();
                setNewWord();
            }
            else
            {
                finishAvailable();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentCount != amountOfWords & currentCount < amountOfWords)
            {
                this.right += 1;
                this.grade += 0.5f;
                this.currentCount += 1;
                
                refreshScreen();
                setNewWord();
            }
            else
            {
                finishAvailable();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentCount != amountOfWords & currentCount < amountOfWords)
            {
                this.wrong += 1;
                this.grade -= 1;
                this.currentCount += 1;
                
                refreshScreen();
                setNewWord();
            } else
            {
                finishAvailable();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentCount != amountOfWords & currentCount < amountOfWords)
            {
                this.pass += 1;
                this.currentCount += 1;
                
                refreshScreen();
                setNewWord();
            }
            else
            {
                finishAvailable();
            }
        }

        private void gameScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void finishGame()
        {
            
        }

        private void finishAvailable()
        {
            this.Height = 318;
            this.finishB = new Button();
            this.finishB.Show();
            this.finishB.Location = new Point(255, 244);
            this.finishB.Text = "Finish";
            this.finishB.Width = 75;
            this.finishB.Height = 23;
            this.finishB.Visible = true;
            Controls.Add(finishB);
            this.finishB.Click += new EventHandler(finishB_Click);
        }

        private void finishB_Click(object sender, EventArgs e)
        {
            Hide();
            preWin.Closed += (s, args) => this.Close();
            preWin.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBoxNew.Visible)
            {
                this.Width = 352;
                textBoxNew.Hide();
            }
            else
            {
                this.Width = 796;
                textBoxNew.Text = functions.loadLanguageText(currentLanguage, 25);
                textBoxNew.Location = new Point(337, 6);
                textBoxNew.Width = 431;
                textBoxNew.Height = 228;
                Controls.Add(textBoxNew);
                textBoxNew.Show();
            }
            
        }
    }
}
