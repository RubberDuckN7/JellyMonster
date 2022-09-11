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
    public class CannonTypeDataWriter : ContentDataWriter<CannonTypeData>
    {
        protected override void Write(ContentWriter output, CannonTypeData value)
        {
			// List<string> cannon_waiting
			// List<string> cannon_attacking
			// string cannon_ball
			// Vector2 extents
			// float ball_speed
			// float fire_rate

        }
    }
}
