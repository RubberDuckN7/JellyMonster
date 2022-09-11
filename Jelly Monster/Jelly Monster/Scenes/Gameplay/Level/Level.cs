using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input.Touch;

using IrisEngine;
using ContentData;

namespace Jelly_Monster
{
    public class Level
    {
        GameScene scene;

        LevelPart[] parts;
        EntityInterfaceType[] types;

        Vector2 offset_world;

        int offset_ground;
        int offset_visual_s;
        int offset_visual_a;
        int offset_collectable;
        int offset_enemy;

        byte collectable_count;

        public Level(GameScene scene)
        {
            this.scene = scene;
            this.offset_world = Vector2.Zero;
            this.offset_ground = 0;
            this.offset_visual_s = 0;
            this.offset_visual_a = 0;
            this.offset_collectable = 0;
            this.offset_enemy = 0;
            this.collectable_count = 0;
        }

        public void Load(ContentManager content, string xml)
        {
            LevelData main_data = content.Load<LevelData>(xml);

            int total_count = main_data.Ground_Types.Count +
                main_data.Enemy_Types.Count +
                main_data.Collectable_Types.Count +
                main_data.Visual_Animated_Types.Count +
                main_data.Visual_Static_Types.Count + 1;

            types = new EntityInterfaceType[total_count];

            int offset = 0;

            types[0] = LoadTriggerType();

            offset = 1;

            offset_ground = offset;

            for (byte i = 0; i < main_data.Ground_Types.Count; i++)
            {
                types[i + offset] = LoadGroundType(content, main_data.Ground_Types[i]);
            }

            offset += main_data.Ground_Types.Count;
            offset_visual_s = offset;

            for (byte i = 0; i < main_data.Visual_Static_Types.Count; i++)
            {
                types[i + offset] = LoadVisualStaticType(content, main_data.Visual_Static_Types[i]);
            }

            offset += main_data.Visual_Static_Types.Count;
            offset_visual_a = offset;

            for (byte i = 0; i < main_data.Visual_Animated_Types.Count; i++)
            {
                types[i + offset] = LoadVisualAnimatedType(content, main_data.Visual_Animated_Types[i]);
            }

            offset += main_data.Visual_Animated_Types.Count;
            offset_collectable = offset;

            for (byte i = 0; i < main_data.Collectable_Types.Count; i++)
            {
                types[i + offset] = LoadCollectableType(content, main_data.Collectable_Types[i]);
            }

            offset += main_data.Collectable_Types.Count;
            offset_enemy = offset;

            for(byte i = 0; i < main_data.Enemy_Types.Count; i++)
            {
                types[i + offset] = LoadEnemyType(content, main_data.Enemy_Types[i]);
            }

            parts = new LevelPart[main_data.Level_Parts.Count];

            for (byte i = 0; i < parts.Length; i++)
            {
                parts[i] = new LevelPart();
                parts[i].Load(this, main_data.Level_Parts[i]);
            }
        }

        public void Update(float dt)
        {
            foreach (LevelPart p in parts)
            {
                if(OffsetWorld.X + 1600f > p.Pos.X && OffsetWorld.X < p.Pos.Y)
                    p.Update(this, dt);
            }
        }

        public void Draw(SpriteBatch sp)
        {
            foreach (LevelPart p in parts)
            {
                if (OffsetWorld.X + 1600f > p.Pos.X && OffsetWorld.X < p.Pos.Y)
                    p.Draw(this, sp);
            }
        }

        public EntityInterfaceType TypeAt(byte id)
        {
            return types[id];
        }

        public GameScene Scene
        {
            get { return scene; }
        }

        public JellyPlayer Player
        {
            get { return scene.JPlayer; }
        }

        public int OffsetGround
        {
            get { return offset_ground; }
            set { offset_ground = value; }
        }

        public int OffsetVisualS
        {
            get { return offset_visual_s; }
            set { offset_visual_s = value; }
        }

        public int OffsetVisualA
        {
            get { return offset_visual_a; }
            set { offset_visual_a = value; }
        }

        public int OffsetCollectable
        {
            get { return offset_collectable; }
            set { offset_collectable = value; }
        }

        public int OffsetEnemy
        {
            get { return offset_enemy; }
            set { offset_enemy = value; }
        }

        public Vector2 OffsetWorld
        {
            get { return offset_world; }
            set { offset_world = value; }
        }

        public byte CollectableCount
        {
            get { return collectable_count; }
            set { collectable_count = value; }
        }

        private EntityInterfaceType LoadTriggerType()
        {
            EntityInterfaceType type = new TriggerType();

            return type;
        }

        private EntityInterfaceType LoadGroundType(ContentManager content, GroundTypeData data)
        {
            EntityInterfaceType type = new GroundType();
            GroundType real_type = type as GroundType;
            
            if(real_type != null)
            {
                real_type.Texture = content.Load<Texture2D>(data.Path);
                real_type.Extents = data.Extents;  
            }

            return real_type;
        }

        private EntityInterfaceType LoadVisualStaticType(ContentManager content, VisualStaticData data)
        {
            EntityInterfaceType type = new VisualStaticType();
            VisualStaticType real_type = type as VisualStaticType;

            if (real_type != null)
            {
                real_type.Texture = content.Load<Texture2D>(data.Path);
                real_type.Extents = data.Extents;
            }

            return real_type;
        }

        private EntityInterfaceType LoadVisualAnimatedType(ContentManager content, VisualAnimatedData data)
        {
            EntityInterfaceType type = new VisualAnimatedType();
            VisualAnimatedType real_type = type as VisualAnimatedType;

            if (real_type != null)
            {
                real_type.Textures = new Animation((byte)data.Path.Count);

                for (byte i = 0; i < real_type.Textures.Count; i++)
                {
                    real_type.Textures[i] = content.Load<Texture2D>(data.Path[i]);
                }

                real_type.Extents = data.Extents;
            }

            return real_type;
        }

        private EntityInterfaceType LoadCollectableType(ContentManager content, CollectableTypeData data)
        {
            EntityInterfaceType type = new CollectableType();
            CollectableType real_type = type as CollectableType;

            if (real_type != null)
            {
                real_type.Texture = content.Load<Texture2D>(data.Path);
                real_type.Extents = data.Extents;
                real_type.Score = data.Score;
            }

            return real_type;
        }

        private EntityInterfaceType LoadEnemyType(ContentManager content, TypeData type_data)
        {
            string full_name = "Jelly_Monster." + type_data.Name;

            var type = Type.GetType(full_name);
            var obj = (EntityInterfaceType)Activator.CreateInstance(type);

            EnemyType real_type = obj as EnemyType;

            real_type.Load(content, type_data.Path);

            return real_type;
        }

    }
}
