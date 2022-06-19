using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
	public partial class MainForm : Form
	{
		//private bool isBlack = true;
		private Game game = new Game();

		public MainForm()
		{
			InitializeComponent();

			/*
			this.Controls.Add(new BlackPices(10, 20));
			this.Controls.Add(new WhitePices(150, 200));
			*/
		}

		// Exchange pices 
		private void MainForm_MouseDown(object sender, MouseEventArgs e)
		{

			Piece piece = game.PlaceAPiece(e.X, e.Y);
			if (piece != null)
			{
				this.Controls.Add(piece);

				// Check winner
				if (game.Winner == PieceType.BLACK)
				{
					MessageBox.Show("Black is winner.");
				}
				else if (game.Winner == PieceType.WHITE)
				{
					MessageBox.Show("White is winner.");
				}
			}						
		}

		// Show hand behavior
		private void MainForm_MouseMove(object sender, MouseEventArgs e)
		{
			if (game.CanBePlaced(e.X, e.Y))
			{
				this.Cursor = Cursors.Hand;
			}
			else
			{
				this.Cursor = Cursors.Default;
			}
		}
	}
}
