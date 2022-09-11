using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class EntityInstanceData : ContentObject
    {
		private Vector2 pos;
		private float depth;
		private byte id;

		public Vector2 Pos
		{
			get { return pos; }
			set { pos = value; }
		}
		
		public float Depth
		{
			get { return depth; }
			set { depth = value; }
		}
		
		public byte Id
		{
			get { return id; }
			set { id = value; }
		}
		

		public class EntityInstanceDataReader : ContentTypeReader<EntityInstanceData>
        {
            protected override EntityInstanceData Read(ContentReader input,
                EntityInstanceData existingInstance)
            {
                EntityInstanceData desc = existingInstance;
                if (desc == null)
                {
                    desc = new EntityInstanceData();
                }

				// Vector2 pos
				// float depth
				// byte id

                desc.Pos = input.ReadObject<Vector2>();
                desc.Depth = input.ReadSingle();
                desc.Id = input.ReadByte();

                return desc;
            }
		}
	}
}
