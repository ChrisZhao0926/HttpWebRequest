using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApplicationHttpWebRequest
{
    class FileManager
    {
        public void Write(string path, string content)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(content);
                sw.WriteLine(DateTime.Now);
            }
        }
    }
}
