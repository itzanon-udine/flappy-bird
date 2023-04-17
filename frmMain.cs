using WinFlappyBird.Properties;

namespace WinFlappyBird
{
    public partial class frmMain : Form
    {
        int pipeSpeed = 15;
        int gravity = 1;
        int birdSpeed = 0;
        int score = 0;

        static readonly Random random = new Random();

        public frmMain()
        {
            InitializeComponent();
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
            if (bird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                bird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                bird.Bounds.IntersectsWith(ground.Bounds))
            {

                //GameOver
                gameTimer.Enabled = false;
                bird.Enabled = false;
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
            //Sbatto le ali, bird sale verso l'alto
            if (e.KeyCode== Keys.Space)
            {
                birdSpeed = -10;
            }

        }

    }
}