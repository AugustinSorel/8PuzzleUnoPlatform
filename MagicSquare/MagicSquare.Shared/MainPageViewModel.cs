using System;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace MagicSquare
{
    class MainPageViewModel
    {
        private GameEngine gameEngine;
        public Grid Container { get; }

        public MainPageViewModel(Grid container)
        {
            Container = container;
            gameEngine = new GameEngine();

            DisplayArray();
        }

        private void DisplayArray()
        {
            for (int i = 0; i < Container.Children.Count(); i++)
                (Container.Children[i] as Button).Content = gameEngine.Numbers[i] == 9 ? string.Empty : gameEngine.Numbers[i].ToString();
        }

        internal void HandleClickEvent(Button buttonClicked)
        {
            Button emptyCell = Container.Children.Cast<Button>().Where(x => x.Content.ToString() == string.Empty).First();

            bool goodMove = gameEngine.CheckMove(int.Parse(emptyCell.Tag.ToString()), int.Parse(buttonClicked.Tag.ToString()), buttonClicked.Content.ToString());
            
            if (goodMove)
            {
                int number = int.Parse(buttonClicked.Content.ToString());

                //Swap them
                emptyCell.Content = number.ToString();
                buttonClicked.Content = string.Empty;

                //gameEngine.MoveNumberToEmptyCell();
            }
        }
    }
}
