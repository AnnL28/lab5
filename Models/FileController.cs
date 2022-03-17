using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Models
{
    public class FileController
    {
        public void Write(string data, string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(data);
            }
        }
        public string Read(string path)
        {
            string output = "";
            using (StreamReader sr = File.OpenText(path))
            {
                return sr.ReadToEnd();

            }
        }
    }
}
