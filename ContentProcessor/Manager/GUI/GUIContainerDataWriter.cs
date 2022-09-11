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
    public class GUIContainerDataWriter : ContentDataWriter<GUIContainerData>
    {
        protected override void Write(ContentWriter output, GUIContainerData value)
        {
            output.WriteObject<GUIRScaledData>(value.Background);
            output.Write(value.EmptyTile);
            output.Write(value.SelectedTile);
        }
    }
}