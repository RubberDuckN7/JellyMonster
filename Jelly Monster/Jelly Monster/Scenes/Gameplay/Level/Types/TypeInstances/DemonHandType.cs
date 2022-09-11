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
    public class DemonHandType : EnemyType
    {
        Texture2D demon_claw;
        float range;

		public DemonHandType()
		{
		
		}

        public override EntityInterface CreateInstance(EnemyInstanceData data)
        {
            EntityInterface e = null;
            e = new DemonHand(data);
            return e;
        }

        public override void Load(ContentManager content, string path)
        {
            DemonHandTypeData data = content.Load<DemonHandTypeData>(path);

            animation = new Animation((byte)data.Demon_Hand.Count);

            for (byte i = 0; i < animation.Count; i++)
            {
                Textures[i] = content.Load<Texture2D>(data.Demon_Hand[i]);
            }

            demon_claw = content.Load<Texture2D>(data.Demon_Claw);

            extents = data.Extents;
            range = data.Range;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            DemonHand enemy = entity as DemonHand;

            Rectangle b = new Rectangle((int)entity.Pos.X, (int)entity.Pos.Y, (int)extents.X, (int)extents.Y);

            b.X += 15;
            b.Y += 15;
            b.Width -= 30;
            b.Height -= 30;

            if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
            {
                level.Scene.KillPlayer();
                return;
            }

            float x = (float)(level.Player.Bounds.X + level.Player.Bounds.Width * 0.5f);
            float speed = 120f;

            if (x > enemy.Pos.X - range && x < enemy.Pos.X + extents.X + range)
            {
                if (enemy.Claw.active == false)
                {
                    enemy.Claw.active = true;
                    enemy.Claw.lerp = 0f;
                    enemy.Claw.state = 1;

                    enemy.Claw.pos.X = enemy.Pos.X + 14.5f;
                    enemy.Claw.pos.Y = enemy.Pos.Y + 30f;
                }
            }

            if (enemy.Claw.active)
            {
                // Update regardless if player is near or not, as the claw
                // has been activated
                b.Width = 40;
                b.Height = 40;

                if (enemy.Claw.state == 1)
                {
                    // Lerp into proper direction
                    //if (enemy.Claw.extending_left)
                    if (enemy.Left)
                    {
                        enemy.Claw.pos.X -= speed * dt;
                        if (enemy.Claw.pos.X < enemy.Core.Start.X - enemy.Core.End.X)
                        {
                            enemy.Claw.state = 2;
                        }
                        //enemy.Claw.pos.X = MathHelper.Lerp(enemy.Pos.X, enemy.Pos.X - enemy.Core.End.X - 40f, enemy.Claw.lerp);
                    }
                    else
                    {
                        enemy.Claw.pos.X += speed * dt;
                        if (enemy.Claw.pos.X + 70f > enemy.Core.Start.X + enemy.Core.End.X)
                        {
                            enemy.Claw.state = 2;
                        }
                        //enemy.Claw.pos.X = MathHelper.Lerp(enemy.Pos.X, enemy.Pos.X + extents.X + enemy.Core.End.X, enemy.Claw.lerp);
                    }

                    /*enemy.Claw.lerp += dt * 0.5f;
                    if (enemy.Claw.lerp > 1f)
                    {
                        enemy.Claw.lerp = 1f;
                        enemy.Claw.state = 2;
                    }*/
                }
                else if (enemy.Claw.state == 2)
                {
                    //if (enemy.Claw.extending_left)
                    if (enemy.Left)
                    {
                        enemy.Claw.pos.X += speed * dt;
                        if (enemy.Claw.pos.X > enemy.Pos.X)
                        {
                            enemy.Claw.state = 0;
                            enemy.Claw.active = false;
                        }
                        //enemy.Claw.pos.X = MathHelper.Lerp(enemy.Pos.X, enemy.Pos.X - enemy.Core.End.X - 40f, enemy.Claw.lerp);
                    }
                    else
                    {
                        enemy.Claw.pos.X -= speed * dt;
                        if (enemy.Claw.pos.X < enemy.Pos.X)
                        {
                            enemy.Claw.state = 0;
                            enemy.Claw.active = false;
                        }
                        //enemy.Claw.pos.X = MathHelper.Lerp(enemy.Pos.X, enemy.Pos.X + extents.X + enemy.Core.End.X, enemy.Claw.lerp);
                    }

                    /*enemy.Claw.lerp -= dt * 0.5f;
                    if (enemy.Claw.lerp < 0f)
                    {
                        enemy.Claw.lerp = 0f;
                        enemy.Claw.state = 0;
                        enemy.Claw.active = false;
                    }*/
                }

                b.X = (int)enemy.Claw.pos.X + 10;
                b.Y = (int)enemy.Claw.pos.Y + 10;
                b.Width = 50;
                b.Height = 50;

                if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
                {
                    level.Scene.KillPlayer();
                    return;
                }
            }
        }

        /*public override void Update(Level level, EntityInterface entity, float dt)
        {
            DemonHand enemy = entity as DemonHand;

            Rectangle b = new Rectangle((int)entity.Pos.X, (int)entity.Pos.Y, (int)extents.X, (int)extents.Y);

            b.X += 15;
            b.Y += 15;
            b.Width -= 30;
            b.Height -= 30;

            if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
            {
                level.Scene.KillPlayer();
                return;
            }

            float x = (float)(level.Player.Bounds.X + level.Player.Bounds.Width * 0.5f);

            // Just for temporary, to skip rewriting from range to end.X
            //range = enemy.Core.End.X;

            if (x > enemy.Pos.X - range && x < enemy.Pos.X + extents.X + range)
            {
                if (enemy.Claw.active == false)
                {
                    enemy.Claw.active = true;
                    enemy.Claw.lerp = 0f;
                    enemy.Claw.state = 1;

                    enemy.Claw.pos.X = enemy.Pos.X + 14.5f;
                    enemy.Claw.pos.Y = enemy.Pos.Y + 30f;
                }
            }

            if (enemy.Claw.active)
            {
                // Update regardless if player is near or not, as the claw
                // has been activated
                b.Width = 40;
                b.Height = 40;

                if (enemy.Claw.state == 1)
                {
                    // Lerp into proper direction
                    //if (enemy.Claw.extending_left)
                    if(enemy.Left)
                    {
                        enemy.Claw.pos.X = MathHelper.Lerp(enemy.Pos.X, enemy.Pos.X - range - 40f, enemy.Claw.lerp);
                    }
                    else
                    {
                        enemy.Claw.pos.X = MathHelper.Lerp(enemy.Pos.X, enemy.Pos.X + extents.X + range, enemy.Claw.lerp);
                    }

                    enemy.Claw.lerp += dt * 0.5f;
                    if (enemy.Claw.lerp > 1f)
                    {
                        enemy.Claw.lerp = 1f;
                        enemy.Claw.state = 2;
                    }
                }
                else if (enemy.Claw.state == 2)
                {
                    //if (enemy.Claw.extending_left)
                    if(enemy.Left)
                    {
                        enemy.Claw.pos.X = MathHelper.Lerp(enemy.Pos.X, enemy.Pos.X - range - 40f, enemy.Claw.lerp);
                    }
                    else
                    {
                        enemy.Claw.pos.X = MathHelper.Lerp(enemy.Pos.X, enemy.Pos.X + extents.X + range, enemy.Claw.lerp);
                    }

                    enemy.Claw.lerp -= dt * 0.5f;
                    if (enemy.Claw.lerp < 0f)
                    {
                        enemy.Claw.lerp = 0f;
                        enemy.Claw.state = 0;
                        enemy.Claw.active = false;
                    }
                }

                b.X = (int)enemy.Claw.pos.X + 10;
                b.Y = (int)enemy.Claw.pos.Y + 10;
                b.Width = 50;
                b.Height = 50;

                if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
                {
                    level.Scene.KillPlayer();
                    return;
                }
            }
        }*/

        public override void Draw(Level level, SpriteBatch sp, EntityInterface entity)
        {
            Rectangle b = new Rectangle((int)(entity.Pos.X - level.OffsetWorld.X),
                                        (int)(entity.Pos.Y - level.OffsetWorld.Y),
                                        (int)extents.X, (int)extents.Y);

            DemonHand enemy = entity as DemonHand;

            sp.Draw(Textures[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, entity.Depth);

            if (enemy.Claw.active)
            {
                b.X = (int)(enemy.Claw.pos.X - level.OffsetWorld.X);
                b.Y = (int)(enemy.Claw.pos.Y - level.OffsetWorld.Y);

                b.Width = 70;
                b.Height = 70;

                SpriteEffects effect = SpriteEffects.None;

                //if (enemy.Claw.extending_left)
                if(enemy.Left)
                    effect = SpriteEffects.FlipHorizontally;

                sp.Draw(demon_claw, b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);
            }
        }
	}
}