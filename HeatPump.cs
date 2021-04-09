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
    }

    enum HeatPumpType
    {
        LevegoViz, LevegoLevego, Talajszondas
    }
}