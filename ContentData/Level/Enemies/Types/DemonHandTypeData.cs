using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class DemonHandTypeData : ContentObject
    {
		private List<string> demon_hand = new List<string>();
		private string demon_claw;
		private Vector2 extents;
		private float range;

		public List<string> Demon_Hand
		{
			get { return demon_hand; }
			set { demon_hand = value; }
		}
		
		public string Demon_Claw
		{
			get { return demon_claw; }
			set { demon_claw = value; }
		}
		
		public Vector2 Extents
		{
			get { return extents; }
			set { extents = value; }
		}
		
		public float Range
		{
			get { return range; }
			set { range = value; }
		}
		

		public class DemonHandTypeDataReader : ContentTypeReader<DemonHandTypeData>
        {
            protected override DemonHandTypeData Read(ContentReader input,
                DemonHandTypeData existingInstance)
            {
                DemonHandTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new DemonHandTypeData();
                }

				// List<string> demon_hand
				// string demon_claw
				// Vector2 extents
				// float range

                desc.Demon_Hand.AddRange(input.ReadObject<List<string>>());
                desc.Demon_Claw = input.ReadString();
                desc.Extents = input.ReadObject<Vector2>();
                desc.Range = input.ReadSingle();

                return desc;
            }
		}
	}
}
