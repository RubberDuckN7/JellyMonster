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
    public class CollectableType : EntityInterfaceType
    {
        Texture2D texture;
        Vector2 extents;
        byte score;

        public CollectableType()
        {

        }

        public EntityInterface CreateInstance(EntityInstanceData data)
        {
            EntityInterface e = new Collectable(data);

            return e;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            if ((entity as Collectable).Taken)
                return;

            Rectangle b = new Rectangle((int)entity.Pos.X, (int)entity.Pos.Y, (int)extents.X, (int)extents.Y);

            if (Utility.RectangleVsRectangle(level.Player.Bounds, b))
            {
                level.Scene.AddScore(score);
                (entity as Collectable).Taken = true;
            }
        }

        public override void Draw(Level level, SpriteBatch sp, EntityInterface entity)
        {
            if ((entity as Collectable).Taken)
                return;

            Rectangle b = new Rectangle((int)(entity.Pos.X - level.OffsetWorld.X), 
                                        (int)(entity.Pos.Y - level.OffsetWorld.Y),
                                        (int)extents.X, (int)extents.Y);

            sp.Draw(texture, b, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, entity.Depth);
            //sp.Draw(level.Scene.BoundingTexture, b, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 1f); 
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

        public byte Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
