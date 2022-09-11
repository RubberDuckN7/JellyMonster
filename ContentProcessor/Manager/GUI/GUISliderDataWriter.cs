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
    public class GUISliderDataWriter : ContentDataWriter<GUISliderData>
    {
        protected override void Write(ContentWriter output, GUISliderData value)
        {
            output.Write(value.Background);
            output.Write(value.Top);
            output.Write(value.Bottom);
            output.Write(value.Handle);
        }
    }
}