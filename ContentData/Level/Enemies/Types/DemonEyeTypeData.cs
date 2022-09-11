using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class DemonEyeTypeData : ContentObject
    {
		private List<string> animation_names = new List<string>();
        private List<string> animation_charging = new List<string>();
        private string eye_beam;
		private Vector2 extents;
		private float charge_speed;
		private float fire_speed;

		public List<string> Animation_Names
		{
			get { return animation_names; }
			set { animation_names = value; }
		}

        public List<string> Animation_Charging
        {
            get { return animation_charging; }
            set { animation_charging = value; }
        }

        public string Eye_Beam
        {
            get { return eye_beam; }
            set { eye_beam = value; }
        }

		public Vector2 Extents
		{
			get { return extents; }
			set { extents = value; }
		}
		
		public float Charge_Speed
		{
			get { return charge_speed; }
			set { charge_speed = value; }
		}
		
		public float Fire_Speed
		{
			get { return fire_speed; }
			set { fire_speed = value; }
		}
		

		public class DemonEyeTypeDataReader : ContentTypeReader<DemonEyeTypeData>
        {
            protected override DemonEyeTypeData Read(ContentReader input,
                DemonEyeTypeData existingInstance)
            {
                DemonEyeTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new DemonEyeTypeData();
                }

                desc.Animation_Names.AddRange(input.ReadObject<List<string>>());
                desc.Animation_Charging.AddRange(input.ReadObject<List<string>>());
                desc.Eye_Beam = input.ReadString();
                desc.Extents = input.ReadObject<Vector2>();
                desc.Charge_Speed = input.ReadSingle();
                desc.Fire_Speed = input.ReadSingle();

				// List<string> animation_names
				// Vector2 extents
				// float charge_speed
				// float fire_speed

                return desc;
            }
		}
	}
}
