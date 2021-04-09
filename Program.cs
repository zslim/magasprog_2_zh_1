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

            string filePath = "heating.txt";
            List<string[]> fileContent = new List<string[]>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    fileContent.Add(line.Split(";"));
                }
            }

            foreach (string[] row in fileContent)
            {
                string name = row[0];
                int constructionYear = int.Parse(row[1]);
                double performance = double.Parse(row[2]);

                if (row.Length == 3)
                {
                    shop.AddDevice(new HeatingDevice(name, constructionYear, performance));
                }
                else if (row.Length == 4)
                {
                    HeatPumpType type = (HeatPumpType) Enum.Parse(typeof(HeatPumpType), row[3]);
                    shop.AddDevice(new HeatPump(name, constructionYear, performance, type));
                }
                else
                {
                    bool isCondensing = bool.Parse(row[3]);
                    BoilerFunction function = (BoilerFunction) Enum.Parse(typeof(BoilerFunction), row[4]);
                    shop.AddDevice(new Boiler(name, constructionYear, performance, isCondensing, function));
                }
            }
        }
    }
}
