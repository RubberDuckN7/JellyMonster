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
    public class FlyingDemonType : EnemyType
    {
        float speed;

        public FlyingDemonType()
        {
        }

        public override EntityInterface CreateInstance(EnemyInstanceData data)
        {
            EntityInterface e = null;
            e = new FlyingDemon(data);
            return e;
        }

        public override void Load(ContentManager content, string path)
        {
            FlyingDemonTypeData data = content.Load<FlyingDemonTypeData>(path);

            animation = new Animation((byte)data.Animation_Names.Count);

            for (byte i = 0; i < animation.Count; i++)
            {
                Textures[i] = content.Load<Texture2D>(data.Animation_Names[i]);
            }

            extents = data.Extents;
            speed = data.Speed;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            FlyingDemon enemy = entity as FlyingDemon;

            Vector2 dir;// = enemy.Core.End - enemy.Core.Start;

            if (enemy.FacingFront)
            {
                if(!enemy.DirLeft)
                    dir = enemy.Core.End - enemy.Core.Start;
                else
                    dir = enemy.Core.Start - enemy.Core.End;
            }
            else
            {
                if(!enemy.DirLeft)
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
