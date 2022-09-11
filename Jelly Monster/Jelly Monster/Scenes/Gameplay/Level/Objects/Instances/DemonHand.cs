using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ContentData;

namespace Jelly_Monster
{
    public class DemonHand : Enemy
    {
        public class Hand
        {

            public Vector2 pos;
            public float lerp;
            public byte state;
            public bool extending_left;
            public bool active;

            public Hand(Vector2 pos)
            {
                this.pos = pos;
                lerp = 0.0f;
                state = 0;
                active = false;
            }
        }

        Hand hand;
        public bool left;

        public DemonHand(EnemyInstanceData data)
		{
            this.core = data;
            this.time = new Time();
            this.pos = data.Start;
            this.depth = data.Depth;
            this.id = data.Id;

            this.facing_front = false;

            this.time.Length = 0.07f;

            if (this.core.Start.X < this.core.End.X)
                this.left = false;
            else
                this.left = true;

            float trange = 0f;
            if (left)
            {
                trange = this.core.Start.X - this.core.End.X;
            }
            else
            {
                trange = this.core.End.X - this.core.Start.X;
            }

            this.core.End = new Vector2(trange, trange);

            hand = new Hand(data.Start);
		}

        public Hand Claw
        {
            get { return hand; }
            set { hand = value; }
        }

        public bool Left
        {
            get { return left; }
        }
	}
}