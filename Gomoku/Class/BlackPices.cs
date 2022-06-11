using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
	class BlackPices : Picecs
	{
		public BlackPices(int x, int y) : base(x, y)
		{
			this.Image = Properties.Resources.black;
		}
	}
}
