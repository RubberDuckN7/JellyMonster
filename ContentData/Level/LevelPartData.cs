using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ContentData
{
    public class LevelPartData : ContentObject
    {
		private List<EntityInstanceData> grounds = new List<EntityInstanceData>();
		private List<EntityInstanceData> collectable = new List<EntityInstanceData>();
		private List<EntityInstanceData> visual_static = new List<EntityInstanceData>();
		private List<EntityInstanceData> visual_animated = new List<EntityInstanceData>();
		private List<TriggerData> triggers = new List<TriggerData>();
        private List<EnemyInstanceData> enemies = new List<EnemyInstanceData>();
        private Vector2 pos;

		public List<EntityInstanceData> Grounds
		{
			get { return grounds; }
			set { grounds = value; }
		}
		
		public List<EntityInstanceData> Collectable
		{
			get { return collectable; }
			set { collectable = value; }
		}
		
		public List<EntityInstanceData> Visual_Static
		{
			get { return visual_static; }
			set { visual_static = value; }
		}
		
		public List<EntityInstanceData> Visual_Animated
		{
			get { return visual_animated; }
			set { visual_animated = value; }
		}
		
		public List<TriggerData> Triggers
		{
			get { return triggers; }
			set { triggers = value; }
		}

        public List<EnemyInstanceData> Enemies
		{
			get { return enemies; }
			set { enemies = value; }
		}

        public Vector2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }

		public class LevelPartDataReader : ContentTypeReader<LevelPartData>
        {
            protected override LevelPartData Read(ContentReader input,
                LevelPartData existingInstance)
            {
                LevelPartData desc = existingInstance;
                if (desc == null)
                {
                    desc = new LevelPartData();
                }

				// List<EntityInstanceData> grounds
				// List<EntityInstanceData> collectable
				// List<EntityInstanceData> visual_static
				// List<EntityInstanceData> visual_animated
				// List<TriggerData> triggers
				// List<TypeData> enemies

                desc.Grounds.AddRange(input.ReadObject<List<EntityInstanceData>>());
                desc.Collectable.AddRange(input.ReadObject<List<EntityInstanceData>>());
                desc.Visual_Static.AddRange(input.ReadObject<List<EntityInstanceData>>());
                desc.Visual_Animated.AddRange(input.ReadObject<List<EntityInstanceData>>());
                desc.Triggers.AddRange(input.ReadObject<List<TriggerData>>());
                desc.Enemies.AddRange(input.ReadObject<List<EnemyInstanceData>>());
                desc.Pos = input.ReadObject<Vector2>();

                return desc;
            }
		}
	}
}
