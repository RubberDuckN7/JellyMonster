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
    public class EnemyType : EntityInterfaceType
    {
        protected Animation animation;
        protected Vector2 extents;

        public EnemyType()
        {

        }

        public virtual void Load(ContentManager content, string path)
        {

        }

        public virtual EntityInterface CreateInstance(EnemyInstanceData data)
        {
            return null;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            Enemy enemy = entity as Enemy;
            if (enemy.TimeA.Tick(dt))
            {
                if (animation.Count - 1 == (int)enemy.Index)
                    enemy.Index = 0;
                else
                    enemy.Index++;
            }

            Rectangle b = new Rectangle((int)entity.Pos.X, (int)entity.Pos.Y, (int)extents.X, (int)extents.Y);

            b.X += 10;
            b.Y += 10;
            b.Width -= 20;
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

            SpriteEffects effect = SpriteEffects.None;
            
            Enemy enemy = entity as Enemy;
            
            if (enemy.FacingFront)
                effect = SpriteEffects.FlipHorizontally;
            sp.Draw(Textures[enemy.Index], b, null, Color.White, 0f, Vector2.Zero, effect, entity.Depth); 
        }

        public Animation Textures
        {
            get { return animation; }
            set { animation = value; }
        }

        public Vector2 Extents
        {
            get { return extents; }
            set { extents = value; }
        }
    }
}
