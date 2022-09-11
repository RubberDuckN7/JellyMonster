using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class WormTypeData : ContentObject
    {
		private List<string> worm_monster_attacking = new List<string>();
		private string worm_waiting;
		private string acid_bullet;
		private Vector2 extents;
		private float bullet_speed;
		private float fire_rate;

		public List<string> Worm_Monster_Attacking
		{
			get { return worm_monster_attacking; }
			set { worm_monster_attacking = value; }
		}
		
		public string Worm_Waiting
		{
			get { return worm_waiting; }
			set { worm_waiting = value; }
		}
		
		public string Acid_Bullet
		{
			get { return acid_bullet; }
			set { acid_bullet = value; }
		}
		
		public Vector2 Extents
		{
			get { return extents; }
			set { extents = value; }
		}
		
		public float Bullet_Speed
		{
			get { return bullet_speed; }
			set { bullet_speed = value; }
		}
		
		public float Fire_Rate
		{
			get { return fire_rate; }
			set { fire_rate = value; }
		}
		

		public class WormTypeDataReader : ContentTypeReader<WormTypeData>
        {
            protected override WormTypeData Read(ContentReader input,
                WormTypeData existingInstance)
            {
                WormTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new WormTypeData();
                }

				// List<string> worm_monster_attacking
				// string worm_waiting
				// string acid_bullet
				// Vector2 extents
				// float bullet_speed
				// float fire_rate

                return desc;
            }
		}
	}
}
