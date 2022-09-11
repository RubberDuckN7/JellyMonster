using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ContentData;

namespace Jelly_Monster
{
    public class SawWheel : Enemy
    {
        bool dir_left; 
		public SawWheel(EnemyInstanceData data)
		{
            this.core = data;
            this.time = new Time();
            this.pos = data.Start;
            this.depth = data.Depth;
            this.id = data.Id;

            if (data.Start.X < data.End.X)
                this.facing_front = true;
            else
                this.facing_front = false;

            this.dir_left = !this.facing_front;

            time.Length = 0.02f;	
		}

        public bool DirLeft
        {
            get { return dir_left; }
        }
	}
}