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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

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
        private DispatcherTimer timer;

        public Game()
        {
            InitializeComponent();

            // Tarvittavat alustukset
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, easiness);
            timer.Tick += new EventHandler(timer_Tick);

            // Määritellään ikkunalle tapahtumankäsittelijä näppäimistön kuuntelua varten
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);

            // Piirretään omenat ja käärme
            IniBonusPoints(); 
            PaintSnake(startingPoint);
            currentPosition = startingPoint;

            // Aloitetaan peli
            timer.Start();
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
            Point point = new Point(rnd.Next(minimi, (maxWidth - 10)), 
                                    rnd.Next(minimi, (maxHeight - 10)));

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
            // Huom. bonusCount < snakeLength - muuten ei toimi
            if (count > snakeLenght)
            {
                paintCanvas.Children.RemoveAt(count - snakeLenght + (bonusCount - 1));
                snakeParts.RemoveAt(count - snakeLenght);
            }
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            // Muutetaan käärmeen suuntaa näppäimistön painalluksen mukaan,
            // mutta ei sallita 180 asteen käännöstä
            switch (e.Key)
            {
                case Key.P:                 // Pause-näppäin
                    if (timer.IsEnabled)
                        timer.Stop();
                    else
                        timer.Start();
                    break;
                case Key.Escape:            // Lopetus
                    if (timer.IsEnabled)
                        GameOver();
                    else
                        this.Close();
                    break;
                case Key.Left:
                    if (lastDirection != Direction.Right)
                        currentDirection = Direction.Left;
                    break;
                case Key.Up:
                    if (lastDirection != Direction.Down)
                        currentDirection = Direction.Up;
                    break;
                case Key.Right:
                    if (lastDirection != Direction.Left)
                        currentDirection = Direction.Right;
                    break;
                case Key.Down:
                    if (lastDirection != Direction.Up)
                        currentDirection = Direction.Down;
                    break;
            }
            lastDirection = currentDirection;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    currentPosition.Y -= 1;
                    break;
                case Direction.Right:
                    currentPosition.X += 1;
                    break;
                case Direction.Down:
                    currentPosition.Y += 1;
                    break;
                case Direction.Left:
                    currentPosition.X -= 1;
                    break;
                default:
                    break;
            }

            // Piirretään käärme uudelleen
            PaintSnake(currentPosition);

            // TÖRMÄYSTARKASTELUT

            // Törmäystarkastelu #1: Tarkistetaan, onko käärme kanvaasilla
            if ((currentPosition.X > maxWidth) || (currentPosition.X < minimi) ||
                (currentPosition.Y > maxHeight) || (currentPosition.Y < minimi))
                GameOver();

            // Törmäystarkastelu #2: Tarkistetaan, ettei käärme pure omaa häntäänsä
            for (int i = 0; i < snakeParts.Count - snakeWidth * 2; i++)
            {
                Point p = new Point(snakeParts[i].X, snakeParts[i].Y);
                if ((Math.Abs(p.X - currentPosition.X) < snakeWidth) &&
                   (Math.Abs(p.Y - currentPosition.Y) < snakeWidth))
                    GameOver();
            }

            // Törmäystarkastelu #3: Tarkistetaan, osuuko omenaan
            int n = 0;
            foreach (Point point in bonusPoints)
            {
                if ((Math.Abs(point.X - currentPosition.X) < snakeWidth) &&
                    (Math.Abs(point.Y - currentPosition.Y) < snakeWidth))
                {
                    // Syödään omena
                    score += 10;

                    // Kasvatetaan käärmeen pituutta
                    snakeLenght += 10;  

                    // Nopeutetaan peliä
                    if (easiness > 5)
                    {
                        easiness--;
                        timer.Interval = new TimeSpan(0, 0, 0, 0, easiness);
                    }

                    this.Title = "SnakeWPF - Your current score: " + score;
                    bonusPoints.RemoveAt(n);
                    paintCanvas.Children.RemoveAt(n);   // Poistetaan omena
                    PaintBonus(n);      // Piirretään uusi omena syödyn paikkaan
                    break;
                }
                n++;
            }
        }
        private void GameOver()
        {
            timer.Stop();
            MessageBox.Show("Your score: " + score);
            this.Close();
            // GameOverShow();         // Kutsutaan animaatio
        }

        private void GameOverShow()
        {
            txtMessage.Text = "GAME OVER\nYour score: " + score + "\npress ESC to quit";
            //paintCanvas.Children.Add(txtMessage); - JOSTAIN SYYSTÄ MADON TÖRMÄYS KAATAA OHJELMAN

            // Animaatio, joka siirtää kanvaasia
            var trs = new TranslateTransform();
            var anim = new DoubleAnimation(0, 620, TimeSpan.FromSeconds(15));
            trs.BeginAnimation(TranslateTransform.XProperty, anim);
            trs.BeginAnimation(TranslateTransform.YProperty, anim);
            paintCanvas.RenderTransform = trs;
        }
    }
}
