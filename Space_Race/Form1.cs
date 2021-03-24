using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Space_Race
{
    public partial class Form1 : Form
    {
        string gameState = "waiting";

        Random randGen = new Random();
        int randValue = 0;

        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        Pen WhitePen = new Pen(Color.White);
        Pen RedPen = new Pen(Color.Red);

        Pen drawPen = new Pen(Color.White);

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        int paddle1X = 170;
        int paddle1Y = 330;
        int player1Score = 0;
        int player2Score = 0;

        int paddle2X = 440;
        int paddle2Y = 330;

        int paddleWidth = 20;
        int paddleHeight = 50;
        int paddleSpeed = 4;

        //astroids
        List<int> astroidXList = new List<int>();
        List<int> astroidYList = new List<int>();

        List<int> astroid1XList = new List<int>();
        List<int> astroid1YList = new List<int>(); 

        List<int> astroidSpeedList = new List<int>();
        List<string> astroidColourList = new List<string>();

        int astroidWidth = 3;
        int astroidHeight = 2;

        public Form1()
        {
            InitializeComponent();
        }

        public void GameInitialize()
        {
            rocket1ScoreLabel.Text = "";
            rocket2ScoreLabel.Text = "";
            gameTimer.Enabled = true;
            gameState = "running";

            astroidXList.Clear();
            astroidYList.Clear();

            astroid1XList.Clear(); 
            astroid1YList.Clear();

            astroidSpeedList.Clear();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //check to see if a new astroid should be created 
            randValue = randGen.Next(0, 101);

            if (randValue < 10)
            {
                astroidYList.Add(randGen.Next(0, this.Height - 50));
                astroidXList.Add(10);
                astroidSpeedList.Add(randGen.Next(2, 10));

                astroidYList.Add(randGen.Next(0, this.Height - 50)); 
                astroidXList.Add(660);

                astroidSpeedList.Add(randGen.Next(-10, -2));
                astroidColourList.Add("white");
            }

            for (int i = 0; i < astroidXList.Count(); i++)
            {
                astroidXList[i] += astroidSpeedList[i];
            }

            if (upArrowDown == true && paddle1Y > 0)
            {
                paddle1Y -= paddleSpeed;
            }

            if (downArrowDown == true && paddle1Y < this.Height - paddleHeight)
            {
                paddle1Y += paddleSpeed;
            }

            if (wDown == true && paddle2Y > 0)
            {
                paddle2Y -= paddleSpeed;
            }

            if (sDown == true && paddle2Y < this.Height - paddleHeight)
            {
                paddle2Y += paddleSpeed;
            }

            //if rocket and metiorite hit
            Rectangle paddle1Rec = new Rectangle(paddle1X, paddle1Y, paddleWidth, paddleHeight);
            Rectangle paddle2Rec = new Rectangle(paddle2X, paddle2Y, paddleWidth, paddleHeight);
             
            for (int i = 0; i < astroidYList.Count; i++)
            {
                Rectangle astroidRec = new Rectangle(astroidXList[i], astroidYList[i], astroidWidth, astroidHeight);

                if (paddle1Rec.IntersectsWith(astroidRec))
                { 
                    paddle1Y = 330;
                    SoundPlayer Player = new SoundPlayer(Properties.Resources._253886__themusicalnomad__negative_beeps);
                    Player.Play();
                }
            }

            for (int i = 0; i < astroidYList.Count; i++)
            {
                Rectangle astroidRec = new Rectangle(astroidXList[i], astroidYList[i], astroidWidth, astroidHeight);

                if (paddle2Rec.IntersectsWith(astroidRec))
                {
                    paddle2Y = 330;
                    SoundPlayer Player = new SoundPlayer(Properties.Resources._253886__themusicalnomad__negative_beeps);
                    Player.Play();
                }
            }

            //rocket reaches end of screen (scores point)
            if (paddle1Y < 0)
            {
                player1Score = player1Score + 1;
                rocket1ScoreLabel.Text = $"{player1Score}";
                paddle1Y = 330;
                SoundPlayer Player = new SoundPlayer(Properties.Resources._488227__plumaudio__happy_blip__1_);
                Player.Play();

            }

            if (paddle2Y < 0)
            {
                player2Score = player2Score + 1;
                rocket2ScoreLabel.Text = $"{player2Score}";
                paddle2Y = 330;
                SoundPlayer Player = new SoundPlayer(Properties.Resources._488227__plumaudio__happy_blip__1_);
                Player.Play();
            }

            //if player reaches a score of 3
            if (player1Score == 3) 
            {
                gameState = "winner";
                winnrLabel.Text = "Player 1 Congratulations";
            }

            if (player2Score == 3)
            {
                gameState = "winner";
                winnrLabel.Text = "Player 2 Congratulations";
            }
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "winner")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "winner")
                    {
                        Application.Exit();
                    }
                    break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                titleLabel.Text = "SPACE RACE :)";
                subTitleLabel.Text = "Press Space Bar to Start or Escape to Exit";
            }
            else if (gameState == "running")
            {
                // draw text at top 
                titleLabel.Text = $" ";
                subTitleLabel.Text = $" ";
                winnrLabel.Text = " ";

                e.Graphics.DrawRectangle(drawPen, paddle1X, paddle1Y, paddleWidth, paddleHeight);
                e.Graphics.DrawRectangle(drawPen, paddle2X, paddle2Y, paddleWidth, paddleHeight);

                for (int i = 0; i < astroidYList.Count(); i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, astroidXList[i], astroidYList[i], astroidWidth, astroidHeight);
                }
            }
            else if (gameState == "over")
            {
                titleLabel.Text = "GAME OVER";
                subTitleLabel.Text += "\nPress Space Bar to Start or Escape to Exit";
                rocket1ScoreLabel.Text = " ";
                rocket2ScoreLabel.Text = " ";
            }
            else if (gameState == "winner")
            { 
                titleLabel.Text = "WINNER";
                subTitleLabel.Text += "\nPress Space Bar to Start or Escape to Exit";
                rocket1ScoreLabel.Text = " ";
                rocket2ScoreLabel.Text = " ";
            }
        }
    }
}

