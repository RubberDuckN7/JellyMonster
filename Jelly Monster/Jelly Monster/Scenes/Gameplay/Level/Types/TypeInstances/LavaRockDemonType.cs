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
    public class LavaRockDemonType : EnemyType
    {
        float speed;

        public LavaRockDemonType()
        {
        }

        public override EntityInterface CreateInstance(EnemyInstanceData data)
        {
            EntityInterface e = null;
            e = new LavaRockDemon(data);
            return e;
        }

        public override void Load(ContentManager content, string path)
        {
            LavaRockDemonTypeData data = content.Load<LavaRockDemonTypeData>(path);

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
            Enemy enemy = entity as Enemy;

            Vector2 dir = enemy.Core.End - enemy.Core.Start;

            if (!enemy.FacingFront)
                dir = enemy.Core.Start - enemy.Core.End;
            dir.Normalize();

            enemy.Pos += dir * speed * dt;

            if (enemy.FacingFront)
            {
                if (enemy.Pos.X + extents.X > enemy.Core.End.X)
                    enemy.FacingFront = false;
            }
            else
            {
                if (enemy.Pos.X < enemy.Core.Start.X)
                    enemy.FacingFront = true;
            }

            if (enemy.TimeA.Tick(dt * 0.7f))
            {
                if (animation.Count - 1 == (int)enemy.Index)
                    enemy.Index = 0;
                else
                    enemy.Index++;
            }

            Rectangle b = new Rectangle((int)entity.Pos.X, (int)entity.Pos.Y, (int)extents.X, (int)extents.Y);

            b.X += 15;
            b.Y += 15;

            b.Width -= 30;
            b.Height -= 30;

            if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
            {
                level.Scene.KillPlayer();
            }
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

            //b.X += 15;
            //b.Y += 15;

            //b.Width -= 30;
            //b.Height -= 30;

            //sp.Draw(level.Scene.BoundingTexture, b, null, Color.Red, 0f, Vector2.Zero, effect, 1f);
        }
    }
}
