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
using System.Windows.Shapes;

namespace Labra_15___SnakeGame
{
    /// <summary>
    /// The classic Snake Game in WPF
    /// </summary>

    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }

    public partial class Game : Window
    {
        // Variables and consts
        private const int minimi = 5;
        private const int maxHeight = 380;
        private const int maxWidth = 620;
        private int snakeWidth = 10;
        private int snakeLenght = 100;
        private int easiness = 20;              // Timerin ajastinaika (ms)
        private int score = 0;
        private List<Point> bonusPoints = new List<Point>();    // Omenakokoelma
        private const int bonusCount = 20;
        private List<Point> snakeParts = new List<Point>();     // Käärmeen osat
        private Point startingPoint = new Point(100, 100);      // Käärmeen aloituspiste
        private Point currentPosition = new Point();            // Käärmeen nykyinen sijainti
        private Direction lastDirection = Direction.Right;
        private Direction currentDirection = Direction.Right;   // Alussa lähtee aina oikealle
        private Random rnd = new Random();      // Omenoiden sijaintien arvontaa varten
        public Game()
        {
            InitializeComponent();
            // Tarvittavat alustukset

            // Piirretään omenat ja käärme
            IniBonusPoints(); 
            PaintSnake(startingPoint);
            currentPosition = startingPoint;

            // Aloitetaan peli
        }

        // Metodit
        private void IniBonusPoints()           // Piirretään omenoita näytölle
        {
            for (int n = 0; n < bonusCount; n++)
            {
                PaintBonus(n);
            }
        }

        private void PaintBonus(int index)      // Mikä omena syötiin
        {
            // Arvotaan omenalle piste, eli x- ja y- koordinaatit
            Point point = new Point(rnd.Next(minimi, maxWidth), 
                                    rnd.Next(minimi, maxHeight));

            // Omenan piirtäminen
            Ellipse omena = new Ellipse();
            omena.Fill = Brushes.Red;
            omena.Width = snakeWidth;
            omena.Height = snakeWidth;
            Canvas.SetTop(omena, point.Y);
            Canvas.SetLeft(omena, point.X);
            paintCanvas.Children.Insert(index, omena);
            bonusPoints.Insert(index, point);
        }

        private void PaintSnake(Point currentPoint)
        {
            Ellipse snake = new Ellipse();
            snake.Fill = Brushes.Green;
            snake.Width = snakeWidth;
            snake.Height = snakeWidth;
            Canvas.SetTop(snake, currentPoint.Y);
            Canvas.SetLeft(snake, currentPoint.X);
            int count = paintCanvas.Children.Count;
            paintCanvas.Children.Add(snake);
            snakeParts.Add(currentPosition);
            
            // Rajoitetaan käärmeen pituutta
            // TODO
        }

        private void GameOver()
        {
            MessageBox.Show("Your score: " + score);
            this.Close();                       // Palataan start-valikkoon
        }

        private void GameOverShow()
        {
            // TODO
        }
    }
}
