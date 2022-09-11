using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class LavaRockDemonTypeData : ContentObject
    {
		private List<string> animation_names = new List<string>();
		private Vector2 extents;
		private float speed;

		public List<string> Animation_Names
		{
			get { return animation_names; }
			set { animation_names = value; }
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
		

		public class LavaRockDemonTypeDataReader : ContentTypeReader<LavaRockDemonTypeData>
        {
            protected override LavaRockDemonTypeData Read(ContentReader input,
                LavaRockDemonTypeData existingInstance)
            {
                LavaRockDemonTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new LavaRockDemonTypeData();
                }

                desc.Animation_Names.AddRange(input.ReadObject<List<string>>());
                desc.Extents = input.ReadObject<Vector2>();
                desc.Speed = input.ReadSingle();

				// List<string> animation_names
				// Vector2 extents
				// float speed

                return desc;
            }
		}
	}
}
