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
            
            return "ERROR";

        }

        public bool wordExists(string wordType, string word, string deck)
        {
            using (StreamReader reader = new StreamReader("Dictionary/Deutsch/" + deck))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] lineSep = line.Split(", ");
                    switch (wordType)
                    {
                        case "V":
                            if (lineSep[1].ToLower() == word.ToLower())
                            {
                                return true;
                            }
                            break;
                        case "N":
                            if (lineSep[2].ToLower() == word.ToLower())
                            {
                                return true;
                            }
                            break;
                        case "A":
                            if (lineSep[1].ToLower() == word.ToLower())
                            {
                                return true;
                            }
                            break;
                        default:
                            break;
                    }
                }

                return false;
            }
        }
    }
}
