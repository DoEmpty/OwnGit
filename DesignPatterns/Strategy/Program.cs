using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string word = null;
                while (word == null || word != "")
                {
                    Console.Write("input job:");
                    string job = Console.ReadLine();
                    Console.Write("input level:");
                    string level = Console.ReadLine();
                    Console.WriteLine($"salary:￥{new SalaryContext(level, job).GetSalary()}");
                    Console.WriteLine("press any key to continue");
                    word = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
