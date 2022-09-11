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
    public class GUICheckBoxDataWriter : ContentDataWriter<GUICheckBoxData>
    {
        protected override void Write(ContentWriter output, GUICheckBoxData value)
        {
            output.Write(value.Background);
            output.Write(value.Pressed);
        }
    }
}