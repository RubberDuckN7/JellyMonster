using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class TriggerData : ContentObject
    {
		private Rectangle bounds;
        private float data;
		private string type;

		public Rectangle Bounds
		{
			get { return bounds; }
			set { bounds = value; }
		}

        public float Data
        {
            get { return data; }
            set { data = value; }
        }

		public string Type
		{
			get { return type; }
			set { type = value; }
		}
		
		public class TriggerDataReader : ContentTypeReader<TriggerData>
        {
            protected override TriggerData Read(ContentReader input,
                TriggerData existingInstance)
            {
                TriggerData desc = existingInstance;
                if (desc == null)
                {
                    desc = new TriggerData();
                }

				// Rectangle bounds
				// string type

                desc.Bounds = input.ReadObject<Rectangle>();
                desc.Data = input.ReadSingle();
                desc.Type = input.ReadString();
                
                return desc;
            }
		}
	}
}
