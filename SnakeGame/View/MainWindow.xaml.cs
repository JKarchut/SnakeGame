using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SnakeGame.GameViewModel game;
        public MainWindow()
        {
            game = new GameViewModel(500, 500);
            game.Game.Images.Url = new List<string>();
            game.Game.Images.Url.Add("https://cdn.pixabay.com/photo/2015/02/28/15/25/snake-653639_960_720.jpg");
            game.Game.Images.Url.Add("https://cdn.pixabay.com/photo/2014/11/23/21/22/snake-543243_960_720.jpg");
            game.Game.Images.Url.Add("https://cdn.pixabay.com/photo/2014/08/15/21/40/snake-419043_960_720.jpg");
            game.Game.Images.Url.Add("https://cdn.pixabay.com/photo/2014/08/15/21/40/snake-419043_960_720.jpg");
            game.Game.Images.Url.Add("https://cdn.pixabay.com/photo/2016/08/31/18/19/snake-1634293_960_720.jpg");
            InitializeComponent();
            DataContext = game;
        }
    }
}
