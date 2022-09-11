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
    public class LavaRockDemonTypeDataWriter : ContentDataWriter<LavaRockDemonTypeData>
    {
        protected override void Write(ContentWriter output, LavaRockDemonTypeData value)
        {
            output.WriteObject<List<string>>(value.Animation_Names);
            output.WriteObject<Vector2>(value.Extents);
            output.Write(value.Speed);

			// List<string> animation_names
			// Vector2 extents
			// float speed

        }
    }
}
