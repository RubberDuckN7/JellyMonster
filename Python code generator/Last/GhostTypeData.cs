using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class GhostTypeData : ContentObject
    {
		private List<string> ghost_walking = new List<string>();
		private Vector2 extents;
		private float speed;

		public List<string> Ghost_Walking
		{
			get { return ghost_walking; }
			set { ghost_walking = value; }
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
		

		public class GhostTypeDataReader : ContentTypeReader<GhostTypeData>
        {
            protected override GhostTypeData Read(ContentReader input,
                GhostTypeData existingInstance)
            {
                GhostTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new GhostTypeData();
                }

				// List<string> ghost_walking
				// Vector2 extents
				// float speed

                return desc;
            }
		}
	}
}
