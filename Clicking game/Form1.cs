using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clicking_game
{
    public partial class Form1 : Form
    {
        int interval = 1000;
        int size = 70;
        int count = 0;
        int score = 0;
        int penalty = 0;

        bool gameStopped = false;

        Random rand = new Random();
        Timer gameTimer = new Timer();
        private Timer circleTimer;
        private Label scoreLabel;
        private Label penaltyLabel;
        private SoundPlayer clickSoundPlayer;

        private void CreateCircle()
        {
            //if (gameStopped) return;
            int x = rand.Next(0, ClientSize.Width - size);
            int y = rand.Next(0, ClientSize.Height - size);

            (Color color, int circle_score) = GetRandomColorAndScore();

            Circle circle = new Circle(x, y, size, color, circle_score);
            circle.MouseClick += Circle_MouseClick;
            Controls.Add(circle);

            count++;

            if (count % 10 == 0 && interval > 200)
            {
                interval -= 100;
            }

            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += (s, e) =>
            {
                //if (gameStopped) return;
                RemoveCircle(circle);
                timer.Stop();
                timer.Dispose();
                Penalty();
            };
            timer.Start();

            circleTimer = timer;
        }

        public Form1()
        {
            InitializeComponent();
            gameTimer.Interval = interval;
            gameTimer.Tick += GameLoop;
            Paint += Form1_Paint;
            this.Text = "Clicking Game";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scoreLabel = new Label();
            scoreLabel.Location = new Point(10, 10);
            scoreLabel.Font = new Font("Arial", 12, FontStyle.Regular);

            penaltyLabel = new Label();
            penaltyLabel.Location = new Point(110, 10);
            penaltyLabel.Font = new Font("Arial", 12, FontStyle.Regular);

            clickSoundPlayer = new SoundPlayer("pop-39222.wav");
            //this.BackgroundImage = Image.FromFile("bg.jpg");
            restartButton.Click += restartButton_Click_1;

            Controls.Add(scoreLabel);
            Controls.Add(penaltyLabel);
            gameTimer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void Circle_MouseClick(object sender, MouseEventArgs e)
        {
            if (gameStopped) return;
            if (e.Button == MouseButtons.Left)
            {
                Circle circle = (Circle)sender;
                circle.Clicked = true;
                circleTimer.Stop();
                circleTimer.Dispose();
                RemoveCircle(circle);
                IncreaseScore(circle.score);

                if (circle.color != Color.LimeGreen)
                {
                    LessPenalty(circle);
                }

                clickSoundPlayer.Play();
            }
        }




        private void Penalty()
        {
            if (gameStopped) return;

            List<Circle> unclickedCircles = Controls.OfType<Circle>()
                .Where(c => !c.Clicked && c.color != Color.LimeGreen)
                .ToList();

            if (unclickedCircles.Count > 0)
            {
                Circle circle = unclickedCircles[rand.Next(0, unclickedCircles.Count)];
                penalty += Math.Abs(circle.score);

                if (penalty > 100)
                {
                    GameOver();
                }
            }
        }


        private void LessPenalty(Circle circle)
        {
            penalty = Math.Max(0, penalty - circle.score);
        }


        private void IncreaseScore(int points)
        {
            score += points;
        }

        private void RemoveCircle(Circle circle)
        {
            circle.Clicked = true; 
            Controls.Remove(circle);
            circle.Dispose();
        }


        private (Color color, int circle_score) GetRandomColorAndScore()
        {
            Color[] colors = { Color.LimeGreen, Color.IndianRed, Color.LightSteelBlue, Color.Yellow };
            int[] scores = { -20, 10, 0, 5 };

            int index = rand.Next(colors.Length);

            Color color = colors[index];
            int circle_score = scores[index];

            return (color, circle_score);
        }

        private void Draw(Graphics graphics)
        {
            scoreLabel.Text = "Рахунок: " + score ;
            penaltyLabel.Text = "Штраф: " + penalty; 
           
        }
        private void stopbutton_Click(object sender, EventArgs e)
        {
            GameOver();
            Close();
        }

        private void GameOver()
        {
            gameStopped= true;
            gameTimer.Stop();
            gameOverLabel.Size = new Size(300, 150);
            gameOverLabel.Font = new Font("Arial", 42, FontStyle.Regular);

            gameOverLabel.Location = new Point(
                (ClientSize.Width - gameOverLabel.Width) / 2,
                (ClientSize.Height - gameOverLabel.Height) / 2
            );
            foreach (var circle in Controls.OfType<Circle>().ToList())
            {
                circle.Clicked = true;
                Controls.Remove(circle);
                circle.Dispose();
            }
            gameOverLabel.Visible = true;
            restartButton.Visible = true;
        }

        private void GameLoop(object sender, EventArgs e)
        {
            CreateCircle();
        }

        
        private void restartButton_Click_1(object sender, EventArgs e)
        {
            gameOverLabel.Visible = false;
            restartButton.Visible = false;

            score = 0;
            penalty = 0;
            //penaltyLabel.Text = "Штраф: " + penalty;

            gameStopped = false;
            gameTimer.Interval = interval;
            gameTimer.Start();
        }




    }
}

