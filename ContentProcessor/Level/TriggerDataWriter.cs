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
    public class TriggerDataWriter : ContentDataWriter<TriggerData>
    {
        protected override void Write(ContentWriter output, TriggerData value)
        {
            // Rectangle bounds
            // string type
            output.WriteObject<Rectangle>(value.Bounds);
            output.Write(value.Data);
            output.Write(value.Type);
        }
    }
}
