namespace WinFlappyBird
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components=new System.ComponentModel.Container();
            ground=new Panel();
            lblScore=new Label();
            pipeBottom=new PictureBox();
            pipeTop=new PictureBox();
            bird=new PictureBox();
            gameTimer=new System.Windows.Forms.Timer(components);
            ground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pipeBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pipeTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bird).BeginInit();
            SuspendLayout();
            // 
            // ground
            // 
            ground.BackColor=Color.Transparent;
            ground.BackgroundImage=Properties.Resources.ground;
            ground.Controls.Add(lblScore);
            ground.Dock=DockStyle.Bottom;
            ground.Location=new Point(0, 572);
            ground.Name="ground";
            ground.Size=new Size(553, 113);
            ground.TabIndex=0;
            // 
            // lblScore
            // 
            lblScore.AutoSize=true;
            lblScore.Location=new Point(12, 39);
            lblScore.Name="lblScore";
            lblScore.Size=new Size(91, 30);
            lblScore.TabIndex=0;
            lblScore.Text="Score: 0";
            // 
            // pipeBottom
            // 
            pipeBottom.Anchor=AnchorStyles.Bottom|AnchorStyles.Left;
            pipeBottom.BackColor=Color.Transparent;
            pipeBottom.BackgroundImage=Properties.Resources.pipe;
            pipeBottom.BackgroundImageLayout=ImageLayout.Zoom;
            pipeBottom.Location=new Point(279, 404);
            pipeBottom.Name="pipeBottom";
            pipeBottom.Size=new Size(95, 269);
            pipeBottom.TabIndex=1;
            pipeBottom.TabStop=false;
            // 
            // pipeTop
            // 
            pipeTop.BackColor=Color.Transparent;
            pipeTop.BackgroundImage=Properties.Resources.pipedown;
            pipeTop.BackgroundImageLayout=ImageLayout.Zoom;
            pipeTop.Location=new Point(332, -44);
            pipeTop.Name="pipeTop";
            pipeTop.Size=new Size(95, 269);
            pipeTop.TabIndex=2;
            pipeTop.TabStop=false;
            // 
            // bird
            // 
            bird.BackColor=Color.Transparent;
            bird.Image=Properties.Resources.grumpy_yellow;
            bird.Location=new Point(65, 257);
            bird.Name="bird";
            bird.Size=new Size(119, 103);
            bird.SizeMode=PictureBoxSizeMode.Zoom;
            bird.TabIndex=3;
            bird.TabStop=false;
            // 
            // gameTimer
            // 
            gameTimer.Enabled=true;
            gameTimer.Interval=50;
            gameTimer.Tick+=Update;
            // 
            // frmMain
            // 
            AutoScaleDimensions=new SizeF(12F, 30F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.Aqua;
            ClientSize=new Size(553, 685);
            Controls.Add(bird);
            Controls.Add(ground);
            Controls.Add(pipeBottom);
            Controls.Add(pipeTop);
            Font=new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            KeyPreview=true;
            Margin=new Padding(5, 6, 5, 6);
            Name="frmMain";
            Text="Flappy Bird";
            KeyDown+=keyDown;
            ground.ResumeLayout(false);
            ground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pipeBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)pipeTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)bird).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel ground;
        private Label lblScore;
        private PictureBox pipeBottom;
        private PictureBox pipeTop;
        private PictureBox bird;
        private System.Windows.Forms.Timer gameTimer;
    }
}