using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class EnemyInstanceData : ContentObject
    {
		private Vector2 start;
		private Vector2 end;
		private float depth;
		private byte id;

		public Vector2 Start
		{
			get { return start; }
			set { start = value; }
		}
		
		public Vector2 End
		{
			get { return end; }
			set { end = value; }
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
		

		public class EnemyInstanceDataReader : ContentTypeReader<EnemyInstanceData>
        {
            protected override EnemyInstanceData Read(ContentReader input,
                EnemyInstanceData existingInstance)
            {
                EnemyInstanceData desc = existingInstance;
                if (desc == null)
                {
                    desc = new EnemyInstanceData();
                }

				// Vector2 start
				// Vector2 end
				// float depth
				// byte id

                desc.Start = input.ReadObject<Vector2>();
                desc.End = input.ReadObject<Vector2>();
                desc.Depth = input.ReadSingle();
                desc.Id = input.ReadByte();

                return desc;
            }
		}
	}
}
