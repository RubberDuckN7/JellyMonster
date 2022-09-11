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
    public class VisualStaticType : EntityInterfaceType
    {
        Texture2D texture;
        Vector2 extents;

        public EntityInterface CreateInstance(EntityInstanceData data)
        {
            EntityInterface e = new VisualStatic(data);

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

            sp.Draw(texture, b, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, entity.Depth); 
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public Vector2 Extents
        {
            get { return extents; }
            set { extents = value; }
        }
    }
}
