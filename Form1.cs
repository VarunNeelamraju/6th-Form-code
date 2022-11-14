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

namespace C4
{
    public partial class Form1 : Form
    {

        Game game1 = new Game();
        //List of Games to save and redraw with
        List<Game> pieces;
        //constructor of the Form
        public Form1()
        {
            InitializeComponent();
            pieces = new List<Game>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            game1.drawBoard(e);
            foreach (Game piece in pieces)
            {
                piece.redrawGamePiece(e.Graphics);
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Color pcolor = new Color();
            Game piece = new Game(e.X, e.Y, pcolor);
            using (Graphics f = this.panel1.CreateGraphics())
            {
                game1.drawGamePiece(e, f);
                if (game1.player1)
                {
                    lblTurn.ForeColor = Color.Red;
                    lblTurn.Text = "Player 1's Turn";
                    pcolor = Color.Black;
                    pieces.Add(piece);
                }
                else
                {
                    lblTurn.ForeColor = Color.Black;
                    lblTurn.Text = "Player 2's Turn";
                    pcolor = Color.Red;
                    pieces.Add(piece);
                }
                if (game1.WinningPlayer() == Color.Red)
                {
                    MessageBox.Show("Red Player Wins", "Red Beat Black", MessageBoxButtons.OK);
                    game1.Reset();
                    panel1.Invalidate();
                }
                else if (game1.WinningPlayer() == Color.Black)
                {
                    MessageBox.Show("Black Player Wins", "Black Beat Red", MessageBoxButtons.OK);
                    game1.Reset();
                    panel1.Invalidate();
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

   