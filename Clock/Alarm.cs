using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class Alarm : IComparable
    {
        public static readonly string[] WeekDayNames = new string[7]{ "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс"};
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public bool[] WeekDays {  get; private set; }
        public string FileName { get; set; } = "";
        public Alarm()
        {
            WeekDays = new bool[7];
        }
        public Alarm(Alarm other) : this()
        {
            this.Date = other.Date;
            this.Time = other.Time;
            this.FileName = other.FileName;
            for (int i = 0; i < WeekDays.Length; i++)
            {
                this.WeekDays[i] = other.WeekDays[i];
            }
        }
        string WeekDaysToString()
        {
            string days = "";
            for (int i = 0; i < WeekDays.Length; i++)
            {
                if(WeekDays[i])days += WeekDayNames[i];
                Console.Write(WeekDays[i] + "\t");
            }
            return days;
        }
        public override string ToString()
        {
            string result = "";
            if (Date != null && Date != DateTime.MinValue) result += $"{Date},";
            result += $"{Time.TimeOfDay}, {WeekDaysToString()}, {FileName.Split('\\').Last()}";
            return result;
        }
        public int CompareTo(object other)
        {
            return this.Time.CompareTo((other as Alarm).Time);
        }
    }
}
