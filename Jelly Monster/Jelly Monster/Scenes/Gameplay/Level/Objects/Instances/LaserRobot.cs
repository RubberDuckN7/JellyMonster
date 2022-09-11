using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ContentData;

namespace Jelly_Monster
{
    public class LaserRobot : Enemy
    {
		Vector2 bullet_pos;
		Vector2 bullet_dir;
		float wait_time;
		byte state;
		bool fired;
        bool bullet_left;

        public LaserRobot(EnemyInstanceData data)
		{
            this.core = data;
            this.time = new Time();
            this.pos = data.Start;
            this.depth = data.Depth;
            this.id = data.Id;

            if (core.Start.X < core.End.X)
                this.facing_front = false;
            else
                this.facing_front = true;

            float range = 0f;
            if (!facing_front)
            {
                range = core.End.X - core.Start.X;
            }
            else
            {
                range = core.Start.X - core.End.X; 
            }

            //range = Math.Abs(range);
            core.End = new Vector2(range, range);
            this.time.Length = 0.1f;

            this.bullet_pos = Vector2.Zero;
            this.bullet_dir = Vector2.Zero;

            this.wait_time = 0f;
            this.state = 0;
            this.fired = false;		
		}

        public void Fire(Vector2 target, Vector2 extents)
        {
            fired = true;

            if (facing_front)
            {
                bullet_pos.X = Pos.X + extents.X - 20f;
                bullet_pos.Y = Pos.Y + extents.Y * 0.5f;
                bullet_dir = new Vector2(1f, 0f);
                bullet_left = false;
            }
            else
            {
                bullet_pos.X = Pos.X + 20f;
                bullet_pos.Y = Pos.Y + extents.Y * 0.5f;
                bullet_dir = new Vector2(-1f, 0f);
                bullet_left = true;
            }
            //bullet_dir.Normalize();
        }

		public Vector2 BulletPos
		{
			get { return bullet_pos; }
			set { bullet_pos = value; }
		}
		
		public Vector2 BulletDir
		{
			get { return bullet_dir; }
			set { bullet_dir = value; }
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
		
		public bool Fired
		{
			get { return fired; }
			set { fired = value; }
		}

        public bool BulletLeft
        {
            get { return bullet_left; }
        }
	}
}