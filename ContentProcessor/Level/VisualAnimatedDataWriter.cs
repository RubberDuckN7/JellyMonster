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
    public class VisualAnimatedDataWriter : ContentDataWriter<VisualAnimatedData>
    {
        protected override void Write(ContentWriter output, VisualAnimatedData value)
        {
            // List<string> path
            // Vector2 extents
            output.WriteObject<List<string>>(value.Path);
            output.WriteObject<Vector2>(value.Extents);
        }
    }
}
