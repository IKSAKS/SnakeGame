using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Main : Form
    {
        int speed = 1;
        int foodCount = 1;
        List<Food> foods = new List<Food>();
        List<Snake> snakes = new List<Snake>();
        Snake snakeHead;
        Area area;
        int score;
        Label scoreLabel;
        private Boolean directionY = false; // up or down
        private Boolean directionMain = false; // up or left
        private Boolean upgradeManuOpen = false;
        Keys keys = Keys.None;
        int areaSize = 25;
        public Main()
        {
            InitializeComponent();
            InitializeGame();
            InitializeText();
            InitializeButtons();
            InitializeUpgrades();


        }
        private void InitializeButtons()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.BackgroundImage = Properties.Resources.pauseButton;
            pictureBox.Size = new Size(40, 40);
            pictureBox.Left = (areaSize - 3) * 20;
            pictureBox.Top = 0;
            area.Controls.Add(pictureBox);
            pictureBox.BringToFront();
            pictureBox.Click += (sender, e) =>
            {
                pauseMenu();
            };
        }

        private void pauseMenu()
        {
            gameTimer.Stop();
            PictureBox pauseMenu = new PictureBox();
            pauseMenu.BackColor = Color.FromArgb(155, 0, 0, 0);
            pauseMenu.Size = new Size(500, 500);
            pauseMenu.Left = 0;
            pauseMenu.Top = 0;
            area.Controls.Add(pauseMenu);
            pauseMenu.BringToFront();
            Button cont = new Button();
            cont.Text = "Continue";
            cont.Top = 150;
            cont.Left = 170;
            cont.Size = new Size(150, 50);
            cont.BackColor = Color.FromArgb(6, 31, 54);
            cont.ForeColor = Color.FromArgb(229, 197, 168);
            cont.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
            pauseMenu.Controls.Add(cont);
            cont.Click += (senderP, eP) =>
            {
                gameTimer.Start();
                pauseMenu.Controls.Remove(cont);
                area.Controls.Remove(pauseMenu);
            };
            Button quit = new Button();
            quit.Text = "Quit";
            quit.Top = 210;
            quit.Left = 170;
            quit.Size = new Size(150, 50);
            quit.BackColor = Color.FromArgb(6, 31, 54);
            quit.ForeColor = Color.FromArgb(229, 197, 168);
            quit.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
            pauseMenu.Controls.Add(quit);
            quit.Click += (senderP, eP) =>
            {
                this.Close();
            };
        }
        private void InitializeUpgrades()
        {
            upgradeMenu.BackColor = Color.FromArgb(229, 197, 168);
        }
        private void InitializeText()
        {
            scoreLabel = new Label();
            scoreLabel.Location = new Point(12, 9);
            scoreLabel.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
            scoreLabel.AutoSize = true;
            scoreLabel.Text = "Score: 0";
            scoreLabel.ForeColor = Color.FromArgb(6, 31, 54);
            area.Controls.Add(scoreLabel);
            scoreLabel.BringToFront();
            scoreLabel.BackColor = Color.Transparent;
            gameOverLabel.BringToFront();
            gameOverLabel.BackColor = Color.Transparent;
            
        }
        private void InitializeGame()
        {
            area = new Area();
            Controls.Add(area);
            
            snakeHead = new Snake(this, true);
            snakeHead.Left = 100;
            snakeHead.Top = 100;
            spawnFood();
        }
        private void spawnFood()
        {
            Food food = new Food();
            area.Controls.Add(food);
            food.BringToFront();
            foods.Add(food);
        }
        
        private void SnakeFoodCollision()
        {
            foreach (Food food in foods)
            {
                if (!snakeHead.Bounds.IntersectsWith(food.Bounds)) continue;
                GrowSnake();
                score++;
                foods.Remove(food);
                area.Controls.Remove(food);
                food.Dispose();
                spawnFood();
                return;
            }
            
        }
        private void SnakeSnakeCollision()
        {
            for (int i = 1; i < snakes.Count(); i++)
            {
                Snake snake = snakes[i];
                if (!snakeHead.Bounds.IntersectsWith(snake.Bounds)) continue;
                GameOver();
                return;

            }

        }

        private void UpdateScore()
        {
            scoreLabel.Text = $"Score: {score}";
        }

        private void SnakeAreaCollision()
        {
            
            if (snakeHead.Bounds.IntersectsWith(area.Bounds)) return;
            GameOver();

        }

        private void GrowSnake()
        {
            Snake lastSnake = snakes.LastOrDefault();
            lastSnake.Grow();
        }

        public void AddSnake(Snake snake)
        {
            snakes.Add(snake);
            area.Controls.Add(snake);
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyCode.ToString());
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (directionY) return;
                    keys = e.KeyCode;
                    break;
                case Keys.Down:
                    if (directionY) return;
                    keys = e.KeyCode;
                    break;
                case Keys.Left:
                    if (!directionY) return;
                    keys = e.KeyCode;
                    break;
                case Keys.Right:
                    if (!directionY) return;
                    keys = e.KeyCode;
                    break;
            }
        }

        private void Update(object sender, EventArgs e)
        {
            UpdateDirection();
            MoveSnakeHead();
            SnakeSnakeCollision();
            SnakeFoodCollision();
            UpdateScore();
            SnakeAreaCollision();
            
        }

        private void UpdateDirection()
        {
            switch (keys)
            {
                case Keys.Up:
                    if (directionY) return;
                    directionY = true;
                    directionMain = true;
                    break;
                case Keys.Down:
                    if (directionY) return;
                    directionY = true;
                    directionMain = false;
                    break;
                case Keys.Left:
                    if (!directionY) return;
                    directionY = false;
                    directionMain = true;
                    break;
                case Keys.Right:
                    if (!directionY) return;
                    directionY = false;
                    directionMain = false;
                    break;
            }
        }

        private void MoveSnakeHead()
        {

            snakeHead.Update(directionY, directionMain, false, false);
        }

        private void GameOver()
        {
            gameTimer.Stop();
            gameOverLabel.Visible = true;
            pauseMenu();
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void upgradeLabel_Click(object sender, EventArgs e)
        {
            if (!upgradeManuOpen)
            {
                int borderWidth = this.Width - this.ClientSize.Width;
                int borderHeight = this.Height - this.ClientSize.Height;
                this.Size = new Size(500 + borderWidth, 600 + borderHeight);
                upgradeManuOpen = true;
            }
            else
            {
                int borderWidth = this.Width - this.ClientSize.Width;
                int borderHeight = this.Height - this.ClientSize.Height;
                this.Size = new Size(500 + borderWidth, 500 + borderHeight);
                upgradeManuOpen = false;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            int borderWidth = this.Width - this.ClientSize.Width;
            int borderHeight = this.Height - this.ClientSize.Height;
            this.Size = new Size(500 + borderWidth, 500 + borderHeight);
        }

        private void upgradeSpeed_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void upgradeSpeed_Click(object sender, EventArgs e)
        {
            int cost = speed;
            if (cost > score) return;
            score -= cost;
            UpdateScore();
            speed++;
            speedLabel.Text = $"Speed {speed}";
            int newCost = speed;
            upgradeSpeed.Text = $"Upgrade\nCost :{newCost}";
            gameTimer.Interval -= gameTimer.Interval / 10;
            this.Focus();
        }
        private void upgradeFood_Click(object sender, EventArgs e)
        {
            int cost = foodCount*2;
            if (cost > score) return;
            score -= cost;
            UpdateScore();
            foodCount++;
            foodLabel.Text = $"Foods {foodCount}";
            int newCost = foodCount*2;
            upgradeFood.Text = $"Upgrade\nCost :{newCost}";
            spawnFood();
            this.Focus();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu.Instance.Close();
        }
    }
}
