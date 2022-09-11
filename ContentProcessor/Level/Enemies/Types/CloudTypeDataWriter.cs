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

            output.WriteObject<List<string>>(value.Cloud_Attacking);
            output.WriteObject<List<string>>(value.Cloud_Waiting);
            output.Write(value.Thunder_One);
            output.Write(value.Thunder_Two);
            output.WriteObject<Vector2>(value.Extents);
            output.Write(value.Speed);
            output.Write(value.Thunder_Length);
            output.Write(value.Wait_Length);
        }
    }
}
