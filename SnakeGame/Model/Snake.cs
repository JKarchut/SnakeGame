using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SnakeGame.Game
{
    class Snake
    {
        public ObservableCollection<SnakeBody> Body { get; set; }
        int width, height;
        public Direction CurrentDirection { get; set; }
        public Snake(SnakeBody start, Direction dir,int wid,int heig)
        {
            width = wid;
            height = heig;
            CurrentDirection = dir;
            Body = new ObservableCollection<SnakeBody>();
            Body.Add(start);
            CurrentDirection = Direction.Down;
        }
        public bool Move()
        {
            SnakeBody s = Body[0];
            int sx = s.X;
            int sy = s.Y;
            switch (CurrentDirection)
            {
                case Direction.Up:
                    sy -= s.Size;
                    break;
                case Direction.Down:
                    sy += s.Size;
                    break;
                case Direction.Right:
                    sx += s.Size;
                    break;
                case Direction.Left:
                    sx -= s.Size;
                    break;
            }
            Body.RemoveAt(Body.Count-1);
            Body.Insert(0,new SnakeBody(sx, sy, 5));
            if (s.X > width || s.X < 0 || s.Y > height || s.Y < 0)
                return false;
            return true;
        }
        public void Grow()
        {
            SnakeBody s = Body[Body.Count-1];
            switch (CurrentDirection)
            {
                case Direction.Up:
                    s.Y += s.Size;
                    break;
                case Direction.Down:
                    s.Y -= s.Size;
                    break;
                case Direction.Right:
                    s.X += s.Size;
                    break;
                case Direction.Left:
                    s.X -= s.Size;
                    break;
            }
            Body.Add(new SnakeBody(s.X, s.Y,5));
        }
        public SnakeBody GetHead { get => Body[0]; }
    }
}
