using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class FireElementalDemonTypeData : ContentObject
    {
		private List<string> animation_names = new List<string>();
        private List<string> animation_attacking = new List<string>();
        private string bullet;
		private Vector2 extents;
		private float bullet_speed;
		private float fire_rate;

		public List<string> Animation_Names
		{
			get { return animation_names; }
			set { animation_names = value; }
		}

        public List<string> Animation_Attacking
        {
            get { return animation_attacking; }
            set { animation_attacking = value; }
        }

        public string Bullet
        {
            get { return bullet; }
            set { bullet = value; }
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
		

		public class FireElementalDemonTypeDataReader : ContentTypeReader<FireElementalDemonTypeData>
        {
            protected override FireElementalDemonTypeData Read(ContentReader input,
                FireElementalDemonTypeData existingInstance)
            {
                FireElementalDemonTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new FireElementalDemonTypeData();
                }

                desc.Animation_Names.AddRange(input.ReadObject<List<string>>());
                desc.Animation_Attacking.AddRange(input.ReadObject<List<string>>());
                desc.Bullet = input.ReadString();
                desc.Extents = input.ReadObject<Vector2>();
                desc.Bullet_Speed = input.ReadSingle();
                desc.Fire_Rate = input.ReadSingle();

				// List<string> animation_names
				// Vector2 extents
				// float bullet_speed
				// float fire_rate

                return desc;
            }
		}
	}
}
