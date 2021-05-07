using System;
using System.Net;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace Updater
{
    public partial class UpdateScreen : Form
    {
        private string currentVersionMj, currentVersionMn, currentVersionBuild;
        private string newVersionMj, newVersionMn, newVersionBuild;

        public UpdateScreen()
        {
            this.Visible = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           this.Icon = new System.Drawing.Icon("icon.ico");
           bool anyUpdate = checkForUpdate();

            if (!Directory.Exists("Dictionary/Deutsch"))
            {
                Directory.CreateDirectory("Dictionary/Deutsch");
            }

            if (!Directory.Exists("Language"))
            {
                Directory.CreateDirectory("Language");
            }

            if (!File.Exists("Dictionary/Deutsch/A1"))
            {
                File.Create("Dictionary/Deutsch/A1");
            }

            if (!File.Exists("Dictionary/Deutsch/A2"))
            {
                File.Create("Dictionary/Deutsch/A2");
            }

            if (!File.Exists("Dictionary/Deutsch/B1"))
            {
                File.Create("Dictionary/Deutsch/B1");
            }

            if (anyUpdate)
            {
                this.Visible = true;
                this.Refresh();
                System.Threading.Thread.Sleep(1000);
                updateApp();
                File.Delete("update.xml");
                ProcessStartInfo startInfo = new ProcessStartInfo("DicApp.exe");
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                startInfo.Arguments = "-n";
                Process.Start(startInfo);
                Application.Exit();
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("DicApp.exe");
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                startInfo.Arguments = "-n";
                Process.Start(startInfo);
                Application.Exit();
            }
        }

        private bool checkForUpdate()
        {
            using (var client = new WebClient { UseDefaultCredentials = true })
            {
                client.DownloadFile("https://raw.githubusercontent.com/poppolouse1/dicapp/main/update.xml", "update.xml");
            }

            XmlDocument updateXML = new XmlDocument();
            updateXML.Load("update.xml");
            this.newVersionMj = updateXML.SelectSingleNode("//currentVersion/major").InnerText;
            this.newVersionMn = updateXML.SelectSingleNode("//currentVersion/minor").InnerText;
            this.newVersionBuild = updateXML.SelectSingleNode("//currentVersion/build").InnerText;

            XmlDocument settingsXML = new XmlDocument();
            settingsXML.Load("settings.xml");
            this.currentVersionMj = settingsXML.SelectSingleNode("//currentVersion/major").InnerText;
            this.currentVersionMn = settingsXML.SelectSingleNode("//currentVersion/minor").InnerText;
            this.currentVersionBuild = settingsXML.SelectSingleNode("//currentVersion/build").InnerText;

            if (int.Parse(newVersionMj) > int.Parse(currentVersionMj))
            {
                MessageBox.Show("A new update has been found. It will be downloaded shortly.", "Update Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else if (int.Parse(newVersionMj) >= int.Parse(currentVersionMj) && int.Parse(newVersionMn) > int.Parse(currentVersionMn))
            {
                MessageBox.Show("A new update has been found. It will be downloaded shortly.", "Update Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else if (int.Parse(newVersionMj) >= int.Parse(currentVersionMj) && int.Parse(newVersionMn) >= int.Parse(currentVersionMn) && Int32.Parse(newVersionBuild) > Int32.Parse(currentVersionBuild))
            {
                MessageBox.Show("A new update has been found. It will be downloaded shortly.", "Update Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                File.Delete("update.xml");
                return false;
            }
        }

        private void updateApp()
        {
            XmlDocument updateXML = new XmlDocument();
            updateXML.Load("update.xml");

            XmlNodeList allPaths = updateXML.SelectNodes("//path");

            List<string> allFiles = new List<string>();
            foreach (XmlNode node in allPaths)
            {
                allFiles.Add(node.InnerText.Split("release/")[node.InnerText.Split("release/").Length - 1]);
            }

            foreach (string file in allFiles)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }

            using (var client = new WebClient { UseDefaultCredentials = true })
            {
                foreach (XmlNode node in allPaths)
                {
                    client.DownloadFile(node.InnerText, node.InnerText.Split("release/")[node.InnerText.Split("release/").Length - 1]);
                }
            }
        }
    }
}
