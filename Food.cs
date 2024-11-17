using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SnakeGame
{
    internal class Food : PictureBox
    {
        Random r = new Random();
        public Food() 
        {
            this.Size = new Size(20, 20);
            this.Left = r.Next(0, 24) * 20;
            this.Top = r.Next(0, 24) * 20;
            this.BackColor = Color.Red;
            
        }
    }
}
