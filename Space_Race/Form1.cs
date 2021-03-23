using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        int timerLineX = 300;
        int timerLineY = 70;
        int timerLineWidth = 5;
        int timerLineHeight = 300;

        int time = 600;

        //astroids
        List<int> astroidXList = new List<int>();
        List<int> astroidYList = new List<int>();
        List<int> astroidSpeedList = new List<int>();
        List<string> astroidColourList = new List<string>();

        //List<int> astroidRightXList = new List<int>();
        //List<int> astroidRightYList = new List<int>();
        int counter = 0;
        int astroidLeftX = 100;
        int astroidLeftY = 350;

        int astroidRightX = 400;
        int astroidRightY = 10;

        int astroidWidth = 3;
        int astroidHeight = 2;
        int astroidSpeed = 4;


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
            astroidSpeedList.Clear();
            time = 600;

            //astroidYList.Add(300);

            //paddle2X = 440;
            //paddle2Y = 330;

            //ballX = this.Width / 2 - ballWidth / 2;
            // ballY = this.Height - ballHeight - ballHeight;
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



            //TO DO:
            //add sounds
            //dots coming from the right
            //state who winner is


            //if rocket and metiorite hit
            Rectangle paddle1Rec = new Rectangle(paddle1X, paddle1Y, paddleWidth, paddleHeight);
            Rectangle paddle2Rec = new Rectangle(paddle2X, paddle2Y, paddleWidth, paddleHeight);

            for (int i = 0; i < astroidYList.Count; i++)
            {
                Rectangle astroidRec = new Rectangle(astroidXList[i], astroidYList[i], astroidWidth, astroidHeight);

                if (paddle1Rec.IntersectsWith(astroidRec))
                {
                    paddle1Y = 330;
                }
            }

            for (int i = 0; i < astroidYList.Count; i++)
            {
                Rectangle astroidRec = new Rectangle(astroidXList[i], astroidYList[i], astroidWidth, astroidHeight);

                if (paddle2Rec.IntersectsWith(astroidRec))
                {
                    paddle2Y = 330;
                }
            }

            //rocket reaches end of screen (scores point)
            if (paddle1Y < 0)
            {
                player1Score = player1Score + 1;
                rocket1ScoreLabel.Text = $"{player1Score}";
                paddle1Y = 330;
            }

            if (paddle2Y < 0)
            {
                player2Score = player2Score + 1;
                rocket2ScoreLabel.Text = $"{player2Score}";
                paddle2Y = 330;
            }

            //if player reaches a score of 3
            if (player1Score == 3) 
            {
                gameState = "winner";
            }

            if (player2Score == 3)
            {
                gameState = "winner";
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
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
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
            }
            else if (gameState == "winner")
            { 
                titleLabel.Text = "WINNER";
                subTitleLabel.Text += "\nPress Space Bar to Start or Escape to Exit";
            }
        }

        ////rockets
        //e.Graphics.DrawRectangle(drawPen, paddle1X, paddle1Y, paddleWidth, paddleHeight);
        //e.Graphics.DrawRectangle(drawPen, paddle2X, paddle2Y, paddleWidth, paddleHeight);

        //    timer line
        //    e.Graphics.DrawRectangle(drawPen, timerLineX, timerLineY, timerLineWidth, timerLineHeight);
        //    e.Graphics.FillRectangle(whiteBrush, timerLineX, timerLineY, timerLineWidth, timerLineHeight);
    }
}

