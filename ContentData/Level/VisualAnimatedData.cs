using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class VisualAnimatedData : ContentObject
    {
		private List<string> path = new List<string>();
		private Vector2 extents;

		public List<string> Path
		{
			get { return path; }
			set { path = value; }
		}
		
		public Vector2 Extents
		{
			get { return extents; }
			set { extents = value; }
		}
		

		public class VisualAnimatedDataReader : ContentTypeReader<VisualAnimatedData>
        {
            protected override VisualAnimatedData Read(ContentReader input,
                VisualAnimatedData existingInstance)
            {
                VisualAnimatedData desc = existingInstance;
                if (desc == null)
                {
                    desc = new VisualAnimatedData();
                }

				// List<string> path
				// Vector2 extents

                desc.Path.AddRange(input.ReadObject<List<string>>());
                desc.Extents = input.ReadObject<Vector2>();

                return desc;
            }
		}
	}
}
