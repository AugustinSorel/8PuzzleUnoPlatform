using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace MagicSquare
{
    class MainPageViewModel
    {
        private GameEngine gameEngine;
        public Grid Container { get; }
        public TimerClass TimerClass { get; }

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
                (Container.Children[i] as Button).Content = gameEngine.ArrayOfRandomIntegers[i] == 0 ? string.Empty : gameEngine.ArrayOfRandomIntegers[i].ToString();
        }

        internal void HandleClickEvent(Button buttonClicked)
        {
            Button emptyCell = GetButton(string.Empty);

            bool valideMove = gameEngine.CheckMove(int.Parse(emptyCell.Tag.ToString()), int.Parse(buttonClicked.Tag.ToString()), buttonClicked.Content.ToString());

            if (!valideMove)
                return;
            
            HandleMove(buttonClicked, emptyCell);

            HandleEndGame();

            CheckIfTimerIsEnabled();
        }

        private void HandleMove(Button buttonClicked, Button emptyCell)
        {
            gameEngine.UpdateArray(int.Parse(emptyCell.Tag.ToString()), int.Parse(buttonClicked.Tag.ToString()), int.Parse(buttonClicked.Content.ToString()));
            SwapContents(emptyCell, buttonClicked);
        }

        private void CheckIfTimerIsEnabled()
        {
            if (!TimerClass.DispatcherTimer.IsEnabled)
                TimerClass.StartTimer();
        }

        private void HandleEndGame()
        {
            bool endGame = gameEngine.CheckEndGame();
            
            if (endGame)
            {

                ShowDialog();
            }
        }

        private async void ShowDialog()
        {
            var dialog = new MessageDialog("Hi!");
            await dialog.ShowAsync();
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
    }
}
