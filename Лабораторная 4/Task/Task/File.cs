using System;
using System.IO;

namespace Task
{
    class File
    {
        static public string GetMessage(string fileName)
        {
            string message;
            var filePath = Path.GetFullPath(fileName);
            using (StreamReader file = new StreamReader(filePath))
            {
                message = file.ReadToEnd();
            }

            return message;
        }

        static public void CreateFile(string text, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(text);
            }
        }
    }
}
