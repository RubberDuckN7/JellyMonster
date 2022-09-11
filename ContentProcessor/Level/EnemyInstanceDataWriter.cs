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
    public class EnemyInstanceDataWriter : ContentDataWriter<EnemyInstanceData>
    {
        protected override void Write(ContentWriter output, EnemyInstanceData value)
        {
            // Vector2 start
            // Vector2 end
            // float depth
            // byte id
            output.WriteObject<Vector2>(value.Start);
            output.WriteObject<Vector2>(value.End);
            output.Write(value.Depth);
            output.Write(value.Id);
        }
    }
}
