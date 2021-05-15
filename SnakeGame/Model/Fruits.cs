using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SnakeGame.Game
{
    class Fruit
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public Fruit(int x,int y,int size)
        {
            X = x;Y = y;
            Size = size;
        }
    }
    class Fruits
    {
        public ObservableCollection<Fruit> fruits { get; set; }
        int width, height;
        Random random = new Random();
        public Fruits(int width,int height)
        {
            this.width = width;
            this.height = height;
            fruits = new ObservableCollection<Fruit>();
        }
        public void GenerateFruit()
        {
            fruits.Add(new Fruit(random.Next(1, width), random.Next(1, height),5));
        }
        public bool IsOnFruit(SnakeBody elem)
        {
            for(int x=0;x<fruits.Count;x++)
            {
                if (Math.Abs(fruits[x].X - elem.X) < elem.Size && Math.Abs(fruits[x].Y - elem.Y) < elem.Size)
                {
                    fruits.RemoveAt(x);
                    return true;
                }
            }
            return false;
        }
    }
}
