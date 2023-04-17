using WinFlappyBird.Properties;

namespace WinFlappyBird
{
    public partial class frmMain : Form
    {
        int pipeSpeed = 15;
        int gravity = 1;
        int birdSpeed = 0;
        int score = 0;
        bool canStart = true;

        static readonly Random random = new Random();

        public frmMain()
        {
            InitializeComponent();
        }

        private void Reset()
        {

            gameTimer.Enabled = false;
            angelTimer.Enabled = false;

            bird.Left = 65;
            bird.Top = 257;
            bird.Image=Resources.grumpy_yellow;
            bird.Enabled=false;
            pipeSpeed = 15;
            gravity = 1;
            birdSpeed = 0;
            score = 0;

            pipeTop.Left = 332;
            pipeBottom.Left = 279;
            lblScore.Text = "Score: 0";

            GameOver.Visible = false;
            GetReady.Visible = true;
            BestScore.Visible = false;
            canStart = true;

        }

        private void Start()
        {
            gameTimer.Enabled=true;
            bird.Enabled = true;
            canStart = false;
            GetReady.Visible=false;
            GameOver.Visible=false;
            BestScore.Visible=false;
        }

        private void Update(object sender, EventArgs e)
        {
            //Muovo i tubi verso sinistra
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;

            //Faccio cadere bird
            birdSpeed += gravity;
            bird.Top += birdSpeed;

            //Se i tubi escono dallo schermo li rimetto in fondo a destra
            if (pipeBottom.Left + pipeBottom.Width < 0) { pipeBottom.Left = this.Width + 75 * random.Next(5); }
            if (pipeTop.Left + pipeTop.Width < 0) { pipeTop.Left = this.Width + 75 * random.Next(5); }


            //Controllo collisioni 
            Rectangle collision = bird.Bounds;
            collision.Inflate(-20, -15);

            if (collision.IntersectsWith(pipeBottom.Bounds) ||
                collision.IntersectsWith(pipeTop.Bounds) ||
                collision.IntersectsWith(ground.Bounds))
            {

                //GameOver
                gameTimer.Enabled = false;

                //Timer per animazione angioletto
                bird.Image = Resources.angel;
                angelTimer.Enabled = true;

                //Salvo il punteggio
                if (score > Settings.Default.best_score)
                {
                    //Best Score!
                    Settings.Default.best_score = score;
                    Settings.Default.Save();
                    BestScore.Visible = true;
                }
                else
                {
                    GameOver.Visible = true;
                }

            }

            //Aumento punteggio quando bird supera con successo il tubo
            if (bird.Left > pipeBottom.Left + pipeBottom.Width && bird.Left <= pipeBottom.Left + pipeBottom.Width + pipeSpeed)
            {
                score++;
            }
            //Aumento punteggio quando bird supera con successo il tubo
            if (bird.Left > pipeTop.Left + pipeTop.Width && bird.Left <= pipeTop.Left + pipeTop.Width + 15)
            {
                score++;
            }

            lblScore.Text = "Score: " + score.ToString();
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (gameTimer.Enabled == false)
            {
                if (e.KeyCode== Keys.Space)
                {
                    if (canStart)
                    {
                        Start();
                    }
                    else
                    {
                        Reset();
                    }
                }
            }
            else
            {
                //Sbatto le ali, bird sale verso l'alto
                if (e.KeyCode== Keys.Space)
                {
                    birdSpeed = -10;
                }
            }

        }

        private void angelTimer_Tick(object sender, EventArgs e)
        {
            if (bird.Top + bird.Height <= 0)
            {
                angelTimer.Enabled = false;
                if (score == Settings.Default.best_score)
                {
                    GameOver.Visible = false;
                    BestScore.Visible = true;
                }
            }

            bird.Top -= 10;
            bird.Left += 10;

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            Reset();
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            //visualizzo il rettangolo di collisione
            //Rectangle collision = bird.Bounds;
            //collision.Inflate(-20, -15);
            //e.Graphics.DrawRectangle(Pens.Red, collision);
        }
    }
}