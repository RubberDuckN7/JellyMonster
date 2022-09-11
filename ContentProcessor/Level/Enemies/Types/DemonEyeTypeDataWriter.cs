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
    public class DemonEyeTypeDataWriter : ContentDataWriter<DemonEyeTypeData>
    {
        protected override void Write(ContentWriter output, DemonEyeTypeData value)
        {
            output.WriteObject<List<string>>(value.Animation_Names);
            output.WriteObject<List<string>>(value.Animation_Charging);
            output.Write(value.Eye_Beam);
            output.WriteObject<Vector2>(value.Extents);
            output.Write(value.Charge_Speed);
            output.Write(value.Fire_Speed);

			// List<string> animation_names
			// Vector2 extents
			// float charge_speed
			// float fire_speed

        }
    }
}
