using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Windows.UI.Xaml;

namespace MagicSquare
{
    class TimerClass : INotifyPropertyChanged
    {
        private DispatcherTimer dt;
        private int sec;
        private int minute;
        private int hour;
        private string timeString;
        public string TimeString 
        {
            get { return timeString; }
            set { timeString = value; NotifyPropertyChanged("TimeString"); } 
        }

        public TimerClass()
        {
            dt = new DispatcherTimer();
            dt.Tick += Timer_Click;
            dt.Interval = TimeSpan.FromSeconds(1);

            sec = 0;
            minute = 0;
            hour = 0;

            TimeString = string.Empty;
        }

        private void Timer_Click(object sender, object e)
        {
            sec++;

            if (sec == 60)
            {
                sec = 0;
                minute++;
            }

            if (minute == 60)
            {
                minute = 0;
                hour++;
            }

            if (hour == 24)
            {
                hour = 0;
            }

            string secString;
            string minuteString;
            string hourString;

            if (sec < 10)
                secString = "0" + sec.ToString();
            else
                secString = sec.ToString();

            if (minute < 10)
                minuteString = "0" + minute.ToString();
            else
                minuteString = minute.ToString();

            if (hour < 10)
                hourString = "0" + hour.ToString();
            else
                hourString = hour.ToString();

            TimeString = hourString + ":" + minuteString + ":" + secString;
            Debug.WriteLine(TimeString);
        }

        internal void StartTimer()
        {
            dt.Start();
        }

        #region Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
