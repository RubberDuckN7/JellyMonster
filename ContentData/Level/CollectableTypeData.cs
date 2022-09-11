using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class CollectableTypeData : ContentObject
    {
        private Vector2 extents;
		private string path;
		private byte score;

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
		
		public byte Score
		{
			get { return score; }
			set { score = value; }
		}
		

		public class CollectableTypeDataReader : ContentTypeReader<CollectableTypeData>
        {
            protected override CollectableTypeData Read(ContentReader input,
                CollectableTypeData existingInstance)
            {
                CollectableTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new CollectableTypeData();
                }

				// string path
				// byte score

                desc.Extents = input.ReadObject<Vector2>();
                desc.Path = input.ReadString();
                desc.Score = input.ReadByte();

                return desc;
            }
		}
	}
}
