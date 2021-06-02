using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultyThreadWithTimer
{
    public class Program
    {
        static void Main(string[] args)
        {
            TimerLogic.Func();
            TimerLogic.Notify += PrintToComsole;
            TimerLogic.Func2();
            TimerLogic.Notify2 += PrintToComsole2;

            Console.ReadKey();
        }

        public static void PrintToComsole(int counter, DateTime dt)
        {
            Console.WriteLine("Time now is: " + dt.ToString("HH:mm:ss") + " number of triggered events is: " + counter + "\n");
        }

        public static void PrintToComsole2(int tSum, DateTime dt)
        {
            Console.WriteLine("Time now is: " + dt.ToString("HH:mm:ss") + " Total sum seconds: " + tSum + "\n");
        }
    }
}