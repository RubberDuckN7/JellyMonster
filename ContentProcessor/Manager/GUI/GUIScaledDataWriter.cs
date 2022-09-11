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
    public class GUIRScaledDataWriter : ContentDataWriter<GUIRScaledData>
    {
        protected override void Write(ContentWriter output, GUIRScaledData value)
        {
            output.Write(value.Background);
            output.Write(value.CornerTL);
            output.Write(value.CornerTR);
            output.Write(value.CornerBL);
            output.Write(value.CornerBR);
            output.Write(value.BorderHorizontal);
            output.Write(value.BorderVertical);
        }
    }
}
