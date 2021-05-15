using SnakeGame.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SnakeGame
{
    class GameViewModel
    {
        public Game.SnakeGame Game { get; }
        public ICommand UpKey { get; }
        public ICommand DownKey { get; }
        public ICommand LeftKey { get; }
        public ICommand RightKey { get; }

        public GameViewModel(int width,int height)
        {
            Game = new Game.SnakeGame(width, height);
            UpKey = new CommandDelegate(UpKeyPressed);
            DownKey = new CommandDelegate(DownKeyPressed);
            LeftKey = new CommandDelegate(LeftKeyPressed);
            RightKey = new CommandDelegate(RightKeyPressed);
        }
        private void UpKeyPressed(object arg)
        {
            Game.KeyPressed(SnakeGame.Game.Direction.Up);
        }
        private void DownKeyPressed(object arg)
        {
            Game.KeyPressed(SnakeGame.Game.Direction.Down);
        }
        private void LeftKeyPressed(object arg)
        {
            Game.KeyPressed(SnakeGame.Game.Direction.Left);
        }
        private void RightKeyPressed(object arg)
        {
            Game.KeyPressed(SnakeGame.Game.Direction.Right);
        }
    }
}
