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

            output.WriteObject<List<string>>(value.Worm_Monster_Attacking);
            output.Write(value.Worm_Waiting);
            output.Write(value.Acid_Bullet);
            output.WriteObject<Vector2>(value.Extents);
            output.Write(value.Bullet_Speed);
            output.Write(value.Fire_Rate);
        }
    }
}
