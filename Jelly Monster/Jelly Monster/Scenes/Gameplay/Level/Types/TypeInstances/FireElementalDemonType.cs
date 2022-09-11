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
    public class FireElementalDemonType : EnemyType
    {
        Animation attack_animation;
        Texture2D bullet;
        float bullet_speed;
        float fire_rate;

        public FireElementalDemonType()
        {
        }

        public override EntityInterface CreateInstance(EnemyInstanceData data)
        {
            EntityInterface e = null;
            e = new FireElementalDemon(data);
            return e;
        }

        public override void Load(ContentManager content, string path)
        {
            FireElementalDemonTypeData data = content.Load<FireElementalDemonTypeData>(path);

            animation = new Animation((byte)data.Animation_Names.Count);

            for (byte i = 0; i < animation.Count; i++)
            {
                Textures[i] = content.Load<Texture2D>(data.Animation_Names[i]);
            }

            attack_animation = new Animation((byte)data.Animation_Attacking.Count);

            for (byte i = 0; i < attack_animation.Count; i++)
            {
                attack_animation[i] = content.Load<Texture2D>(data.Animation_Attacking[i]);
            }

            bullet = content.Load<Texture2D>(data.Bullet);

            extents = data.Extents;
            bullet_speed = data.Bullet_Speed;
            fire_rate = data.Fire_Rate;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            FireElementalDemon enemy = entity as FireElementalDemon;

            Vector2 dir = enemy.Core.End - enemy.Core.Start;

            if (level.Player.X < enemy.Pos.X)
                enemy.FacingFront = false;
            else
                enemy.FacingFront = true;

            enemy.WaitTime += dt;

            if (enemy.State == 0)
            {
                if (enemy.TimeA.Tick(dt))
                {
                    if (animation.Count - 1 == enemy.Index)
                        enemy.Index = 0;
                    else
                        enemy.Index++;
                }

                if (enemy.WaitTime > fire_rate)
                {
                    enemy.WaitTime = 0f;
                    enemy.State = 1;
                    enemy.Index = 0;
                }

                if (enemy.Fired)
                    enemy.BulletPos += enemy.BulletDir * bullet_speed * dt;
            }
            else if (enemy.State == 1)
            {
                if (enemy.TimeA.Tick(dt))
                {
                    if (attack_animation.Count - 1 == enemy.Index)
                    {
                        enemy.Index = 0;
                        enemy.State = 0;
                        enemy.Fire(level.Player.PrevPos, extents);
                        enemy.WaitTime = 0f;
                    }
                    else
                        enemy.Index++;
                }
            }

            Rectangle b = new Rectangle((int)entity.Pos.X, (int)entity.Pos.Y, (int)extents.X, (int)extents.Y);

            b.X += 15;
            b.Width -= 30;

            if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
            {
                level.Scene.KillPlayer();
                return;
            }

            if (enemy.Fired)
            {
                b.X = (int)(enemy.BulletPos.X);
                b.Y = (int)(enemy.BulletPos.Y);
                b.Width = 10;
                b.Height = 10;

                if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
                {
                    level.Scene.KillPlayer();
                }
            }
        }

        public override void Draw(Level level, SpriteBatch sp, EntityInterface entity)
        {
            FireElementalDemon enemy = entity as FireElementalDemon;

            Rectangle b = new Rectangle((int)(entity.Pos.X - level.OffsetWorld.X),
                                        (int)(entity.Pos.Y - level.OffsetWorld.Y),
                                        (int)extents.X, (int)extents.Y);


            SpriteEffects effect = SpriteEffects.None;

            if (enemy.FacingFront)
                effect = SpriteEffects.FlipHorizontally;

            if (enemy.State == 0)
            {
                sp.Draw(Textures[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);         

                if (enemy.Fired)
                {
                    b.X = (int)(enemy.BulletPos.X - level.OffsetWorld.X);
                    b.Y = (int)(enemy.BulletPos.Y - level.OffsetWorld.Y);

                    b.Width = 10;
                    b.Height = 10;

                    sp.Draw(bullet, b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth); 
                }
            }
            else if (enemy.State == 1)
            {
                sp.Draw(attack_animation[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth); 
            }


            b = new Rectangle((int)(entity.Pos.X - level.OffsetWorld.X),
                              (int)(entity.Pos.Y - level.OffsetWorld.Y),
                              (int)extents.X, (int)extents.Y);

            //b.X += 15;
            //b.Width -= 30;

            //sp.Draw(level.Scene.BoundingTexture, b, null, Color.Red, 0f, Vector2.Zero, effect, 1f);
        }
    }
}
