namespace SnakeGame
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.scoreLabel1 = new System.Windows.Forms.Label();
            this.upgradeLabel = new System.Windows.Forms.Label();
            this.upgradeMenu = new System.Windows.Forms.PictureBox();
            this.upgradeSpeed = new System.Windows.Forms.Button();
            this.speedLabel = new System.Windows.Forms.Label();
            this.foodLabel = new System.Windows.Forms.Label();
            this.upgradeFood = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.upgradeMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 500;
            this.gameTimer.Tick += new System.EventHandler(this.Update);
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameOverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.gameOverLabel.Location = new System.Drawing.Point(89, 142);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(305, 63);
            this.gameOverLabel.TabIndex = 0;
            this.gameOverLabel.Text = "Game Over";
            this.gameOverLabel.Visible = false;
            // 
            // scoreLabel1
            // 
            this.scoreLabel1.AutoSize = true;
            this.scoreLabel1.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel1.Location = new System.Drawing.Point(12, 9);
            this.scoreLabel1.Name = "scoreLabel1";
            this.scoreLabel1.Size = new System.Drawing.Size(115, 31);
            this.scoreLabel1.TabIndex = 1;
            this.scoreLabel1.Text = "Score: 0";
            this.scoreLabel1.Visible = false;
            // 
            // upgradeLabel
            // 
            this.upgradeLabel.AutoSize = true;
            this.upgradeLabel.Location = new System.Drawing.Point(418, 469);
            this.upgradeLabel.Name = "upgradeLabel";
            this.upgradeLabel.Size = new System.Drawing.Size(53, 13);
            this.upgradeLabel.TabIndex = 2;
            this.upgradeLabel.Text = "Upgrades";
            this.upgradeLabel.Click += new System.EventHandler(this.upgradeLabel_Click);
            // 
            // upgradeMenu
            // 
            this.upgradeMenu.Location = new System.Drawing.Point(-7, 497);
            this.upgradeMenu.Name = "upgradeMenu";
            this.upgradeMenu.Size = new System.Drawing.Size(527, 102);
            this.upgradeMenu.TabIndex = 3;
            this.upgradeMenu.TabStop = false;
            // 
            // upgradeSpeed
            // 
            this.upgradeSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upgradeSpeed.Location = new System.Drawing.Point(11, 532);
            this.upgradeSpeed.Name = "upgradeSpeed";
            this.upgradeSpeed.Size = new System.Drawing.Size(68, 47);
            this.upgradeSpeed.TabIndex = 4;
            this.upgradeSpeed.Text = "Upgrade Cost: 1";
            this.upgradeSpeed.UseVisualStyleBackColor = true;
            this.upgradeSpeed.Click += new System.EventHandler(this.upgradeSpeed_Click);
            this.upgradeSpeed.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.upgradeSpeed_PreviewKeyDown);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(14, 516);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(47, 13);
            this.speedLabel.TabIndex = 5;
            this.speedLabel.Text = "Speed 1";
            // 
            // foodLabel
            // 
            this.foodLabel.AutoSize = true;
            this.foodLabel.Location = new System.Drawing.Point(97, 516);
            this.foodLabel.Name = "foodLabel";
            this.foodLabel.Size = new System.Drawing.Size(45, 13);
            this.foodLabel.TabIndex = 7;
            this.foodLabel.Text = "Foods 1";
            this.foodLabel.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.upgradeSpeed_PreviewKeyDown);
            // 
            // upgradeFood
            // 
            this.upgradeFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upgradeFood.Location = new System.Drawing.Point(100, 532);
            this.upgradeFood.Name = "upgradeFood";
            this.upgradeFood.Size = new System.Drawing.Size(68, 47);
            this.upgradeFood.TabIndex = 6;
            this.upgradeFood.Text = "Upgrade Cost: 2";
            this.upgradeFood.UseVisualStyleBackColor = true;
            this.upgradeFood.Click += new System.EventHandler(this.upgradeFood_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 591);
            this.ControlBox = false;
            this.Controls.Add(this.foodLabel);
            this.Controls.Add(this.upgradeFood);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.upgradeSpeed);
            this.Controls.Add(this.upgradeMenu);
            this.Controls.Add(this.upgradeLabel);
            this.Controls.Add(this.scoreLabel1);
            this.Controls.Add(this.gameOverLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Snake Game";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.upgradeMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Label scoreLabel1;
        private System.Windows.Forms.Label upgradeLabel;
        private System.Windows.Forms.PictureBox upgradeMenu;
        private System.Windows.Forms.Button upgradeSpeed;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label foodLabel;
        private System.Windows.Forms.Button upgradeFood;
    }
}

