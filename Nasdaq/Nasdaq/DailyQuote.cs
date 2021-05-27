using System;
namespace Nasdaq
{
    public class DailyQuote
    {

        public DateTime Date { get; }
        public decimal Close { get; }
        public ulong Volume { get; }
        public decimal Open { get; }
        public decimal High { get; }
        public decimal Low { get; }

        public DailyQuote(DateTime date,
            decimal close,
            ulong volume,
            decimal open,
            decimal high,
            decimal low)
        {
            Date = date;
            Close = close;
            Volume = volume;
            Open = open;
            High = high;
            Low = low;
        }

        public DailyQuote(string line)
        {
            string[] values = line.Split(',');

            for (int i = 0; i < values.Length; i++)
                if (values[i].Contains('$'))
                {
                    values[i] = values[i].Replace("$","");
                }

            for (int i = 0; i < values.Length; i++)
            {
                if (i == 0)
                    Date = DateTime.Parse(values[i]);
                else if (i == 1)
                    Close = decimal.Parse(values[i]);
                else if (i == 2)
                    Volume = ulong.Parse(values[i]);
                else if (i == 3)
                    Open = decimal.Parse(values[i]);
                else if (i == 4)
                    High = decimal.Parse(values[i]);
                else if (i == 5)
                    Low = decimal.Parse(values[i]);
            }
        }
    }
}
