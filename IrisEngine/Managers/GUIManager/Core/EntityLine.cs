using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IrisEngine
{
    public class EntityLine
    {
        SliderResources resources;
        Rectangle bounds;
        float end_width;
        float end_height;
        

        public EntityLine(SliderResources resources, int x, int y, int w, int h, float end_width, float end_height)
        {
            this.resources = resources;
            this.bounds = new Rectangle(x, y, w, h);
            this.end_width = end_width;
            this.end_height = end_height;
        }

        public EntityLine(SliderResources resources, Rectangle bounds, float end_width, float end_height)
        {
            this.resources = resources;
            this.bounds = bounds;
            this.end_width = end_width;
            this.end_height = end_height;
        }

        public void Draw(SpriteBatch sp)
        {
            Draw(sp, Color.White);
        }

        public void Draw(SpriteBatch sp, Color color)
        {
            Draw(sp, Vector2.Zero, color);
        }

        public void Draw(SpriteBatch sp, Vector2 offset, Color color)
        {
            int x = bounds.X;
            int y = bounds.Y;

            bounds.X += (int)offset.X;
            bounds.Y += (int)offset.Y;

            sp.Draw(resources.background, bounds, color);

            float temp_x = (float)(end_width - bounds.Width);
            float temp_y = (float)(end_height - bounds.Height);

            Rectangle b_top = new Rectangle(0, 0, (int)end_width, (int)end_height);
            Rectangle b_bottom= new Rectangle(0, 0, (int)end_width, (int)end_height);

            b_top.X = (int)(bounds.X + temp_x * 0.5f);
            b_top.Y = (int)(bounds.Y);

            b_bottom.X = b_top.X;
            b_bottom.Y = (int)(bounds.Y + bounds.Height - end_height);

            sp.Draw(resources.top, b_top, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.5f);
            sp.Draw(resources.bottom, b_bottom, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.5f);


            bounds.X = x;
            bounds.Y = y;
        }

        public Rectangle Bounds
        {
            get { return bounds; }
        }

        public float EndW
        {
            get { return end_width; }
        }

        public float EndH
        {
            get { return end_height; }
        }

    }
}
