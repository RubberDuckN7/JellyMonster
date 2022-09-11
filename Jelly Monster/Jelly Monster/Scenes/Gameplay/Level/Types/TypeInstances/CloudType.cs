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
    public class CloudType : EnemyType
    {
		Animation attack_animation;
        Texture2D thunder_one;
        Texture2D thunder_two;
        float speed;
        float thunder_length;
        float wait_length;

		public CloudType()
		{
		
		}

        public override EntityInterface CreateInstance(EnemyInstanceData data)
        {
            EntityInterface e = null;
            e = new Cloud(data);
            return e;
        }

        public override void Load(ContentManager content, string path)
        {
            CloudTypeData data = content.Load<CloudTypeData>(path);

            animation = new Animation((byte)data.Cloud_Waiting.Count);

            for (byte i = 0; i < animation.Count; i++)
            {
                Textures[i] = content.Load<Texture2D>(data.Cloud_Waiting[i]);
            }

            attack_animation = new Animation((byte)data.Cloud_Attacking.Count);

            for (byte i = 0; i < attack_animation.Count; i++)
            {
                attack_animation[i] = content.Load<Texture2D>(data.Cloud_Attacking[i]);
            }

            thunder_one = content.Load<Texture2D>(data.Thunder_One);
            thunder_two = content.Load<Texture2D>(data.Thunder_Two);

            extents = data.Extents;
            speed = data.Speed;
            thunder_length = data.Thunder_Length;
            wait_length = data.Wait_Length;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            Cloud enemy = entity as Cloud;

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

            Rectangle b = new Rectangle((int)entity.Pos.X, (int)entity.Pos.Y, (int)extents.X, (int)extents.Y);

            b.X += 10;
            b.Y += 10;
            b.Width -= 20;
            b.Height -= 30;

            if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
            {
                level.Scene.KillPlayer();
                return;
            }

            enemy.StateTime += dt;

            if (enemy.State == 0)
            {
                if (enemy.TimeA.Tick(dt))
                {
                    if (animation.Count - 1 == (int)enemy.Index)
                        enemy.Index = 0;
                    else
                        enemy.Index++;
                }

                if (enemy.StateTime > wait_length)
                {
                    enemy.StateTime = 0f;
                    enemy.Index = 0;
                    enemy.State = 1;
                }
            }
            else if (enemy.State == 1)
            {
                if (enemy.TimeA.Tick(dt))
                {
                    enemy.ThunderLeft = !enemy.ThunderLeft;
                    if (attack_animation.Count - 1 == (int)enemy.Index)
                        enemy.Index = 0;
                    else
                        enemy.Index++;
                }

                if (enemy.StateTime > thunder_length)
                {
                    enemy.StateTime = 0f;
                    enemy.Index = 0;
                    enemy.State = 0;
                }



                /*b.X += 12;
                b.Y += b.Height;
                b.Height = 150;
                b.Width = 75;*/

                b.X = (int)entity.Pos.X + 12 + 10;
                b.Y = (int)entity.Pos.Y + (int)extents.Y;
                b.Height = 150;
                b.Width = 55;

                if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
                {
                    level.Scene.KillPlayer();
                    return;
                }
            }

        }

        public override void Draw(Level level, SpriteBatch sp, EntityInterface entity)
        {
            Rectangle b = new Rectangle((int)(entity.Pos.X - level.OffsetWorld.X),
                                        (int)(entity.Pos.Y - level.OffsetWorld.Y),
                                        (int)extents.X, (int)extents.Y);

            SpriteEffects effect = SpriteEffects.None;

            Cloud enemy = entity as Cloud;

            if (enemy.FacingFront)
                effect = SpriteEffects.FlipHorizontally;

            if (enemy.State == 0)
                sp.Draw(Textures[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);
            else
            {
                sp.Draw(attack_animation[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);

                b.X += 12;
                b.Y += b.Height;
                b.Height = 150;
                b.Width = 75;

                if(enemy.ThunderLeft)
                    sp.Draw(thunder_one, b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth); 
                else
                    sp.Draw(thunder_two, b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth); 
            }

        }
	}
}