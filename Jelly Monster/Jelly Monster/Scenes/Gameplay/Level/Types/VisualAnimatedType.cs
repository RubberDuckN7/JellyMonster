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
    public class VisualAnimatedType : EntityInterfaceType
    {
        Animation animation;
        Time time;
        Vector2 extents;

        public VisualAnimatedType()
        {
            time = new Time();
            time.Length = 0.2f;
        }

        public EntityInterface CreateInstance(EntityInstanceData data)
        {
            EntityInterface e = new VisualAnimated(data);

            return e;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            base.Update(level, entity, dt);
        }

        public override void Draw(Level level, SpriteBatch sp, EntityInterface entity)
        {
            Rectangle b = new Rectangle((int)(entity.Pos.X - level.OffsetWorld.X),
                                        (int)(entity.Pos.Y - level.OffsetWorld.Y),
                                        (int)extents.X, (int)extents.Y);

            VisualAnimated va = entity as VisualAnimated;

            sp.Draw(animation[va.Index], b, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, entity.Depth); 
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
