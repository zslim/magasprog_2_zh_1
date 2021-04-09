using System;
using System.Collections.Generic;
using System.Linq;

namespace magasprog_2_zh_1
{
    class Shop
    {
        private List<HeatingDevice> heaters;
        private List<Boiler> boilers;
        private List<HeatPump> heatPumps;

        public Shop()
        {
            boilers = new List<Boiler>();
            heatPumps = new List<HeatPump>();
        }

        public void AddDevice(HeatingDevice heater)
        {
            heaters.Add(heater);
        }
        public void AddDevice(Boiler boiler)
        {
            if (!boiler.IsCondensing & boiler.ConstructionYear > 2018)
            {
                throw new Exception("2018 óta csak kondenzációs kazánokat szabad árusítani");
            }
            boilers.Add(boiler);
        }

        public void AddDevice(HeatPump heatPump)
        {
            heatPumps.Add(heatPump);
        }

        public int NumberOfCondensingCombinedBoilers
        {
            get
            {
                int result = boilers.Where(b => b.IsCondensing & b.Function == BoilerFunction.Kombi).ToList().Count;
                return result;
            }
        }

        public int GetNumberOfHeatPumpsOfType(HeatPumpType type)
        {
            int result = heatPumps.Where(hp => hp.Type == type).ToList().Count;
            return result;
        }

        public Boiler GetTopPerformerBoiler
        {
            get
            {
                double maxPerformance = boilers.Max(b => b.Performance);
                Boiler result = boilers.Where(b => b.Performance == maxPerformance).ToList()[0];
                return result;
            }
        }
    }
}