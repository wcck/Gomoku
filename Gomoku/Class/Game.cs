using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
	class Game
	{
		private PieceType currentPlayer = PieceType.BLACK;
		private PieceType winner = PieceType.NONE;
		private Board board = new Board();
		public PieceType Winner { get { return winner; } }


		public bool CanBePlaced(int x, int y)
		{
			return board.CanBePlaced(x, y);
		}

		public Piece PlaceAPiece(int x, int y)
		{
			Piece piece = board.PlaceAPiece(x, y, currentPlayer);
			if (piece != null)
			{				
				checkWinner();

				if (currentPlayer == PieceType.BLACK)
				{
					currentPlayer = PieceType.WHITE;
				}
				else
				{
					currentPlayer = PieceType.BLACK;
				}

				return piece;
			}
			return null;
		}

		private void checkWinner()
		{
			int centerX = board.LastPlaceNode.X;
			int centerY = board.LastPlaceNode.Y;

			// Check 8 diffrent direct
			for (int xDir = -1; xDir <= 1; xDir++)
			{
				for (int yDir = -1; yDir <= 1; yDir++)
				{
					// Remove middle condition
					if (xDir == 0 && yDir == 0)
					{
						continue;
					}
					
					// Record number of same pice
					int count = 1;
					while (count < 5)
					{
						int targetX = centerX + (count * xDir);
						int targetY = centerY + (count * yDir);
						//
						if (targetX < 0 || targetX >= Board.NODE_COUNT ||
							targetY < 0 || targetY >= Board.NODE_COUNT ||
							board.GetPieceType(targetX, targetY) != currentPlayer)
						{
							break;
						}
						count++;
					}

					// Check wether achice 5
					if (count == 5)
					{
						winner = currentPlayer;
					}
				}				
			}			
		}
	}
}
