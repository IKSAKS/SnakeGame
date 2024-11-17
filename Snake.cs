using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace SnakeGame
{
    public class Snake : PictureBox
    {
        Main main;
        Snake child;
        private Boolean lastDirectionY = false; // up or down
        private Boolean lastDirectionMain = false; // up or left
        private Boolean firstMove = true;
        Boolean head;
        int speed = 20;
        public Snake(Main main, Boolean head = false)
        {
            this.head = head;
            this.main = main;
            this.Size = new Size(20, 20);
            this.BackColor = Color.Transparent;
            this.BackgroundImage = Properties.Resources.bg;
            this.SendToBack();
            if (head)
            {
                this.BackgroundImage = Properties.Resources.snakeHeadRight;
                this.BringToFront();
            }
            main.AddSnake(this);
            
        }

        

        public void UpdateLastDirection(Boolean lastDirectionY, Boolean lastDirectionMain) {
            this.lastDirectionMain = lastDirectionMain;
            this.lastDirectionY = lastDirectionY;
        }
        public void Update(Boolean directionY, Boolean directionMain, Boolean nextDirectionY, Boolean nextDirectionMain)
        {
            this.BringToFront();
            if (directionY && directionMain)
            {
                this.Top -= speed;
                if (!nextDirectionY)
                {
                    if(!nextDirectionMain) this.BackgroundImage = Properties.Resources.snakeButtomRight;
                    else this.BackgroundImage = Properties.Resources.snakeButtonLeft;
                }else
                this.BackgroundImage = Properties.Resources.bodyVertical;
            }
            else if (directionY && !directionMain)
            {
                this.Top += speed;
                if (!nextDirectionY)
                {
                    if (!nextDirectionMain) this.BackgroundImage = Properties.Resources.snakeTopRight; 
                    else this.BackgroundImage = Properties.Resources.snakeTopLeft; 
                }
                else
                this.BackgroundImage = Properties.Resources.bodyVertical;
            }
            else if (!directionY && directionMain)
            {
                this.Left -= speed;

                if (nextDirectionY)
                {
                    if (nextDirectionMain) this.BackgroundImage = Properties.Resources.snakeTopRight;
                    else this.BackgroundImage = Properties.Resources.snakeButtomRight;
                }
                else
                this.BackgroundImage = Properties.Resources.bodyHorizontal;
            }
            else if (!directionY && !directionMain)
            {
                this.Left += speed;

                if (nextDirectionY)
                {
                    if (nextDirectionMain) this.BackgroundImage = Properties.Resources.snakeTopLeft;
                    else this.BackgroundImage = Properties.Resources.snakeButtonLeft;
                }
                else
                    this.BackgroundImage = Properties.Resources.bodyHorizontal;

            }
            if (child != null)
            {
                if (!firstMove)
                {
                    child.Update(lastDirectionY, lastDirectionMain, directionY, directionMain);
                }
                firstMove = false;
            }
            if (head)
            {
                if (directionY && directionMain)
                {
                    this.BackgroundImage = Properties.Resources.snakeHeadUp;
                }
                else if (directionY && !directionMain)
                {
                    this.BackgroundImage = Properties.Resources.snakeHeadDown;
                }
                else if (!directionY && directionMain)
                {
                    this.BackgroundImage = Properties.Resources.snakeHeadLeft;
                }
                else if (!directionY && !directionMain)
                {
                    this.BackgroundImage = Properties.Resources.snakeHeadRight;
                }
            }
            lastDirectionY = directionY;
            lastDirectionMain = directionMain;
        }

        public void Grow()
        {
            Random r = new Random();
            child = new Snake(main);
            child.Left = this.Left;
            child.Top = this.Top;
        }

    }
}
