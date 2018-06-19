using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public abstract class LevelSalary
    {
        public LevelSalary(Job jobCategory)
        {
            this.JobCategory = jobCategory;
        }
        public abstract double Multiple { get; }
        public Job JobCategory { get; set; }
        public abstract double ClacSalary();
    }

    public class P1 : LevelSalary
    {
        public P1(Job jobCategory) : base(jobCategory)
        { }

        public override double Multiple { get => 1; }

        public override double ClacSalary()
        {
            return (JobCategory.BasicSalary + JobCategory.PerformanceSalary) * Multiple + JobCategory.FullAttendance;
        }
    }
    public class P2 : LevelSalary
    {
        public P2(Job jobCategory) : base(jobCategory)
        { }

        public override double Multiple { get => 1.2; }

        public override double ClacSalary()
        {
            return (JobCategory.BasicSalary + JobCategory.PerformanceSalary) * Multiple + JobCategory.FullAttendance + 500;//+餐补
        }
    }

    public class P3 : LevelSalary
    {
        public P3(Job jobCategory) : base(jobCategory)
        { }

        public override double Multiple { get => 1.6; }

        public override double ClacSalary()
        {
            return (JobCategory.BasicSalary + JobCategory.PerformanceSalary) * Multiple + JobCategory.FullAttendance+500+1000;//+餐补+加班费
        }
    }

    public class P4 : LevelSalary
    {
        public P4(Job jobCategory) : base(jobCategory)
        { }

        public override double Multiple { get => 1.9; }

        public override double ClacSalary()
        {
            return (JobCategory.BasicSalary + JobCategory.PerformanceSalary) * Multiple + JobCategory.FullAttendance + 500 + 2000;//+餐补+岗位津贴
        }
    }

    public class P5 : LevelSalary
    {
        public P5(Job jobCategory) : base(jobCategory)
        { }

        public override double Multiple { get => 2.5; }

        public override double ClacSalary()
        {
            return (JobCategory.BasicSalary + JobCategory.PerformanceSalary) * Multiple + JobCategory.FullAttendance + 2000+1000;//+岗位津贴+交通补助
        }
    }

    public class P6 : LevelSalary
    {
        public P6(Job jobCategory) : base(jobCategory)
        { }

        public override double Multiple { get => 3.4; }

        public override double ClacSalary()
        {
            return (JobCategory.BasicSalary + JobCategory.PerformanceSalary) * Multiple + JobCategory.FullAttendance + 2000 + 1000 + 10000;//+岗位津贴+交通补助+分红
        }
    }

    public class P7 : LevelSalary
    {
        public P7(Job jobCategory) : base(jobCategory)
        { }

        public override double Multiple { get => 3.4; }

        public override double ClacSalary()
        {
            return (JobCategory.BasicSalary + JobCategory.PerformanceSalary) * Multiple + JobCategory.FullAttendance + 2000 + 1000 + 1000 + 30000;//+岗位津贴+交通补助+差旅费+分红
        }
    }
}
