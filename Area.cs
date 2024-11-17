using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeGame
{
    internal class Area : PictureBox
    {
        public Area()
        {
            this.Left = 0;
            this.Top = 0;
            this.Size = new Size(500, 500);
            this.BackgroundImage = Properties.Resources.bg;
            this.BackgroundImageLayout = ImageLayout.Tile;
            this.SendToBack();
        }
    }
}
