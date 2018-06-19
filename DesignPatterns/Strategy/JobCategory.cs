using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy
{
    public class Job
    {
        public virtual double BasicSalary { get; }
        public virtual double PerformanceSalary { get;}
        public virtual double FullAttendance { get;}
    }

    public class Developer : Job
    {
        public override double BasicSalary { get => 3000; }
        public override double PerformanceSalary { get => 2000; }
        public override double FullAttendance { get => 500; }
    }

    public class Tester : Job
    {
        public override double BasicSalary { get => 2000; }
        public override double PerformanceSalary { get => 2000; }
        public override double FullAttendance { get => 500; }
    }

    public class Producter : Job
    {
        public override double BasicSalary => 4000;

        public override double PerformanceSalary => 2000;

        public override double FullAttendance => 500;
    }
}
