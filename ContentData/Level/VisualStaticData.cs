using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class VisualStaticData : ContentObject
    {
		private Vector2 extents;
		private string path;

		public Vector2 Extents
		{
			get { return extents; }
			set { extents = value; }
		}
		
		public string Path
		{
			get { return path; }
			set { path = value; }
		}
		

		public class VisualStaticDataReader : ContentTypeReader<VisualStaticData>
        {
            protected override VisualStaticData Read(ContentReader input,
                VisualStaticData existingInstance)
            {
                VisualStaticData desc = existingInstance;
                if (desc == null)
                {
                    desc = new VisualStaticData();
                }

				// Vector2 extents
				// string path

                desc.Extents = input.ReadObject<Vector2>();
                desc.Path = input.ReadString();

                return desc;
            }
		}
	}
}
