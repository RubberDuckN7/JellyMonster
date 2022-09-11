using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using ContentData;

namespace ContentProcessor
{
    [ContentTypeWriter]
    public class GhostTypeDataWriter : ContentDataWriter<GhostTypeData>
    {
        protected override void Write(ContentWriter output, GhostTypeData value)
        {
			// List<string> ghost_walking
			// Vector2 extents
			// float speed

            output.WriteObject<List<string>>(value.Ghost_Walking);
            output.WriteObject<Vector2>(value.Extents);
            output.Write(value.Speed);
        }
    }
}
