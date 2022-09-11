using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using IrisEngine;

namespace Jelly_Monster
{
    public  class Wizard
    {

		Vector2 bullet_pos;
		Vector2 bullet_dir;
		float wait_time;
		byte state;
		bool fired;

		public Wizard()
		{
		
		}
		
		public Vector2 Bullet_Pos
		{
			get { return bullet_pos; }
			set { bullet_pos = value; }
		}
		
		public Vector2 Bullet_Dir
		{
			get { return bullet_dir; }
			set { bullet_dir = value; }
		}
		
		public float Wait_Time
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