using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IrisEngine
{
    public class Entity
    {
        Rectangle bounds;
        Texture2D texture;

        public Entity(Texture2D texture, int x, int y, int w, int h)
        {
            this.bounds = new Rectangle(x, y, w, h);
            this.texture = texture;
        }

        public Entity(Texture2D texture, Rectangle bounds)
        {
            this.bounds = bounds;
            this.texture = texture;
        }

        public void Draw(SpriteBatch sp)
        {
            Draw(sp, Color.White);
        }

        public void Draw(SpriteBatch sp, Color color)
        {
            sp.Draw(texture, bounds, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.5f);
        }

        public void Draw(SpriteBatch sp, Color color, Vector2 offset)
        {
            int x = bounds.X;
            int y = bounds.Y;

            bounds.X += (int)offset.X;
            bounds.Y += (int)offset.Y;

            sp.Draw(texture, bounds, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.5f);

            bounds.X = x;
            bounds.Y = y;
        }

        public Rectangle Bounds
        {
            get { return bounds; }
            set { bounds = value; }
        }

        public int X
        {
            get { return bounds.X; }
            set { bounds.X = value; }
        }

        public int Y
        {
            get { return bounds.Y; }
            set { bounds.Y = value; }
        }

        public int Width
        {
            get { return bounds.Width; }
            set { bounds.Width = value; }
        }

        public int Height
        {
            get { return bounds.Height; }
            set { bounds.Height = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

    }
}
