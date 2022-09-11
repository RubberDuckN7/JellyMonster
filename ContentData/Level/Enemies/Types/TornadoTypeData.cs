using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class TornadoTypeData : ContentObject
    {
		private List<string> tornado_moving = new List<string>();
		private Vector2 extents;
		private float speed;

		public List<string> Tornado_Moving
		{
			get { return tornado_moving; }
			set { tornado_moving = value; }
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
		

		public class TornadoTypeDataReader : ContentTypeReader<TornadoTypeData>
        {
            protected override TornadoTypeData Read(ContentReader input,
                TornadoTypeData existingInstance)
            {
                TornadoTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new TornadoTypeData();
                }

				// List<string> tornado_moving
				// Vector2 extents
				// float speed

                desc.Tornado_Moving.AddRange(input.ReadObject<List<string>>());
                desc.Extents = input.ReadObject<Vector2>();
                desc.Speed = input.ReadSingle();

                return desc;
            }
		}
	}
}
