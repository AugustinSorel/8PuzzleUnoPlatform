using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace MagicSquare
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        private GameEngine gameEngine;
        public Grid Container { get; }
        private TimerClass timeClass;
        public TimerClass TimerClass 
        {
            get { return timeClass; }
            set
            {
                timeClass = value;
                NotifyPropertyChanged("TimerClass");
            }
        }

        public MainPageViewModel(Grid container)
        {
            Container = container;
            gameEngine = new GameEngine();
            TimerClass = new TimerClass();
            DisplayArray();
        }

        private void DisplayArray()
        {
            for (int i = 0; i < Container.Children.Count(); i++)
                (Container.Children[i] as Button).Content = gameEngine.Numbers[i] == 9 ? string.Empty : gameEngine.Numbers[i].ToString();
        }

        internal void HandleClickEvent(Button buttonClicked)
        {
            if (TimerClass.TimeString == string.Empty)
                TimerClass.StartTimer();

            Button emptyCell = GetButton(string.Empty);

            bool valideMove = gameEngine.CheckMove(int.Parse(emptyCell.Tag.ToString()), int.Parse(buttonClicked.Tag.ToString()), buttonClicked.Content.ToString());

            if (valideMove)
            {
                SwapContents(emptyCell, buttonClicked);
            }
        }

        private Button GetButton(string buttonContent)
        {
            return Container.Children.Cast<Button>().Where(x => x.Content.ToString() == buttonContent).First();
        }

        private void SwapContents(Button emptyCell, Button buttonClicked)
        {
            emptyCell.Content = buttonClicked.Content.ToString();
            buttonClicked.Content = string.Empty;
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
