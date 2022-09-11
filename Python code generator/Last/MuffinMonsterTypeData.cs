using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class MuffinMonsterTypeData : ContentObject
    {
		private List<string> muffin_attacking = new List<string>();
		private string muffin_waiting;
		private Vector2 extents;

		public List<string> Muffin_Attacking
		{
			get { return muffin_attacking; }
			set { muffin_attacking = value; }
		}
		
		public string Muffin_Waiting
		{
			get { return muffin_waiting; }
			set { muffin_waiting = value; }
		}
		
		public Vector2 Extents
		{
			get { return extents; }
			set { extents = value; }
		}
		

		public class MuffinMonsterTypeDataReader : ContentTypeReader<MuffinMonsterTypeData>
        {
            protected override MuffinMonsterTypeData Read(ContentReader input,
                MuffinMonsterTypeData existingInstance)
            {
                MuffinMonsterTypeData desc = existingInstance;
                if (desc == null)
                {
                    desc = new MuffinMonsterTypeData();
                }

				// List<string> muffin_attacking
				// string muffin_waiting
				// Vector2 extents

                return desc;
            }
		}
	}
}
