using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultyThreadWithTimer
{
    public class TimerLogic
    {
        public delegate void WithParams(int param, DateTime dt);
        public static event WithParams Notify;
        public static event WithParams Notify2;
        public static Timer t;
        public static Timer t2;
        public static DateTime DateTime1;
        public static DateTime DateTime2;
        static int timeChange = 5000;
        public static int SumOfSecFirst { get; set; } = 0;
        public static int SumOfSecSecond { get; set; } = 0;
        public static int counter = 0;
        public static int TotalSum { get; set; } = 0;


        public static void Func()
        {
            t = new Timer(TimerCallback, null, 0, 5000);

        }

        public static void Func2()
        {
            t2 = new Timer(TimerCallback2, null, 0, 13000);
        }

        public static void TimerCallback(Object o)
        {
            
            counter++;
            DateTime1 =  DateTime.UtcNow; // сюда кладём время, которое выведем в cw
            SumOfSecFirst += DateTime1.Second; // сюда только секунды от того же экземпляра

            Notify.Invoke(counter, DateTime1);

        }
        public static void TimerCallback2(Object o)
        {
            DateTime2 = DateTime.UtcNow;
            SumOfSecSecond += DateTime2.Second;

            int totalSum = SumOfSecFirst + SumOfSecSecond;
            TotalSum = totalSum;
            if (TotalSum % 1000 == 0)
            {
                timeChange -= 1000;
                try
                {
                    TimerLogic.t.Change(0, timeChange);
                }
                catch (Exception)
                {
                    // Если уже некуда убавлять время ожидания в таймере, то таймеры выключаются
                    TimerLogic.t.Change(Timeout.Infinite, Timeout.Infinite);
                    TimerLogic.t2.Change(Timeout.Infinite, Timeout.Infinite);
                }
            }
            Notify2.Invoke(TotalSum, DateTime2);
        }
    }
}