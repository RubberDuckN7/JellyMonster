using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ContentData;

namespace Jelly_Monster
{
    public class DemonEye : Enemy
    {
        float wait_time;
        byte state;

        public DemonEye(EnemyInstanceData data)
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

            if (this.facing_front)
            {
                //this.Core.End.Y = (float)(data.End.X - (data.Start.X + extents.X)); 
            }
            else
            {
                //this.core.End.Y = (float)(data.Start.X - data.End.X);
            }

            time.Length = 0.1f;

            wait_time = 0f;
            state = 0;
        }

        public float WaitTime
        {
            get { return wait_time; }
            set { wait_time = value; }
        }

        public byte State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
