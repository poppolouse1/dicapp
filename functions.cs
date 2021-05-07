using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DicApp
{
    class functions
    {
        public void writeToFile(string wordProps, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(@"Dictionary/Deutsch/" + filePath, true))
            {
                writer.WriteLine(wordProps);
            }

        }

        public string loadLanguageText(string language, int lineNumber)
        {

            using (StreamReader reader = new StreamReader("Language/" + language))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace("\\n", "\n");
                    string[] lineSep = line.Split('#');
                    if (int.Parse(lineSep[0]) == lineNumber)
                    {
                        return lineSep[1];
                    }
                }
            }
            /*
            string[] languageLines = File.ReadAllLines("Language/" + language);

            foreach (string line in languageLines)
            {
                
            }
            */
            return "ERROR";

        }
    }
}
