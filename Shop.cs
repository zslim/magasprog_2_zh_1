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
                if (!((Boiler) heater).IsCondensing & heater.ConstructionYear > 2018)
                {
                    throw new Exception("2018 óta csak kondenzációs kazánokat szabad árusítani");
                }
            }
            products.Add(heater);
        }

        public int NumberOfCondensingCombinedBoilers
        {
            get
            {
                List<Boiler> boilers = products
                                        .Where(p => p is Boiler)
                                        .Select(p => p as Boiler)
                                        .ToList();
                int result = boilers
                                .Where(b => b.IsCondensing & b.Function == BoilerFunction.Kombi)
                                .ToList()
                                .Count;
                return result;
            }
        }

        public int GetNumberOfHeatPumpsOfType(HeatPumpType type)
        {
            List<HeatPump> heatPumps = products
                                        .Where(p => p is HeatPump)
                                        .Select(p => p as HeatPump)
                                        .ToList();
            int result = heatPumps
                            .Where(hp => hp.Type == type)
                            .ToList()
                            .Count;
            return result;
        }

        public Boiler GetTopPerformerBoiler
        {
            get
            {
                List<Boiler> boilers = products
                                        .Where(p => p is Boiler)
                                        .Select(p => p as Boiler)
                                        .ToList();
                double maxPerformance = boilers.Max(b => b.Performance);
                Boiler result = boilers
                                    .Where(b => b.Performance == maxPerformance)
                                    .ToList()[0];
                return result;
            }
        }
    }
}