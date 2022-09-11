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
    public class MuffinMonsterType : EnemyType
    {
		Texture2D waiting;
		float range;

		public MuffinMonsterType()
		{
            range = 50f;
		}

        public override EntityInterface CreateInstance(EnemyInstanceData data)
        {
            EntityInterface e = null;
            e = new MuffinMonster(data);
            return e;
        }

        public override void Load(ContentManager content, string path)
        {
            MuffinMonsterTypeData data = content.Load<MuffinMonsterTypeData>(path);

            animation = new Animation((byte)data.Muffin_Attacking.Count);

            for (byte i = 0; i < animation.Count; i++)
            {
                Textures[i] = content.Load<Texture2D>(data.Muffin_Attacking[i]);
            }

            waiting = content.Load<Texture2D>(data.Muffin_Waiting);

            extents = data.Extents;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            MuffinMonster enemy = entity as MuffinMonster;

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

            if (enemy.State == 1)
            {
                if (enemy.TimeA.Tick(dt))
                {
                    if (animation.Count - 1 == (int)enemy.Index)
                        enemy.Index = 0;
                    else
                        enemy.Index++;
                }
            }

            Rectangle b = new Rectangle((int)entity.Pos.X, (int)entity.Pos.Y, (int)extents.X, (int)extents.Y);

            if (level.Player.Bounds.X + b.Width > enemy.Pos.X - range && level.Player.Bounds.X < enemy.Pos.X + extents.X + range)
            {
                enemy.State = 1;
            }
            else
            {
                enemy.State = 0;
                enemy.Index = 0;
            }

            if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
            {
                level.Scene.KillPlayer();
            }
        }

        public override void Draw(Level level, SpriteBatch sp, EntityInterface entity)
        {
            MuffinMonster enemy = entity as MuffinMonster;

            Rectangle b = new Rectangle((int)(entity.Pos.X - level.OffsetWorld.X),
                                        (int)(entity.Pos.Y - level.OffsetWorld.Y),
                                        (int)extents.X, (int)extents.Y);

            SpriteEffects effect = SpriteEffects.None;

            if (enemy.FacingFront)
                effect = SpriteEffects.FlipHorizontally;

            if (enemy.State == 0)
            {
                sp.Draw(waiting, b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);
            }
            else if (enemy.State == 1)
            {
                sp.Draw(animation[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth);
            }
        }		

		public float Range
		{
			get { return range; }
			set { range = value; }
		}
		
	}
}