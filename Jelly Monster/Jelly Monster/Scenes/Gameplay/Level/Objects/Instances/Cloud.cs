using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ContentData;

namespace Jelly_Monster
{
    public class Cloud : Enemy
    {
		float state_time;
		byte state;
        bool thunder_left;

        bool dir_left;
        public Cloud(EnemyInstanceData data)
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

            time.Length = 0.07f;
            state_time = 0f;
            state = 0;
            thunder_left = false;
		}
		
		public float StateTime
		{
			get { return state_time; }
			set { state_time = value; }
		}
		
		public byte State
		{
			get { return state; }
			set { state = value; }
		}

        public bool ThunderLeft
        {
            get { return thunder_left; }
            set { thunder_left = value; }
        }

        public bool DirLeft
        {
            get { return dir_left; }
        }
	}
}