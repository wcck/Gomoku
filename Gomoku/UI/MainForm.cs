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
		private bool isBlack = true;
		private Board board = new Board();

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
			if (isBlack)
			{
				this.Controls.Add(new BlackPices(e.X, e.Y));
				isBlack = false;
			}
			else
			{
				this.Controls.Add(new WhitePices(e.X, e.Y));
				isBlack = true;
			}			
		}

		// Show hand behavior
		private void MainForm_MouseMove(object sender, MouseEventArgs e)
		{
			if (board.CanBePlaced(e.X, e.Y))
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
