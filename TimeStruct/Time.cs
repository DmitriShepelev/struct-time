#pragma warning disable CA1815

namespace TimeStruct
{
    public struct Time
    {
        public Time(int minutes)
            : this(0, minutes)
        {
        }

        public Time(int hours, int minutes)
        {
            const int MINS_PER_DAY = 24 * 60;
            int totallMinutes;
            int minInHours, mins;
           
            if (hours < 0)
            {
                minInHours = hours * -60;
                minInHours %= MINS_PER_DAY;
                minInHours = MINS_PER_DAY - minInHours;
            }
            else
            {
                minInHours = hours * 60;
            }

            if (minutes < 0)
            {
                mins = minutes * -1;
                mins %= MINS_PER_DAY;
                mins = MINS_PER_DAY - mins;
            }
            else
            {
                mins = minutes;
            }

            totallMinutes = minInHours + mins;
            if (totallMinutes >= MINS_PER_DAY)
            {
                totallMinutes %= MINS_PER_DAY;
            }

            this.Hours = totallMinutes / 60;

            this.Minutes = totallMinutes % 60;
        }

        public int Minutes { get; }

        public int Hours { get; }

        public new string ToString()
        {
            return $"{this.Hours:D2}:{this.Minutes:D2}";
        }

        public void Deconstruct(out int hours, out int minutes)
        {
            hours = this.Hours;
            minutes = this.Minutes;
        }
    }
}
