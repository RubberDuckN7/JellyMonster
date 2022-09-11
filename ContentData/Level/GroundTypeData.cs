using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class GroundTypeData : ContentObject
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
		

		public class GroundTypeDataReader : ContentTypeReader<GroundTypeData>
        {
            protected override GroundTypeData Read(ContentReader input,
                GroundTypeData existingInstance)
            {
                GroundTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new GroundTypeData();
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
