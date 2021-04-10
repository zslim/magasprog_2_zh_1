using System;
using System.Collections.Generic;
using System.IO;

namespace magasprog_2_zh_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            System.Console.WriteLine("Üdvözöljük a 'Semmi Gáz' áruházban! \n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            string filePath = "heating.txt";
            List<string[]> fileContent = ReadFileContent(filePath);
            shop.FillFromFile(fileContent);

            shop.PrintAllProducts();
        }

        static List<string[]> ReadFileContent(string filePath)
        {
            List<string[]> fileContent = new List<string[]>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    fileContent.Add(line.Split(";"));
                }
            }

            return fileContent;
        }

        
    }
}
