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
    public class SpikesType : EnemyType
    {
		Animation remove;
        Texture2D waiting;

		public SpikesType()
		{
		
		}

        public override EntityInterface CreateInstance(EnemyInstanceData data)
        {
            EntityInterface e = null;
            e = new Spikes(data);
            return e;
        }

        public override void Load(ContentManager content, string path)
        {
            SpikesTypeData data = content.Load<SpikesTypeData>(path);

            animation = new Animation((byte)data.Spikes_Attacking.Count);

            for (byte i = 0; i < animation.Count; i++)
            {
                Textures[i] = content.Load<Texture2D>(data.Spikes_Attacking[i]);
            }

            remove = new Animation((byte)data.Spikes_Removing.Count);

            for (byte i = 0; i < remove.Count; i++)
            {
                remove[i] = content.Load<Texture2D>(data.Spikes_Removing[i]);
            }

            waiting = content.Load<Texture2D>(data.Spikes_Waiting);

            extents = data.Extents;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            Spikes enemy = entity as Spikes;

            enemy.WaitTime += dt;

            if (enemy.State == 0)
            {
                if (enemy.WaitTime > 2f)//enemy.Core.End.X)
                {
                    enemy.State = 1;
                    enemy.WaitTime = 0f;
                }
            }
            else if (enemy.State == 1)
            {
                if (enemy.TimeA.Tick(dt))
                {
                    if (animation.Count - 1 == (int)enemy.Index)
                    {
                        enemy.Index = (byte)(animation.Count - 1);
                        enemy.WaitTime = 0f;
                        enemy.State = 2;
                    }
                    else
                        enemy.Index++;
                }
            }
            else if(enemy.State == 2)
            {
                if (enemy.WaitTime > 1f) //enemy.Core.End.Y)
                {
                    enemy.State = 3;
                    enemy.WaitTime = 0f;
                    enemy.Index = 0;
                }
            }
            else if (enemy.State == 3)
            {
                if (enemy.TimeA.Tick(dt))
                {
                    if (remove.Count - 1 == (int)enemy.Index)
                    {
                        enemy.Index = 0;
                        enemy.WaitTime = 0f;
                        enemy.State = 0;
                    }
                    else
                        enemy.Index++;
                }
            }

            if (enemy.State == 0)
                return;

            Rectangle b = new Rectangle((int)entity.Pos.X, (int)entity.Pos.Y, (int)extents.X, (int)extents.Y);

            b.X += 20;
            b.Y += 15;
            b.Width -= 40;
            b.Height -= 30;

            if (enemy.State == 3 || enemy.State == 1)
            {
                b.Y += (int)(b.Height * 0.5f);
                b.Height = (int)(b.Height * 0.5f); 
            }

            if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
            {
                level.Scene.KillPlayer();
            }
        }

        public override void Draw(Level level, SpriteBatch sp, EntityInterface entity)
        {
            Spikes enemy = entity as Spikes;

            Rectangle b = new Rectangle((int)(entity.Pos.X - level.OffsetWorld.X),
                                        (int)(entity.Pos.Y - level.OffsetWorld.Y),
                                        (int)extents.X, (int)extents.Y);

            SpriteEffects effect = SpriteEffects.None;

            //if (enemy.FacingFront)
            //    effect = SpriteEffects.FlipHorizontally;

            if (enemy.State == 0)
            {
                sp.Draw(waiting, b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);
            }
            else if (enemy.State == 1 || enemy.State == 2)
            {
                sp.Draw(animation[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);
            }
            else if (enemy.State == 3)
            {
                sp.Draw(remove[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);
            }
        }		
	}
}