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
    public class LevelPartDataWriter : ContentDataWriter<LevelPartData>
    {
        protected override void Write(ContentWriter output, LevelPartData value)
        {
            // List<EntityInstanceData> grounds
            // List<EntityInstanceData> collectable
            // List<EntityInstanceData> visual_static
            // List<EntityInstanceData> visual_animated
            // List<TriggerData> triggers
            // List<TypeData> enemies
            output.WriteObject<List<EntityInstanceData>>(value.Grounds);
            output.WriteObject<List<EntityInstanceData>>(value.Collectable);
            output.WriteObject<List<EntityInstanceData>>(value.Visual_Static);
            output.WriteObject<List<EntityInstanceData>>(value.Visual_Animated);
            output.WriteObject<List<TriggerData>>(value.Triggers);
            output.WriteObject<List<EnemyInstanceData>>(value.Enemies);
            output.WriteObject<Vector2>(value.Pos);
        }
    }
}
