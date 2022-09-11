using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class AnimationData : ContentObject
    {
		private List<string> path = new List<string>();

		public List<string> Path
		{
			get { return path; }
			set { path = value; }
		}
		

		public class AnimationDataReader : ContentTypeReader<AnimationData>
        {
            protected override AnimationData Read(ContentReader input,
                AnimationData existingInstance)
            {
                AnimationData desc = existingInstance;
                if (desc == null)
                {
                    desc = new AnimationData();
                }

				// List<string> path

                desc.Path.AddRange(input.ReadObject<List<string>>());

                return desc;
            }
		}
	}
}
