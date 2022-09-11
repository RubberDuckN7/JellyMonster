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
    public class LaserRobotType : EnemyType
    {
		Animation attack_animation;
		Texture2D bullet;
		float bullet_speed;
		float fire_rate;

		public LaserRobotType()
		{
		
		}

        public override EntityInterface CreateInstance(EnemyInstanceData data)
        {
            EntityInterface e = null;
            e = new LaserRobot(data);
            return e;
            /*
            LaserRobot lr = e as LaserRobot;

            float range = 0f;
            if (lr.FacingFront)
            {
                range = lr.Core.End.X;
                range += extents.X;
                lr.Core.End = new Vector2(range, range);
            }

            return lr;*/
        }

        public override void Load(ContentManager content, string path)
        {
            LaserRobotTypeData data = content.Load<LaserRobotTypeData>(path);

            animation = new Animation((byte)data.Laser_Robot_Waiting.Count);

            for (byte i = 0; i < animation.Count; i++)
            {
                Textures[i] = content.Load<Texture2D>(data.Laser_Robot_Waiting[i]);
            }

            attack_animation = new Animation((byte)data.Laser_Robot_Attacking.Count);

            for (byte i = 0; i < attack_animation.Count; i++)
            {
                attack_animation[i] = content.Load<Texture2D>(data.Laser_Robot_Attacking[i]);
            }

            bullet = content.Load<Texture2D>(data.Laser_Shot);

            extents = data.Extents;
            bullet_speed = data.Bullet_Speed;
            fire_rate = data.Fire_Rate;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            LaserRobot enemy = entity as LaserRobot;

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
            }
            else if (enemy.State == 1)
            {
                if (enemy.TimeA.Tick(dt))
                {
                    if (attack_animation.Count - 1 == enemy.Index)
                    {
                        enemy.Index = 0;
                        enemy.State = 2;
                        enemy.Fire(level.Player.PrevPos, extents);
                        enemy.WaitTime = 0f;
                    }
                    else
                        enemy.Index++;
                }
            }
            else if (enemy.State == 2)
            {
                enemy.BulletPos += enemy.BulletDir * bullet_speed * dt;

                if (enemy.BulletLeft)
                {
                    if (enemy.BulletPos.X < enemy.Pos.X - enemy.Core.End.X)
                    {
                        enemy.State = 0;
                        enemy.WaitTime = 0f;
                        enemy.Index = 0;
                        enemy.Fired = false;
                    }
                }
                else
                {
                    if (enemy.BulletPos.X > enemy.Pos.X + enemy.Core.End.X + extents.X)
                    {
                        enemy.State = 0;
                        enemy.WaitTime = 0f;
                        enemy.Index = 0;
                        enemy.Fired = false;
                    }
                }
            }








            /*if (enemy.State == 0)
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
            }*/

            Rectangle b = new Rectangle((int)entity.Pos.X, (int)entity.Pos.Y, (int)extents.X, (int)extents.Y);

            b.X += 7;
            b.Y += 7;
            b.Width -= 14;
            b.Height -= 14;

            if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
            {
                level.Scene.KillPlayer();
                return;
            }

            if (enemy.Fired)
            {
                b.X = (int)(enemy.BulletPos.X) + 4;
                b.Y = (int)(enemy.BulletPos.Y) + 2;
                b.Width = 14;
                b.Height = 6;

                if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
                {
                    level.Scene.KillPlayer();
                }
            }
        }

        /*public override void Update(Level level, EntityInterface entity, float dt)
        {
            LaserRobot enemy = entity as LaserRobot;

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
        }*/

        public override void Draw(Level level, SpriteBatch sp, EntityInterface entity)
        {
            LaserRobot enemy = entity as LaserRobot;

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
                sp.Draw(attack_animation[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);
            }
            else if (enemy.State == 2)
            {
                sp.Draw(Textures[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);

                b.X = (int)(enemy.BulletPos.X - level.OffsetWorld.X);
                b.Y = (int)(enemy.BulletPos.Y - level.OffsetWorld.Y);
                
                b.Width = 20;
                b.Height = 10;
                
                sp.Draw(bullet, b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth - 0.1f);           
            }

            /*if (enemy.State == 0)
            {
                sp.Draw(Textures[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);

                if (enemy.Fired)
                {
                    b.X = (int)(enemy.BulletPos.X - level.OffsetWorld.X);
                    b.Y = (int)(enemy.BulletPos.Y - level.OffsetWorld.Y);

                    b.Width = 20;
                    b.Height = 10;

                    sp.Draw(bullet, b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth - 0.1f);
                }
            }
            else if (enemy.State == 1)
            {
                sp.Draw(attack_animation[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);
            }*/
        }
		
		public Animation Attack_Animation
		{
			get { return attack_animation; }
			set { attack_animation = value; }
		}
		
		public Texture2D Bullet
		{
			get { return bullet; }
			set { bullet = value; }
		}
		
		public float Bullet_Speed
		{
			get { return bullet_speed; }
			set { bullet_speed = value; }
		}
		
		public float Fire_Rate
		{
			get { return fire_rate; }
			set { fire_rate = value; }
		}
		
	}
}