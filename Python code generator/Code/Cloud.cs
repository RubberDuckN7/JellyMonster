using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using IrisEngine;

namespace Jelly_Monster
{
    public  class Cloud
    {

		float wait_time;
		byte state;

		public Cloud()
		{
		
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
		
	}
}