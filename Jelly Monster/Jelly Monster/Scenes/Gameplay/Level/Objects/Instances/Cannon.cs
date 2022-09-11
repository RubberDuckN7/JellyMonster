using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ContentData;

namespace Jelly_Monster
{
    public class Cannon : Enemy
    {
		Vector2 bullet_pos;
		Vector2 bullet_dir;
		float wait_time;
		byte state;
		bool fired;

        public Cannon(EnemyInstanceData data)
		{
            this.core = data;
            this.time = new Time();
            this.pos = data.Start;
            this.depth = data.Depth;
            this.id = data.Id;

            if (core.Start.X > core.End.X)
                this.facing_front = false;
            else
                this.facing_front = true;

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
                bullet_pos.Y = Pos.Y + 5f;
                bullet_dir = new Vector2(1f, 0f);
            }
            else
            {
                bullet_pos.X = Pos.X + 20f;
                bullet_pos.Y = Pos.Y + 5f;
                bullet_dir = new Vector2(-1f, 0f);
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
		
	}
}