using System;

namespace magasprog_2_zh_1
{
    class HeatingDevice
    {
        private string name;
        public string Name
        {
            get => name;
            private set
            {
                if (value == "" || value == null)
                {
                    throw new Exception("Invalid value for Device.Name: must not be null or empty string.");
                }
                name = value;
            }
        }

        private int constructionYear;
        public int ConstructionYear
        {
            get => constructionYear;
            private set
            {
                int thisYear = DateTime.Now.Year;
                if (value > thisYear)
                {
                    throw new Exception("Invalid construction year: year has not started yet.");
                }
                constructionYear = value;
            }
        }

        private double performance;
        public double Performance
        {
            get => performance;
            set
            {
                if (value < 0.01)
                {
                    throw new Exception("Invalid value for Device.Performance: should be at least 0.01");
                }
                performance = value;
            }
        }

        public HeatingDevice(string name, int constructionYear, double performance)
        {
            this.Name = name;
            this.ConstructionYear = constructionYear;
            this.Performance = performance;
        }

        public HeatingDevice(string name, int constructionYear): this(name, constructionYear, 0.01)
        {
        }

        public override string ToString()
        {
            string result = string.Format("Eszköz [Név: {0}, gyártási év: {1}, teljesítmény: {2}]", Name, ConstructionYear, Performance);
            return result;
        }
    }
}