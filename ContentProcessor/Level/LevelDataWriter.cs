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
    public class LevelDataWriter : ContentDataWriter<LevelData>
    {
        protected override void Write(ContentWriter output, LevelData value)
        {
            // List<GroundTypeData> ground_types
            // List<CollectableTypeData> collectable_types
            // List<VisualStaticData> visual_static_types
            // List<VisualAnimatedData> visual_animated_types
            // List<AnimationData> raw_animations
            // List<EnemyTypeData> enemy_types
            // List<LevelPartData> level_parts
            output.WriteObject<List<GroundTypeData>>(value.Ground_Types);
            output.WriteObject<List<CollectableTypeData>>(value.Collectable_Types);
            output.WriteObject<List<VisualStaticData>>(value.Visual_Static_Types);
            output.WriteObject<List<VisualAnimatedData>>(value.Visual_Animated_Types);
            output.WriteObject<List<AnimationData>>(value.Raw_Animations);
            output.WriteObject<List<TypeData>>(value.Enemy_Types);
            output.WriteObject<List<LevelPartData>>(value.Level_Parts);
        }
    }
}
