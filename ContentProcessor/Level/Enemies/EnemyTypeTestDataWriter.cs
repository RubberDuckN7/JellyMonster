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
    public class EnemyTypeTestDataWriter : ContentDataWriter<EnemyTypeTestData>
    {
        protected override void Write(ContentWriter output, EnemyTypeTestData value)
        {
            // List<string> path
            output.WriteObject<List<string>>(value.Path);
            output.WriteObject<Vector2>(value.Extents);
            output.Write(value.Speed);
        }
    }
}
