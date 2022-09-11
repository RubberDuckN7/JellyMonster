using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using IrisEngine;
using ContentData;

namespace Jelly_Monster
{
    public class SawWheelType : EnemyType
    {
        float speed;

        public SawWheelType()
        {

        }

        public override EntityInterface CreateInstance(EnemyInstanceData data)
        {
            EntityInterface e = null;
            e = new SawWheel(data);
            return e;
        }

        public override void Load(ContentManager content, string path)
        {
            SawWheelTypeData data = content.Load<SawWheelTypeData>(path);

            animation = new Animation((byte)data.Saw_Wheel_Walking.Count);

            for (byte i = 0; i < animation.Count; i++)
            {
                Textures[i] = content.Load<Texture2D>(data.Saw_Wheel_Walking[i]);
            }

            extents = data.Extents;
            speed = data.Speed;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            SawWheel enemy = entity as SawWheel;

            Vector2 dir;// = enemy.Core.End - enemy.Core.Start;

            if (enemy.FacingFront)
            {
                if (!enemy.DirLeft)
                    dir = enemy.Core.End - enemy.Core.Start;
                else
                    dir = enemy.Core.Start - enemy.Core.End;
            }
            else
            {
                if (!enemy.DirLeft)
                    dir = enemy.Core.Start - enemy.Core.End;
                else
                    dir = enemy.Core.End - enemy.Core.Start;
            }

            dir.Normalize();

            enemy.Pos += dir * speed * dt;

            if (enemy.FacingFront)
            {
                if (!enemy.DirLeft)
                {
                    if (enemy.Pos.X + extents.X > enemy.Core.End.X)
                        enemy.FacingFront = false;
                }
                else
                {
                    // Reason for start is not taking width into account is because
                    // where it is placed
                    if (enemy.Pos.X > enemy.Core.Start.X)
                        enemy.FacingFront = false;
                }

            }
            else
            {
                if (!enemy.DirLeft)
                {
                    if (enemy.Pos.X < enemy.Core.Start.X)
                        enemy.FacingFront = true;
                }
                else
                {
                    if (enemy.Pos.X < enemy.Core.End.X)
                        enemy.FacingFront = true;
                }
            }

            base.Update(level, entity, dt);
        }

        public override void Draw(Level level, SpriteBatch sp, EntityInterface entity)
        {
            base.Draw(level, sp, entity);
        }		
	}
}