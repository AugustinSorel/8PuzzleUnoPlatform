using System;
using System.ComponentModel;
using Windows.UI.Xaml;

namespace MagicSquare
{
    class TimerClass : INotifyPropertyChanged
    {
        private DispatcherTimer dispatcherTimer;
        private int sec;
        private int minute;
        private int hour;
        private string timeString;
        public string TimeString 
        {
            get { return timeString; }
            set 
            { 
                timeString = value; 
                NotifyPropertyChanged("TimeString"); 
            } 
        }

        public TimerClass()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);

            SetTimer();
        }

        private void SetTimer()
        {
            sec = 0;
            minute = 0;
            hour = 0;

            TimeString = "00:00:00";
        }

        private void Timer_Tick(object sender, object e)
        {
            TimeString = GetTimeString();
        }

        internal void Pause()
        {
            dispatcherTimer.Stop();
        }

        private string GetTimeString()
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

            string secString = (sec < 10) ? "0" + sec.ToString() : sec.ToString();
            string minuteString = (minute < 10) ? "0" + minute.ToString() : minute.ToString();
            string hourString = (hour < 10) ? "0" + hour.ToString() : hour.ToString();

            return hourString + ":" + minuteString + ":" + secString;
        }

        internal bool HasStarted()
        {
            return TimeString != "00:00:00";
        }

        internal void StartTimer()
        {
            dispatcherTimer.Start();
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
