﻿using System;
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
            if (buttonClicked.Content.ToString() == string.Empty)
                return;



            // Get number
            int number = int.Parse(buttonClicked.Content.ToString());

            // find the empty cell
            Button button = Container.Children.Cast<Button>().Where(x => x.Content.ToString() == string.Empty).First();

            //Swap them
            button.Content = number.ToString();
            buttonClicked.Content = string.Empty;

            //gameEngine.MoveNumberToEmptyCell();
        }
    }
}
