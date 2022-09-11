using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using IrisEngine;
using ContentData;

namespace Jelly_Monster
{
    public class TornadoType : EnemyType
    {
        float speed;

		public TornadoType()
		{
		
		}

        public override EntityInterface CreateInstance(EnemyInstanceData data)
        {
            EntityInterface e = null;
            e = new Tornado(data);
            return e;
        }

        public override void Load(ContentManager content, string path)
        {
            TornadoTypeData data = content.Load<TornadoTypeData>(path);

            animation = new Animation((byte)data.Tornado_Moving.Count);

            for (byte i = 0; i < animation.Count; i++)
            {
                Textures[i] = content.Load<Texture2D>(data.Tornado_Moving[i]);
            }

            extents = data.Extents;
            speed = data.Speed;        
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            Tornado enemy = entity as Tornado;

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