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
    public class WormType : EnemyType
    {
		Texture2D worm_waiting;
		Texture2D bullet;
		float bullet_speed;
		float fire_rate;

		public WormType()
		{
		
		}

        public override EntityInterface CreateInstance(EnemyInstanceData data)
        {
            EntityInterface e = null;
            e = new Worm(data);
            return e;
        }

        public override void Load(ContentManager content, string path)
        {
            WormTypeData data = content.Load<WormTypeData>(path);

            animation = new Animation((byte)data.Worm_Monster_Attacking.Count);

            for (byte i = 0; i < animation.Count; i++)
            {
                Textures[i] = content.Load<Texture2D>(data.Worm_Monster_Attacking[i]);
            }

            worm_waiting = content.Load<Texture2D>(data.Worm_Waiting);

            bullet = content.Load<Texture2D>(data.Acid_Bullet);

            extents = data.Extents;
            bullet_speed = data.Bullet_Speed;
            fire_rate = data.Fire_Rate;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            Worm enemy = entity as Worm;

            Vector2 dir = enemy.Core.End - enemy.Core.Start;

            if (level.Player.X < enemy.Pos.X)
                enemy.FacingFront = false;
            else
                enemy.FacingFront = true;

            enemy.WaitTime += dt;

            if (enemy.State == 0)
            {
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
                    if (animation.Count - 1 == enemy.Index)
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

            b.X += 10;
            b.Y += 5;
            b.Width -= 20;
            b.Height -= 10;

            if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
            {
                level.Scene.KillPlayer();
                return;
            }

            if (enemy.Fired && enemy.State == 0)
            {
                b.X = (int)(enemy.BulletPos.X) + 5;
                b.Y = (int)(enemy.BulletPos.Y) + 10;
                b.Width = 10;
                b.Height = 20;

                if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
                {
                    level.Scene.KillPlayer();
                }
            }
        }

        public override void Draw(Level level, SpriteBatch sp, EntityInterface entity)
        {
            Worm enemy = entity as Worm;

            Rectangle b = new Rectangle((int)(entity.Pos.X - level.OffsetWorld.X),
                                        (int)(entity.Pos.Y - level.OffsetWorld.Y),
                                        (int)extents.X, (int)extents.Y);

            SpriteEffects effect = SpriteEffects.None;

            if (enemy.FacingFront)
                effect = SpriteEffects.FlipHorizontally;

            if (enemy.State == 0)
            {
                sp.Draw(worm_waiting, b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);

                if (enemy.Fired)
                {
                    b.X = (int)(enemy.BulletPos.X - level.OffsetWorld.X);
                    b.Y = (int)(enemy.BulletPos.Y - level.OffsetWorld.Y);

                    b.Width = 20;
                    b.Height = 30;

                    sp.Draw(bullet, b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);
                }
            }
            else if (enemy.State == 1)
            {
                sp.Draw(animation[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);
            }
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