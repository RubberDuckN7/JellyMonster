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
    public class DemonEyeType : EnemyType
    {
        Animation charging_animation;
        Texture2D eye_beam;

        float charge_speed;
        float fire_speed;

        public DemonEyeType()
        {
        }

        public override EntityInterface CreateInstance(EnemyInstanceData data)
        {
            EntityInterface e = null;
            e = new DemonEye(data);
            return e;
        }

        public override void Load(ContentManager content, string path)
        {
            DemonEyeTypeData data = content.Load<DemonEyeTypeData>(path);

            animation = new Animation((byte)data.Animation_Names.Count);

            for (byte i = 0; i < animation.Count; i++)
            {
                Textures[i] = content.Load<Texture2D>(data.Animation_Names[i]);
            }

            charging_animation = new Animation((byte)data.Animation_Charging.Count);

            for (byte i = 0; i < charging_animation.Count; i++)
            {
                charging_animation[i] = content.Load<Texture2D>(data.Animation_Charging[i]);
            }

            eye_beam = content.Load<Texture2D>(data.Eye_Beam);

            extents = data.Extents;
            charge_speed = data.Charge_Speed;
            fire_speed = data.Fire_Speed;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            DemonEye enemy = entity as DemonEye;

            Rectangle b = new Rectangle((int)entity.Pos.X, (int)entity.Pos.Y, (int)extents.X, (int)extents.Y);

            b.X += 10;
            b.Y += 10;
            b.Width -= 20;
            b.Height -= 20;

            if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
            {
                level.Scene.KillPlayer();
            }

            enemy.WaitTime += dt;

            if (enemy.State == 0)
            {
                if (enemy.TimeA.Tick(dt * 0.5f))
                {
                    if (animation.Count - 1 == enemy.Index)
                        enemy.Index = 0;
                    else
                        enemy.Index++;
                }

                if (enemy.WaitTime > 4f)
                {
                    enemy.WaitTime = 0f;
                    enemy.Index = 0;
                    enemy.State = 1;
                }
            }
            else if (enemy.State == 1)
            {
                if (enemy.TimeA.Tick(dt))
                {
                    if (charging_animation.Count - 1 == enemy.Index)
                        enemy.Index = 0;
                    else
                        enemy.Index++;
                }

                if (enemy.WaitTime > 1.5f)
                {
                    enemy.WaitTime = 0f;
                    enemy.Index = 0;
                    enemy.State = 2;
                }
            }
            else
            {
                enemy.Index = 0;

                if (enemy.WaitTime > 2f)
                {
                    enemy.WaitTime = 0f;
                    enemy.Index = 0;
                    enemy.State = 0;
                }
                else
                {
                    if (enemy.FacingFront)
                    {
                        b.X = (int)(enemy.Pos.X + extents.X);
                        b.Width = (int)(enemy.Core.End.X - (enemy.Core.Start.X + extents.X));
                    }
                    else
                    {
                        b.Width = (int)(enemy.Core.Start.X - enemy.Core.End.X);
                        b.X = (int)(enemy.Pos.X - b.Width);
                    }

                    //b.Y = (int)(enemy.Pos.Y - level.OffsetWorld.Y);
                    //b.Width = (int)enemy.Core.End.Y;
                    //b.Height = (int)extents.Y;

                    //b.Y = (int)(enemy.Pos.Y - level.OffsetWorld.Y + extents.Y * 0.35f);
                    b.Y = (int)(enemy.Pos.Y + extents.Y * 0.35f);
                    //b.Width = (int)enemy.Core.End.Y;
                    b.Height = (int)(extents.Y * 0.3f);

                    if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
                    {
                        level.Scene.KillPlayer();
                    }
                }
            }
        }

        public override void Draw(Level level, SpriteBatch sp, EntityInterface entity)
        {
            DemonEye enemy = entity as DemonEye;

            Rectangle b = new Rectangle((int)(entity.Pos.X - level.OffsetWorld.X),
                                        (int)(entity.Pos.Y - level.OffsetWorld.Y),
                                        (int)extents.X, (int)extents.Y);

            SpriteEffects effect = SpriteEffects.None;

            if (enemy.FacingFront)
                effect = SpriteEffects.FlipHorizontally;
            

            if (enemy.State == 0)
            {
                sp.Draw(Textures[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth); 
            }
            else if (enemy.State == 1)
            {
                sp.Draw(charging_animation[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth); 
            }
            else
            {
                sp.Draw(charging_animation[0], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);

                if (enemy.FacingFront)
                {
                    b.X = (int)(enemy.Pos.X + extents.X - level.OffsetWorld.X);
                    b.Width = (int)(enemy.Core.End.X - (enemy.Core.Start.X + extents.X)); 
                }
                else
                {
                    b.Width = (int)(enemy.Core.Start.X - enemy.Core.End.X);
                    b.X = (int)((enemy.Pos.X - b.Width) - level.OffsetWorld.X);
                }

                b.Y = (int)(enemy.Pos.Y - level.OffsetWorld.Y + extents.Y * 0.35f);
                b.Height = (int)(extents.Y * 0.3f);

                sp.Draw(eye_beam, b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth); 
            }
        }
    }
}
