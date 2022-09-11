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
    public class FireElementalDemonTypeDataWriter : ContentDataWriter<FireElementalDemonTypeData>
    {
        protected override void Write(ContentWriter output, FireElementalDemonTypeData value)
        {
            output.WriteObject<List<string>>(value.Animation_Names);
            output.WriteObject<List<string>>(value.Animation_Attacking);
            output.Write(value.Bullet);
            output.WriteObject<Vector2>(value.Extents);
            output.Write(value.Bullet_Speed);
            output.Write(value.Fire_Rate);

			// List<string> animation_names
			// Vector2 extents
			// float bullet_speed
			// float fire_rate

        }
    }
}
