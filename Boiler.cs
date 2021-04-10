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

        public override string ToString()
        {
            string result = string.Format("Kazán [Név: {0}, gyártási év: {1}, teljesítmény: {2}, kondenzációs-e: {3}, funkciója: {4}]",
                                            Name, ConstructionYear, Performance, IsCondensing, Function);
            return result;
        }
    }

    enum BoilerFunction
    {
        Futo, Kombi, BeepitettTarolos
    }
}