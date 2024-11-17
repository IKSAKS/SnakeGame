﻿using System;
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
        List<Food> foods = new List<Food>();
        List<Snake> snakes = new List<Snake>();
        Snake snakeHead;
        Area area;
        int score;
        Label scoreLabel;
        private Boolean directionY = false; // up or down
        private Boolean directionMain = false; // up or left
        Keys keys = Keys.None;
        int areaSize = 25;
        public Main()
        {
            InitializeComponent();
            InitializeGame();
            InitializeText();
            int borderWidth = this.Width - this.ClientSize.Width;
            int borderHeight = this.Height - this.ClientSize.Height;
            this.Size = new Size(500 + borderWidth, 500 + borderHeight);
        }
        private void InitializeText()
        {
            scoreLabel = new Label();
            scoreLabel.Location = new Point(12, 9);
            scoreLabel.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
            scoreLabel.AutoSize = true;
            scoreLabel.Text = "Score: 0";
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
            this.Controls.Add(food);
            food.BringToFront();
            foods.Add(food);
        }
        
        private void SnakeFoodCollision()
        {
            foreach (Food food in foods)
            {
                if (!snakeHead.Bounds.IntersectsWith(food.Bounds)) return;
                GrowSnake();
                score++;
                foods.Remove(food);
                this.Controls.Remove(food);
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
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
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
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.Location.ToString();
        }

       
    }
}
