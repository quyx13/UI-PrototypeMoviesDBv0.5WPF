using System;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public class Update
    {
        public TimeSpan timeSpan;
        public int i;
        public int number;

        public Update(TimeSpan timeSpan, int i, int number)
        {
            this.timeSpan = timeSpan;
            this.i = i;
            this.number = number;
        }
    }
}