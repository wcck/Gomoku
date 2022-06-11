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
		private static readonly Point NO_MATCH_NODE = new Point(-1, -1);
		private static readonly int OFFSET = 75;
		private static readonly int NODE_RADIUS = 10;
		private static readonly int NODE_DISTANCE = 75;

		// For placing correct pices
		public bool CanBePlaced(int x, int y)
		{
			// To do find the close node
			Point nodeId = FindTheClosetNode(x, y);

			// No, return false
			if (nodeId == NO_MATCH_NODE) return false;

			// Yes, indicate we find it => check pices whether exist
			return true;
		}

		private Point FindTheClosetNode(int x, int y)
		{
			int nodeIdX = FindTheClosetNode(x);
			if (nodeIdX == -1)
				return NO_MATCH_NODE;

			int nodeIdY = FindTheClosetNode(y);
			if (nodeIdY == -1)
				return NO_MATCH_NODE;

			return new Point(nodeIdX, nodeIdY);
		}

		private int FindTheClosetNode(int position)
		{
			if (position < OFFSET) return -1;

			position -= OFFSET;

			int quotient = position / NODE_DISTANCE;
			int remainder = position % NODE_DISTANCE;

			if (remainder <= NODE_RADIUS) return quotient;
			else if (remainder >= NODE_DISTANCE - NODE_RADIUS) return quotient + 1;
			else return -1;
		}
	}
}
