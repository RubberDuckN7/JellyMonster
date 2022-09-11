using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class SawWheelTypeData : ContentObject
    {
		private List<string> saw_wheel_walking = new List<string>();
		private Vector2 extents;
		private float speed;

		public List<string> Saw_Wheel_Walking
		{
			get { return saw_wheel_walking; }
			set { saw_wheel_walking = value; }
		}
		
		public Vector2 Extents
		{
			get { return extents; }
			set { extents = value; }
		}
		
		public float Speed
		{
			get { return speed; }
			set { speed = value; }
		}
		

		public class SawWheelTypeDataReader : ContentTypeReader<SawWheelTypeData>
        {
            protected override SawWheelTypeData Read(ContentReader input,
                SawWheelTypeData existingInstance)
            {
                SawWheelTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new SawWheelTypeData();
                }

				// List<string> saw_wheel_walking
				// Vector2 extents
				// float speed

                desc.Saw_Wheel_Walking.AddRange(input.ReadObject<List<string>>());
                desc.Extents = input.ReadObject<Vector2>();
                desc.Speed = input.ReadSingle();

                return desc;
            }
		}
	}
}
