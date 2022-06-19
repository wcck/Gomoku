using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gomoku
{
	class Board
	{
		public static readonly int NODE_COUNT = 9;
		private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
		private static readonly int OFFSET = 75;
		private static readonly int NODE_RADIUS = 10;
		private static readonly int NODE_DISTANCE = 75;

		// 2D matrix to record pieces positon
		private Piece[,] pices = new Piece[9, 9];

		//
		private Point lastPlaceNode = NO_MATCH_NODE;
		public Point LastPlaceNode { get { return lastPlaceNode; } }

		// Get piece type
		public PieceType GetPieceType(int nodeIDX, int nodeIDY)
		{
			if (pices[nodeIDX, nodeIDY] == null)
			{
				return PieceType.NONE;
			}
			else
			{
				return pices[nodeIDX, nodeIDY].GetPieceType();
			}
			
		}

		// For placing correct pices
		public bool CanBePlaced(int x, int y)
		{
			// To do find the close node
			Point nodeId = findTheClosetNode(x, y);

			// No, return false
			if (nodeId == NO_MATCH_NODE) return false;

			// No, indicate we had placed a pices in board and then return false
			if (pices[nodeId.X, nodeId.Y] != null) return false;

			// Yes, indicate we find it => check pices whether exist
			return true;
		}

		public Piece PlaceAPiece(int x, int y, PieceType type)
		{
			// To do find the close node
			Point nodeId = findTheClosetNode(x, y);

			// No, return null
			if (nodeId == NO_MATCH_NODE) return null;


			// Null, indicate we had placed a pices in board
			if (pices[nodeId.X, nodeId.Y] != null) return null;

			// According to type generate a piece that black or white
			Point formPos = convertCenterPosition(nodeId);
			if (type == PieceType.BLACK)
			{
				pices[nodeId.X, nodeId.Y] = new BlackPices(formPos.X, formPos.Y);
			}
			else
			{
				pices[nodeId.X, nodeId.Y] = new WhitePices(formPos.X, formPos.Y);
			}

			// Record last place piece
			lastPlaceNode = nodeId;

			return pices[nodeId.X, nodeId.Y];
		}

		// Convert center postion
		private Point convertCenterPosition(Point nodeID)
		{
			Point formPosition = new Point();
			formPosition.X = nodeID.X * NODE_DISTANCE + OFFSET;
			formPosition.Y = nodeID.Y * NODE_DISTANCE + OFFSET;
			return formPosition;
		}

		private Point findTheClosetNode(int x, int y)
		{
			int nodeIDX = findTheClosetNode(x);
			if (nodeIDX == -1)
			{
				return NO_MATCH_NODE;
			}
				

			int nodeIDY = findTheClosetNode(y);
			if (nodeIDY == -1)
			{
				return NO_MATCH_NODE;
			}
				

			return new Point(nodeIDX, nodeIDY);
		}	

		private int findTheClosetNode(int position)
		{
			if (position < OFFSET)
			{
				return -1;
			} 

			position -= OFFSET;

			int quotient = position / NODE_DISTANCE;
			int remainder = position % NODE_DISTANCE;

			if (remainder <= NODE_RADIUS)
			{
				return quotient;
			}
			else if (remainder >= NODE_DISTANCE - NODE_RADIUS)
			{
				return quotient + 1;
			}
			else
			{
				return -1;
			}				
		}
	}
}
