using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public class SalaryContext
    {
        public LevelSalary PLevel { get; set; }
        public SalaryContext(string level,string job)
        {
            this.PLevel = LevelFactory.BuildLevelSalary(level, job);
        }

        public double GetSalary()
        {
            return PLevel.ClacSalary();
        }
    }
}
