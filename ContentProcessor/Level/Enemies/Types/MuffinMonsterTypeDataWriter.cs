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
    public class MuffinMonsterTypeDataWriter : ContentDataWriter<MuffinMonsterTypeData>
    {
        protected override void Write(ContentWriter output, MuffinMonsterTypeData value)
        {
			// List<string> muffin_attacking
			// string muffin_waiting
			// Vector2 extents

            output.WriteObject<List<string>>(value.Muffin_Attacking);
            output.Write(value.Muffin_Waiting);
            output.WriteObject<Vector2>(value.Extents);
        }
    }
}
