using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SnakeProt0type_1
{
    public partial class LvL2 : Form
    {
        private List<Shape> Snake = new List<Shape>(); //List holds information about the snake
        private Shape points = new Shape(); //List holds information about the points

        int maxWidth; //max width the snake can travel
        int maxHeight; //max height the snake can travel

        int score;
        int highScore;

        Random rand = new Random();

        bool Left, Right, Up, Down; // Boolean to check for directions 

        Form1 for1;
        public LvL2(Form1 f11)
        {
            for1 = f11;
            InitializeComponent();
        }

        private void LvL2_Load(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && GameSettings.directions != "right") //Allow it to move left and not right
            {
                Left = true;


            }
            if (e.KeyCode.ToString() == "a" && GameSettings.directions != "right") //Allow it to move left and not right
            {
                Left = true;


            }

            if (e.KeyCode == Keys.Right && GameSettings.directions != "left") //Allow it to move left and not right
            {
                Right = true;


            }
            if (e.KeyCode.ToString() == "d" && GameSettings.directions != "left") //Allow it to move left and not right
            {
                Right = true;


            }
            if (e.KeyCode == Keys.Up && GameSettings.directions != "down") //Allow it to move up and not down
            {
                Up = true;


            }
            if (e.KeyCode.ToString() == "w" && GameSettings.directions != "down") //Allow it to move left and not right
            {
                Up = true;


            }
            if (e.KeyCode == Keys.Down && GameSettings.directions != "up") //Allow it to move up and not down
            {
                Down = true;

            }
            if (e.KeyCode.ToString() == "s" && GameSettings.directions != "up") //Allow it to move left and not right
            {
                Down = true;


            }


        }

        private void KeyIsUp(object sender, KeyEventArgs e) // When keys are released stop moving
        {
            if (e.KeyCode == Keys.Left)
            {
                Left = false;

            }
            if (e.KeyCode.ToString() == "a")
            {
                Left = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                Right = false;

            }
            if(e.KeyCode.ToString() == "d")
            {
                Right = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                Up = false;

            }
            if(e.KeyCode.ToString() == "w")
            {
                Left = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                Down = false;

            }
            if(e.KeyCode.ToString() == "s")
            {
                Down = false;
            }

        }

        private void Startgame(object sender, EventArgs e)
        {
            RestartGame();
        }



        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (Left)
            {
                GameSettings.directions = "left";
                ;
            }
            if (Right)
            {
                GameSettings.directions = "right";
                ;
            }
            if (Down)
            {
                GameSettings.directions = "down";
                ;
            }
            if (Up)
            {
                GameSettings.directions = "up";
                ;
            }
            // end of directions

            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {

                    switch (GameSettings.directions)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                    }

                    if (Snake[i].X < 0)
                    {
                        //Snake[i].X = maxWidth;
                        GameOver();

                    }
                    if (Snake[i].X > maxWidth)
                    {
                        //Snake[i].X = 0;
                        GameOver();
                    }
                    if (Snake[i].Y < 0)
                    {
                        //Snake[i].Y = maxHeight;
                        GameOver();
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        //Snake[i].Y = 0;
                        GameOver();
                    }


                    if (Snake[i].X == points.X && Snake[i].Y == points.Y)
                    {
                        Points();
                    }

                    for (int j = 1; j < Snake.Count; j++)
                    {

                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }

                    }


                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }


            PicBox.Invalidate();
        }

        private void UpdateGraphics(object sender, PaintEventArgs e)
        {

            Graphics canvas = e.Graphics; //Graphics 

            Brush snakeColour; //Colour the snake

            for (int i = 0; i < Snake.Count; i++) //Depending on the size of the snake colour the snake with the colour
            {
                if (i == 0)
                {
                    snakeColour = Brushes.PeachPuff; //Colour of Head
                }
                else
                {
                    snakeColour = Brushes.LightBlue; //Colour of body
                }

                canvas.FillEllipse(snakeColour, new Rectangle  //Draw the snake on the board with colour depending on head or body
                    (
                    Snake[i].X * GameSettings.Width,
                    Snake[i].Y * GameSettings.Height,
                    GameSettings.Width, GameSettings.Height
                    ));
            }


            canvas.FillEllipse(Brushes.OrangeRed, new Rectangle //Draw the points on the board randomly
            (
            points.X * GameSettings.Width,
            points.Y * GameSettings.Height,
            GameSettings.Width, GameSettings.Height
            ));





        }

        



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PicBox_Click(object sender, EventArgs e)
        {

        }

        private void RestartGame() //Default settings

        {
            maxWidth = PicBox.Width / GameSettings.Width - 1; //For snake to transition on the other side of screen
            maxHeight = PicBox.Height / GameSettings.Height - 1; //For snake to transition on the other side of screen

            Snake.Clear(); //Start with new snake

            StartGame.Enabled = false; //So arrow key focus in on board
            SwitchForms.Enabled = false; //So arrow key focus in on board
            //btnSave.Enabled = false;
            score = 0;
            txtScore.Text = "Score: " + score; //Updates score

            Shape head = new Shape { X = 20, Y = 20 }; // Places snake around top right
            Snake.Add(head); // Adding the head part of the snake to the list

            for (int i = 0; i < 5; i++) //Adds 5 more parts to the snake
            {
                Shape body = new Shape();
                Snake.Add(body); //Follows the head of snake
            }

            points = new Shape { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) }; //random position of points within height and width

            Timer.Start(); //Starts timer

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void txtScore_Click(object sender, EventArgs e)
        {

        }

        private void SwitchForms_Click(object sender, EventArgs e)
        {
            for1.Show();
            Hide();
        }

        private void Points()
        {

            score += 1; //Increments points

            txtScore.Text = "Score: " + score; //Increments points

            Shape body = new Shape
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };

            Snake.Add(body); //Adds size to snake when collect points

            points = new Shape { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) }; //random position of points within height and width


        }

        private void GameOver() // Intialised when you collide head with body 
        {
            Timer.Stop();
            StartGame.Enabled = true;
            SwitchForms.Enabled = true;
            //btnSave.Enabled = true;

            if (score > highScore) //Updating highscore
            {
                highScore = score;

                txtHighScore.Text = "High Score: " + highScore;

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"\\admin5400\shares\redirected$\Students\Documents\vb6\My Documents\Visual Studio 2017\Code Snippets\Visual C#\Snake Prototypes\Snake Prot0type copy\blank.csv";
            string appendText = txtScore.Text + Environment.NewLine;
            File.AppendAllText(path, appendText);

            Console.ReadKey();
        }

    }
}
