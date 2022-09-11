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
    public class GroundType : EntityInterfaceType
    {
        Texture2D texture;
        Vector2 extents;

        public virtual EntityInterface CreateInstance(EntityInstanceData data)
        {
            EntityInterface e = new Ground(data);

            return e;
        }

        public override void Update(Level level, EntityInterface entity, float dt)
        {
            JellyPlayer pl = level.Player;
            Vector2 prev_pos = pl.PrevPos;
            Rectangle bounds = pl.Bounds;
            Rectangle ground = new Rectangle((int)entity.Pos.X, (int)entity.Pos.Y, (int)extents.X, (int)extents.Y);

            bool falling = pl.Falling;
            bool moving = true;

            Platform.Side side = Platform.CollideObjects(bounds, ground, prev_pos, pl.Falling, out moving, out falling);

            if(side == Platform.Side.None)
                return;

            if (side == Platform.Side.Top)
            {
                pl.Landed((int)(entity.Pos.Y));
            }
            else if (side == Platform.Side.Right)
            {
                if( (pl.Y + pl.Height) > ground.Y)
                    pl.X = (int)(entity.Pos.X + extents.X + 2.0f);
            }
            else if (side == Platform.Side.Left)
            {
                if ((pl.Y + pl.Height) > ground.Y)
                    pl.X = (int)(entity.Pos.X - pl.Width - 2.0f);
            }
            else if (side == Platform.Side.Bottom)
            {
                // - 25f is for adjusting visual colliding
                pl.Y = (int)(entity.Pos.Y + extents.Y + 2.0f - 25f);
                Vector2 vel = pl.Velocity;
                vel.Y = 5f;
                pl.Velocity = vel;
                pl.Falling = true;
            }
        }

        public override void Draw(Level level, SpriteBatch sp, EntityInterface entity)
        {
            Rectangle b = new Rectangle((int)(entity.Pos.X - level.OffsetWorld.X),
                                        (int)(entity.Pos.Y - level.OffsetWorld.Y),
                                        (int)extents.X, (int)extents.Y);

            sp.Draw(texture, b, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, entity.Depth);
            //sp.Draw(level.Scene.BoundingTexture, b, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, entity.Depth);     
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
