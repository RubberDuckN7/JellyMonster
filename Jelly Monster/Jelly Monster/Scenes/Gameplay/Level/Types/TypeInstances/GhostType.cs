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
    public class GhostType : EnemyType
    {
        float speed;

		public GhostType()
		{
		
		}

        public override EntityInterface CreateInstance(EnemyInstanceData data)
        {
            EntityInterface e = null;
            e = new Ghost(data);
            return e;
        }

        public override void Load(ContentManager content, string path)
        {
            GhostTypeData data = content.Load<GhostTypeData>(path);

            animation = new Animation((byte)data.Ghost_Walking.Count);

            for (byte i = 0; i < animation.Count; i++)
            {
                Textures[i] = content.Load<Texture2D>(data.Ghost_Walking[i]);
            }

            extents = data.Extents;
            speed = data.Speed;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            Ghost enemy = entity as Ghost;

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
            Rectangle b = new Rectangle((int)(entity.Pos.X - level.OffsetWorld.X),
                                        (int)(entity.Pos.Y - level.OffsetWorld.Y),
                                        (int)extents.X, (int)extents.Y);

            SpriteEffects effect = SpriteEffects.FlipHorizontally;

            Enemy enemy = entity as Enemy;

            if (enemy.FacingFront)
                effect = SpriteEffects.None;
            sp.Draw(Textures[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth); 
        }		
	}
}