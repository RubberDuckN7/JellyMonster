using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using IrisEngine;

namespace Jelly_Monster
{
    public  class DemonHand
    {

		byte state;

		public DemonHand()
		{
		
		}
		
		public byte State
		{
			get { return state; }
			set { state = value; }
		}
		
	}
}