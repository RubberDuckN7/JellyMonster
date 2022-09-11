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
    public class CloudTypeDataWriter : ContentDataWriter<CloudTypeData>
    {
        protected override void Write(ContentWriter output, CloudTypeData value)
        {
			// List<string> cloud_attacking
			// List<string> cloud_waiting
			// string thunder_one
			// string thunder_two
			// Vector2 extents
			// float speed
			// float thunder_length
			// float wait_length

        }
    }
}
