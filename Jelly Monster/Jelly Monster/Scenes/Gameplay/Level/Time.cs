using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using IrisEngine;

namespace Jelly_Monster
{
    public class MinuteCounter
    {
        private byte minutes;
        private byte seconds;

        public MinuteCounter()
        {
            minutes = 0;
            seconds = 0;
        }

        public void Tick()
        {
            seconds += 1;
            if (seconds >= 60)
            {
                minutes += 1;
                seconds = 0;
            }
        }

        public byte Min
        {
            get { return minutes; }
            set { minutes = value; }
        }

        public byte Sec
        {
            get { return seconds; }
            set { seconds = value; }
        }
    }

    public  class Time
    {
		float time;
		float length;

		public Time()
		{
            time = 0f;
            length = 1f;
		}

        public bool Tick(float dt)
        {
            time += dt;

            if (time >= length)
            {
                time = 0f;
                return true;
            }

            return false;
        }
		
		public float TimeF
		{
			get { return time; }
			set { time = value; }
		}
		
		public float Length
		{
			get { return length; }
			set { length = value; }
		}
		
	}
}