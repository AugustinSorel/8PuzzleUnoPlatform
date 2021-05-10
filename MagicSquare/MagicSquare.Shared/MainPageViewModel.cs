using System;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace MagicSquare
{
    class MainPageViewModel
    {
        private GameEngine gameEngine;

        public MainPageViewModel(Grid container)
        {
            gameEngine = new GameEngine();

            DisplayArray(container);
        }

        private void DisplayArray(Grid container)
        {
            for (int i = 0; i < container.Children.Count(); i++)
                (container.Children[i] as Button).Content = gameEngine.Numbers[i] == 9 ? string.Empty : gameEngine.Numbers[i].ToString();
        }

        internal void Test()
        {
            
        }
    }
}
