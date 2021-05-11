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
        public Grid Container { get; set; }
        public TimerClass TimerClass { get; set; }
        
        public MainPageViewModel(Grid container)
        {
            Container = container;
            TimerClass = new TimerClass();
            
            SetUpNewGame();
        }

        private void SetUpNewGame()
        {
            gameEngine = new GameEngine();
            TimerClass.Restart();
            DisplayArray();
        }

        private void DisplayArray()
        {
            for (int i = 0; i < Container.Children.Count(); i++)
                (Container.Children[i] as Button).Content = gameEngine.ArrayOfRandomIntegers[i] == 0 ? string.Empty : gameEngine.ArrayOfRandomIntegers[i].ToString();
        }

        #region Handle Click Event
        internal void HandleClickEvent(Button buttonClicked)
        {
            Button emptyCell = GetButton(string.Empty);

            MoveDetailStruct moveDetailStruct = GetMoveDetailStruct(buttonClicked, emptyCell);

            bool valideMove = gameEngine.CheckMove(moveDetailStruct);

            if (!valideMove)
                return;

            CheckIfTimerIsEnabled();

            gameEngine.UpdateArray(moveDetailStruct);

            gameEngine.AddHistory(moveDetailStruct);

            SwapContents(emptyCell, buttonClicked);


            HandleEndGame();
        }

        private MoveDetailStruct GetMoveDetailStruct(Button buttonClicked, Button emptyCell)
        {
            return new MoveDetailStruct()
            {
                EmptyCellTag = int.Parse(emptyCell.Tag.ToString()),
                ButtonClickedTag = int.Parse(buttonClicked.Tag.ToString()),
                ButtonClickedContent = buttonClicked.Content.ToString(),
            };
        }

        private void CheckIfTimerIsEnabled()
        {
            if (!TimerClass.DispatcherTimer.IsEnabled)
                TimerClass.StartTimer();
        }

        private async void HandleEndGame()
        {
            bool endGame = gameEngine.CheckEndGame();

            if (endGame)
            {
                TimerClass.Pause();

                await ShowEndGameMessage();

                SetUpNewGame();
            }
        }

        private async Task ShowEndGameMessage()
        {
            await new MessageDialog("You Won !!").ShowAsync();
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
        #endregion

        internal void HandleRedo()
        {

        }

        internal void HandleUndo()
        {
            bool canUndo = gameEngine.CheckCanUndo();

            if (canUndo)
            {
                string code = gameEngine.GetCode();
                string[] moveDetailStructArray = code.Split(',');

                MoveDetailStruct moveDetailStruct = new MoveDetailStruct()
                {
                    ButtonClickedTag = int.Parse(moveDetailStructArray[0]),
                    EmptyCellTag = int.Parse(moveDetailStructArray[1]),
                    ButtonClickedContent = moveDetailStructArray[2],
                };

                MoveDetailStruct moveDetailStruct2 = new MoveDetailStruct()
                {
                    ButtonClickedTag = int.Parse(moveDetailStructArray[1]),
                    EmptyCellTag = int.Parse(moveDetailStructArray[0]),
                    ButtonClickedContent = moveDetailStructArray[2],
                };

                gameEngine.UpdateArray(moveDetailStruct2);

                Button button = Container.Children.Cast<Button>().Where(x => int.Parse(x.Tag.ToString()) == moveDetailStruct.ButtonClickedTag).First();
                Button emptyCellButton = Container.Children.Cast<Button>().Where(x => int.Parse(x.Tag.ToString()) == moveDetailStruct.EmptyCellTag).First();

                emptyCellButton.Content = string.Empty;
                button.Content = moveDetailStruct.ButtonClickedContent;

                //SwapContents();
            }
        }
    }
}
