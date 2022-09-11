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
    public class EntityInstanceDataWriter : ContentDataWriter<EntityInstanceData>
    {
        protected override void Write(ContentWriter output, EntityInstanceData value)
        {
            // Vector2 pos
            // float depth
            // byte id
            output.WriteObject<Vector2>(value.Pos);
            output.Write(value.Depth);
            output.Write(value.Id);
        }
    }
}
