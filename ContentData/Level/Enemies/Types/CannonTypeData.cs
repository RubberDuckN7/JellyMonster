using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class CannonTypeData : ContentObject
    {
		private List<string> cannon_waiting = new List<string>();
		private List<string> cannon_attacking = new List<string>();
		private string cannon_ball;
		private Vector2 extents;
		private float ball_speed;
		private float fire_rate;

		public List<string> Cannon_Waiting
		{
			get { return cannon_waiting; }
			set { cannon_waiting = value; }
		}
		
		public List<string> Cannon_Attacking
		{
			get { return cannon_attacking; }
			set { cannon_attacking = value; }
		}
		
		public string Cannon_Ball
		{
			get { return cannon_ball; }
			set { cannon_ball = value; }
		}
		
		public Vector2 Extents
		{
			get { return extents; }
			set { extents = value; }
		}
		
		public float Ball_Speed
		{
			get { return ball_speed; }
			set { ball_speed = value; }
		}
		
		public float Fire_Rate
		{
			get { return fire_rate; }
			set { fire_rate = value; }
		}
		

		public class CannonTypeDataReader : ContentTypeReader<CannonTypeData>
        {
            protected override CannonTypeData Read(ContentReader input,
                CannonTypeData existingInstance)
            {
                CannonTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new CannonTypeData();
                }

                desc.Cannon_Waiting.AddRange(input.ReadObject<List<string>>());
                desc.Cannon_Attacking.AddRange(input.ReadObject<List<string>>());
                desc.Cannon_Ball = input.ReadString();
                desc.Extents = input.ReadObject<Vector2>();
                desc.Ball_Speed = input.ReadSingle();
                desc.Fire_Rate = input.ReadSingle();

				// List<string> cannon_waiting
				// List<string> cannon_attacking
				// string cannon_ball
				// Vector2 extents
				// float ball_speed
				// float fire_rate

                return desc;
            }
		}
	}
}
