using System;
using System.Collections.Generic;
using System.Linq;

namespace magasprog_2_zh_1
{
    class Shop
    {
        private List<HeatingDevice> products = new List<HeatingDevice>();

        public void AddDevice(HeatingDevice heater)
        {
            if (heater is Boiler)
            {
                if (!(heater as Boiler).IsCondensing & heater.ConstructionYear > 2018)  // itt nem teszem ki a castolást egy külön sorba, mint a 32. sorban, hanem beírom a feltételbe
                {
                    System.Console.WriteLine("2018 óta csak kondenzációs kazánokat szabad árusítani; a következő terméket kihagyjuk: {0}", heater as Boiler);
                    return;
                }
            }
            products.Add(heater);
        }

        public int NumberOfCondensingCombinedBoilers  // szűréses feladat megoldása úgy, ahogy az órán csináltuk
        {
            get
            {
                int result = 0;
                foreach (HeatingDevice item in products)
                {
                    if (item is Boiler)
                    {
                        Boiler boiler = item as Boiler;
                        if (boiler.Function == BoilerFunction.Kombi)
                        {
                            result += 1;
                        }
                    }
                }
                return result;
            }
        }

        public int GetNumberOfHeatPumpsOfType(HeatPumpType type)  // szűréses feladat megoldása Linq csomaggal (Where, Select, ToList)
        {
            List<HeatPump> heatPumps = products
                                        .Where(p => p is HeatPump)  // leszűröm a listából a hőszivattyúkat
                                        .Select(p => p as HeatPump)  // HeatPump típusra castolom őket
                                        .ToList();  // elmentem az új HeatPump objektumaimat egy listába
            int result = heatPumps
                            .Where(hp => hp.Type == type)  // leszűröm azokat a hőszivattyúkat, amiknek megfelelő a típusa
                            .ToList()  // listát csinálok belőle
                            .Count;  // és végül a hossza érdekel
            return result;
        }

        public Boiler GetTopPerformerBoiler
        {
            get
            {
                List<Boiler> boilers = new List<Boiler>();
                foreach (HeatingDevice item in products)
                {
                    if (item is Boiler)
                    {
                        boilers.Add(item as Boiler);
                    }
                }
                double maxPerformance = boilers.Max(b => b.Performance);
                Boiler result = boilers
                                    .Where(b => b.Performance == maxPerformance)
                                    .ToList()[0];
                return result;
            }
        }

        public void FillFromFile(List<string[]> fileContent)
        {
            System.Console.WriteLine("--- Termékek beolvasása ---");
            foreach (string[] row in fileContent)
            {
                string name = row[0];
                int constructionYear = int.Parse(row[1]);
                double performance = double.Parse(row[2]);

                switch (row.Length)
                {
                    case 3:
                        AddDevice(new HeatingDevice(name, constructionYear, performance));
                        break;
                    case 4:
                        HeatPumpType type = (HeatPumpType) Enum.Parse(typeof(HeatPumpType), row[3]);
                        AddDevice(new HeatPump(name, constructionYear, performance, type));
                        break;
                    case 5:
                        bool isCondensing = bool.Parse(row[3]);
                        BoilerFunction function = (BoilerFunction) Enum.Parse(typeof(BoilerFunction), row[4]);
                        AddDevice(new Boiler(name, constructionYear, performance, isCondensing, function));
                        break;
                    default:
                        throw new Exception("Invalid row length");
                }
            }
            System.Console.WriteLine("--- Termékek beolvasva ---");
        }

        public void PrintAllProducts()
        {
            System.Console.WriteLine("\n A boltban elérhető eszközeink: \n");
            foreach (HeatingDevice item in products)
            {
                if (item is Boiler)
                {
                    System.Console.WriteLine((item as Boiler).ToString());
                } 
                else if (item is HeatPump)
                {
                    System.Console.WriteLine((item as HeatPump).ToString());
                }
                else
                {
                    System.Console.WriteLine(item.ToString());
                }
            }
        }
    }
}