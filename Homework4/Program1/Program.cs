using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{

    public delegate void ClockEventHandler(object sender, AlarmclockEventArgs e);    //声明委托

    class Program
    {       
        static void Main(string[] args)
        {
            string time = "";            
            Console.WriteLine("请输入一个符合格式的时间，格式为 10/01/2018 10:01 （月/日/年 时间）：");
            time = Console.ReadLine();
            Alarm alarm = new Alarm();
            alarm.Alarming += ShowAlarm;          
            alarm.AlarmTime = DateTime.Parse(time);          
            alarm.NewAlarm();         
        }

        static void ShowAlarm(object sender, AlarmclockEventArgs e)
        {
            Console.WriteLine("现在是北京时间：" + e.t.ToString());
        }

    }

    public class AlarmclockEventArgs : EventArgs
         {
                  public DateTime t;
          }   

    public class Alarm
    {
        public event ClockEventHandler Alarming;
        private DateTime time = DateTime.Now;      
        public DateTime AlarmTime = DateTime.Today;
        public void NewAlarm()
        {        
                while (time < AlarmTime)
                         time = DateTime.Now;            
                AlarmclockEventArgs alarmclockEventArgs = new AlarmclockEventArgs();
                alarmclockEventArgs.t = time;
                Alarming(this, alarmclockEventArgs);                     
        }
    }
}