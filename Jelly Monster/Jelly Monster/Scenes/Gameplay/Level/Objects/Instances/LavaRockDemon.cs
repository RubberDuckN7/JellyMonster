using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ContentData;

namespace Jelly_Monster
{
    public class LavaRockDemon : Enemy
    {
        public LavaRockDemon(EnemyInstanceData data)
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

            time.Length = 0.1f;
        }
    }
}
