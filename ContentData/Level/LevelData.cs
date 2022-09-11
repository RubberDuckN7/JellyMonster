using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class LevelData : ContentObject
    {
		private List<GroundTypeData> ground_types = new List<GroundTypeData>();
		private List<CollectableTypeData> collectable_types = new List<CollectableTypeData>();
		private List<VisualStaticData> visual_static_types = new List<VisualStaticData>();
		private List<VisualAnimatedData> visual_animated_types = new List<VisualAnimatedData>();
		private List<AnimationData> raw_animations = new List<AnimationData>();
		private List<TypeData> enemy_types = new List<TypeData>();
		private List<LevelPartData> level_parts = new List<LevelPartData>();

		public List<GroundTypeData> Ground_Types
		{
			get { return ground_types; }
			set { ground_types = value; }
		}
		
		public List<CollectableTypeData> Collectable_Types
		{
			get { return collectable_types; }
			set { collectable_types = value; }
		}
		
		public List<VisualStaticData> Visual_Static_Types
		{
			get { return visual_static_types; }
			set { visual_static_types = value; }
		}
		
		public List<VisualAnimatedData> Visual_Animated_Types
		{
			get { return visual_animated_types; }
			set { visual_animated_types = value; }
		}
		
		public List<AnimationData> Raw_Animations
		{
			get { return raw_animations; }
			set { raw_animations = value; }
		}
		
		public List<TypeData> Enemy_Types
		{
			get { return enemy_types; }
			set { enemy_types = value; }
		}
		
		public List<LevelPartData> Level_Parts
		{
			get { return level_parts; }
			set { level_parts = value; }
		}
		

		public class LevelDataReader : ContentTypeReader<LevelData>
        {
            protected override LevelData Read(ContentReader input,
                LevelData existingInstance)
            {
                LevelData desc = existingInstance;
                if (desc == null)
                {
                    desc = new LevelData();
                }

				// List<GroundTypeData> ground_types
				// List<CollectableTypeData> collectable_types
				// List<VisualStaticData> visual_static_types
				// List<VisualAnimatedData> visual_animated_types
				// List<AnimationData> raw_animations
				// List<TypeData> enemy_types
				// List<LevelPartData> level_parts

                desc.Ground_Types.AddRange(input.ReadObject<List<GroundTypeData>>());
                desc.Collectable_Types.AddRange(input.ReadObject<List<CollectableTypeData>>());
                desc.Visual_Static_Types.AddRange(input.ReadObject<List<VisualStaticData>>());
                desc.Visual_Animated_Types.AddRange(input.ReadObject<List<VisualAnimatedData>>());
                desc.Raw_Animations.AddRange(input.ReadObject<List<AnimationData>>());
                desc.Enemy_Types.AddRange(input.ReadObject<List<TypeData>>());
                desc.Level_Parts.AddRange(input.ReadObject<List<LevelPartData>>());

                return desc;
            }
		}
	}
}
