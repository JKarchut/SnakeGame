using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Threading;

namespace SnakeGame.Game
{
    class SnakeGame : INotifyPropertyChanged
    {
        private int Width { get; set; }
        private int Height { get; set; }
        public UrlImages Images { get; set; }
        public int Points { get => points; set { points = value; OnPropertyChanged("Points"); } }
        public bool IsSnakeAlive { get => alive; set { alive = value; OnPropertyChanged("IsSnakeAlive"); } }
        private DispatcherTimer timer;
        int tick,points;
        bool alive;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public Snake Snake { get; set; }
        public Fruits Fruits { get; set; }
        public SnakeGame(int wid,int heig)
        {
            Images = new UrlImages();
            Width = wid;
            Height = heig;
            tick = 0;
            Snake = new Snake(new SnakeBody(Width/2,Height/2,5),Direction.Left,wid,heig);
            Fruits = new Fruits(wid,heig);
            Fruits.GenerateFruit();
            IsSnakeAlive = true;
            Points = 0;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(250000);
            timer.Tick += GameTick;
            timer.Start();
        }
        private void GameTick(object sender,EventArgs arg)
        {
            if (!IsSnakeAlive)
                return;
            if (!Snake.Move())
                IsSnakeAlive = false;
            tick++;
            if (tick % 20 == 0)
            {
                Fruits.GenerateFruit();
                tick = 0;
            }
            if(Fruits.IsOnFruit(Snake.GetHead))
            {
                Snake.Grow();
                Points++;
            }
        }
        public void KeyPressed(Direction dir)
        {
            if (Snake.CurrentDirection == Direction.Down && dir == Direction.Up)
                return;
            if (Snake.CurrentDirection == Direction.Up && dir == Direction.Down)
                return;
            if (Snake.CurrentDirection == Direction.Right && dir == Direction.Left)
                return;
            if (Snake.CurrentDirection == Direction.Left && dir == Direction.Right)
                return;
            Snake.CurrentDirection = dir;
        }

        

    }
}
