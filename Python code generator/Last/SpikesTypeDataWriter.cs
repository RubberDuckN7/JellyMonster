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
    public class SpikesTypeDataWriter : ContentDataWriter<SpikesTypeData>
    {
        protected override void Write(ContentWriter output, SpikesTypeData value)
        {
			// List<string> spikes_attacking
			// List<string> spikes_removing
			// string spikes_waiting
			// Vector2 extents

        }
    }
}
