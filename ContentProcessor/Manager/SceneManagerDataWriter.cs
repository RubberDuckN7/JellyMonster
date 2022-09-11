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
    public class SceneManagerDataWriter : ContentDataWriter<SceneManagerData>
    {
        protected override void Write(ContentWriter output, SceneManagerData value)
        {
            output.Write(value.XmlNameGUI);
            output.Write(value.LoadingTexture);
            output.Write(value.SystemFont);
        }
    }
}
