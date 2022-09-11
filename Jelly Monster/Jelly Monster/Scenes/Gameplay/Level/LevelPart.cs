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
    public class LevelPart
    {
        EntityInterface[] entities;
        Vector2 pos;

        public void Load(Level level, LevelPartData data)
        {
            // As all of them derive from entity, they will be in same array list
            int total_count = data.Grounds.Count + 
                data.Collectable.Count +
                data.Visual_Animated.Count + 
                data.Visual_Static.Count +
                data.Triggers.Count + 
                data.Enemies.Count;

            level.CollectableCount += (byte)data.Collectable.Count;

            entities = new EntityInterface[total_count];

            int offset = 0;

            for (byte i = 0; i < data.Grounds.Count; i++)
            {
                byte id = (byte)(level.OffsetGround + data.Grounds[i].Id);
                int index = (int)(offset + i);

                data.Grounds[i].Id = id;
                entities[index] = CreateInstanceGround(level, data.Grounds[i], id);
            }

            offset += data.Grounds.Count;

            for (byte i = 0; i < data.Visual_Static.Count; i++)
            {
                byte id = (byte)(level.OffsetVisualS + data.Visual_Static[i].Id);
                int index = (int)(offset + i);

                data.Visual_Static[i].Id = id;
                entities[index] = CreateInstanceVisualStatic(level, data.Visual_Static[i], id);
            }

            offset += data.Visual_Static.Count;

            for (byte i = 0; i < data.Visual_Animated.Count; i++)
            {
                byte id = (byte)(level.OffsetVisualA + data.Visual_Animated[i].Id);
                int index = (int)(offset + i);

                data.Visual_Animated[i].Id = id;
                entities[index] = CreateInstanceVisualAnimated(level, data.Visual_Animated[i], id);
            }

            offset += data.Visual_Animated.Count;

            for (byte i = 0; i < data.Collectable.Count; i++)
            {
                byte id = (byte)(level.OffsetCollectable + data.Collectable[i].Id);
                int index = (int)(offset + i);

                data.Collectable[i].Id = id;
                entities[index] = CreateInstanceCollectable(level, data.Collectable[i], id);
            }

            offset += data.Collectable.Count;

            for (byte i = 0; i < data.Triggers.Count; i++)
            {
                //byte id = 0;
                int index = (int)(offset + i);

                entities[index] = CreateInstanceTrigger(level, data.Triggers[i]);
            }

            offset += data.Triggers.Count;

            for (byte i = 0; i < data.Enemies.Count; i++)
            {
                byte id = (byte)(level.OffsetEnemy + data.Enemies[i].Id);
                int index = (int)(offset + i);

                data.Enemies[i].Id = id;
                entities[index] = CreateInstanceEnemy(level, data.Enemies[i], id);
            }

            this.pos = data.Pos;

            for (byte i = 0; i < entities.Length; i++)
            {
                if (entities[i] == null)
                {
                    return;
                }
            }
        }

        public void Update(Level level, float dt)
        {
            foreach (EntityInterface ie in entities)
            {
                EntityInterfaceType type = level.TypeAt(ie.Id);
                type.Update(level, ie, dt);
            }
        }

        public void Draw(Level level, SpriteBatch sp)
        {
            foreach (EntityInterface ie in entities)
            {
                EntityInterfaceType type = level.TypeAt(ie.Id);
                type.Draw(level, sp, ie);
            }
        }

        public Vector2 Pos
        {
            get { return pos; }
        }

        private EntityInterface CreateInstanceTrigger(Level level, TriggerData data)
        {
            EntityInterface e = null;
            EntityInterfaceType type = level.TypeAt(0);
            TriggerType real_type = type as TriggerType;

            if (real_type != null)
            {
                e = real_type.CreateInstance(level, data);
            }
            else
            {
                return null;
            }

            return e;
        }

        private EntityInterface CreateInstanceGround(Level level, EntityInstanceData data, byte real_id)
        {
            EntityInterface e = null;
            EntityInterfaceType type = level.TypeAt(real_id);
            GroundType real_type = type as GroundType;

            if (real_type != null)
            {
                e = real_type.CreateInstance(data);
            }
            else
            {
                return null;
            }

            return e;
        }

        private EntityInterface CreateInstanceVisualStatic(Level level, EntityInstanceData data, byte real_id)
        {
            EntityInterface e = null;
            EntityInterfaceType type = level.TypeAt(real_id);
            VisualStaticType real_type = type as VisualStaticType;

            if (real_type != null)
            {
                e = real_type.CreateInstance(data);
            }
            else
            {
                return null;
            }

            return e;
        }

        private EntityInterface CreateInstanceVisualAnimated(Level level, EntityInstanceData data, byte real_id)
        {
            EntityInterface e = null;
            EntityInterfaceType type = level.TypeAt(real_id);
            VisualAnimatedType real_type = type as VisualAnimatedType;

            if (real_type != null)
            {
                e = real_type.CreateInstance(data);
            }
            else
            {
                return null;
            }

            return e;
        }

        private EntityInterface CreateInstanceCollectable(Level level, EntityInstanceData data, byte real_id)
        {
            EntityInterface e = null;
            EntityInterfaceType type = level.TypeAt(real_id);
            CollectableType real_type = type as CollectableType;

            if (real_type != null)
            {
                e = real_type.CreateInstance(data);
            }
            else
            {
                return null;
            }

            return e;
        }

        private EntityInterface CreateInstanceEnemy(Level level, EnemyInstanceData data, byte real_id)
        {
            EntityInterface e = null;
            EntityInterfaceType type = level.TypeAt(data.Id);
            EnemyType enemy_type = type as EnemyType;

            if (enemy_type != null)
            {
                e = enemy_type.CreateInstance(data);
            }
            else
            {
                return null;
            }

            return e;
        }
    }
}
