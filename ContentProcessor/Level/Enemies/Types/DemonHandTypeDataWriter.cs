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
    public class DemonHandTypeDataWriter : ContentDataWriter<DemonHandTypeData>
    {
        protected override void Write(ContentWriter output, DemonHandTypeData value)
        {
			// List<string> demon_hand
			// string demon_claw
			// Vector2 extents
			// float range

            output.WriteObject<List<string>>(value.Demon_Hand);
            output.Write(value.Demon_Claw);
            output.WriteObject<Vector2>(value.Extents);
            output.Write(value.Range);
        }
    }
}
