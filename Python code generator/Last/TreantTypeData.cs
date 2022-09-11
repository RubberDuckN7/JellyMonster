using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class TreantTypeData : ContentObject
    {
		private List<string> treant_walking = new List<string>();
		private Vector2 extents;
		private float speed;

		public List<string> Treant_Walking
		{
			get { return treant_walking; }
			set { treant_walking = value; }
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
		

		public class TreantTypeDataReader : ContentTypeReader<TreantTypeData>
        {
            protected override TreantTypeData Read(ContentReader input,
                TreantTypeData existingInstance)
            {
                TreantTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new TreantTypeData();
                }

				// List<string> treant_walking
				// Vector2 extents
				// float speed

                return desc;
            }
		}
	}
}
