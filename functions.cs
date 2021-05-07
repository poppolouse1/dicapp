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
    }
}
