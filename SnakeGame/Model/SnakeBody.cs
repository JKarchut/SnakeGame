using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SnakeGame.Game
{
    class SnakeBody : INotifyPropertyChanged
    {
        public int X { get => x; set { x = value; OnPropertyChanged("X"); } }
        public int Y { get => y; set { y = value; OnPropertyChanged("Y"); } }
        public int Size { get => size; set { size = value; OnPropertyChanged("Size"); } }
        private int x, y, size;
        public SnakeBody(int x, int y, int size)
        {
            X = x; Y = y; Size = size;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
