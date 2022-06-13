using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Gomoku
{
	class BackgroundMusic
	{
		void Play()
		{
			// ref. https://blog.csdn.net/weixin_44017371/article/details/108369847
			// music source : https://www.free-stock-music.com/
			SoundPlayer sp = new SoundPlayer("music path");
			sp.PlayLooping();
		}		
	}
}
