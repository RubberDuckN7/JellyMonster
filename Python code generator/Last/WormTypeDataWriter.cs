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
    public class WormTypeDataWriter : ContentDataWriter<WormTypeData>
    {
        protected override void Write(ContentWriter output, WormTypeData value)
        {
			// List<string> worm_monster_attacking
			// string worm_waiting
			// string acid_bullet
			// Vector2 extents
			// float bullet_speed
			// float fire_rate

        }
    }
}
