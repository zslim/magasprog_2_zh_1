using System;

namespace magasprog_2_zh_1
{
    class HeatPump: HeatingDevice
    {
        private HeatPumpType type;
        public HeatPumpType Type
        {
            get => type;
            private set
            {
                type = value;
            }
        }

        public HeatPump(string name, int counstructionYear, double performance, HeatPumpType type): base(name, counstructionYear, performance)
        {
            Type = type;
        }

        public override string ToString()
        {
            string result = string.Format("Hőszivattyú [Név: {0}, gyártási év: {1}, teljesítmény: {2}, működési elv: {3}]",
                                            Name, ConstructionYear, Performance, Type);
            return result;
        }
    }

    enum HeatPumpType
    {
        LevegoViz, LevegoLevego, Talajszondas
    }
}