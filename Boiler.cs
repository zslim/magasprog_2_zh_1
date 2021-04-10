using System;

namespace magasprog_2_zh_1
{
    class Boiler: HeatingDevice
    {
        private bool isCondensing;
        public bool IsCondensing
        {
            get => isCondensing;
            private set
            {
                isCondensing = value;
            }
        }

        private BoilerFunction function;
        public BoilerFunction Function
        {
            get => function;
            private set
            {
                function = value;
            }
        }

        public Boiler(string name, int counstructionYear, double performance, bool isCondensing, BoilerFunction function): base(name, counstructionYear, performance)
        {
            IsCondensing = isCondensing;
            Function = function;
        }

        public Boiler(string name, int counstructionYear, double performance): this(name, counstructionYear, performance, true, BoilerFunction.Kombi)
        {
        }
    }

    enum BoilerFunction
    {
        Futo, Kombi, BeepitettTarolos
    }
}