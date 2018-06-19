using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public static class LevelFactory
    {
        public static LevelSalary BuildLevelSalary(string level,string job)
        {
            Job jobCategory = null;
            switch (job)
            {
                case "dev":jobCategory = new Developer();break;
                case "test": jobCategory = new Tester(); break;
                case "prd": jobCategory = new Producter(); break;
                default:
                    throw new Exception("wrong job");
            }

            LevelSalary levelSalary = null;
            switch (level)
            {
                case "p1":levelSalary = new P1(jobCategory);break;
                case "p2": levelSalary = new P2(jobCategory); break;
                case "p3": levelSalary = new P3(jobCategory); break;
                case "p4": levelSalary = new P4(jobCategory); break;
                case "p5": levelSalary = new P5(jobCategory); break;
                case "p6": levelSalary = new P6(jobCategory); break;
                case "P7": levelSalary = new P7(jobCategory); break;
                default:
                    throw new Exception("wrong level");
            }
            return levelSalary;
        }
    }
}
