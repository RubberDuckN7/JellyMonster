using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IrisEngine
{
    public class EntityScaled
    {
        Rectangle bounds;

        float edge_w;
        float edge_h;
        float border_w;
        float border_h;

        RScaledResources resources;

        public EntityScaled(RScaledResources resources, Rectangle bounds, float ew, float eh, float bw, float bh)
        {
            this.bounds = bounds;

            this.edge_w = ew;
            this.edge_h = eh;
            this.border_w = bw;
            this.border_h = bh;

            this.resources = resources;
        }

        public void Draw(SpriteBatch sp)
        {
            Draw(sp, Color.White);
        }

        public void Draw(SpriteBatch sp, Color color)
        {
            Draw(sp, color, Vector2.Zero);
        }

        public void Draw(SpriteBatch sp, Vector2 offset)
        {
            Draw(sp, Color.White, offset);
        }

        public void Draw(SpriteBatch sp, Color color, Vector2 offset)
        {
            // Small note: Using same Rectangle seems so "override" or something
            // in which case it messes up drawing, and other part wont appear.
            // Using new Rectangle seems to be one solution for now.

            int x = bounds.X;
            int y = bounds.Y;

            bounds.X += (int)offset.X;
            bounds.Y += (int)offset.Y;

            // Draw background
            sp.Draw(resources.background, bounds, color);

            // Draw borders
            Rectangle border_top = new Rectangle(bounds.X, bounds.Y, bounds.Width, (int)(border_h));
            Rectangle border_bottom = new Rectangle(bounds.X, bounds.Y + (int)(bounds.Height - border_h), bounds.Width, (int)(border_h));

            sp.Draw(resources.border_horizontal, border_top, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.5f);
            sp.Draw(resources.border_horizontal, border_bottom, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.5f);

            Rectangle border_left = new Rectangle(bounds.X, bounds.Y, (int)border_w, bounds.Height);
            Rectangle border_right = new Rectangle(bounds.X + (int)(bounds.Width - border_w), bounds.Y, (int)(border_w), bounds.Height);

            sp.Draw(resources.border_vertical, border_left, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.5f);
            sp.Draw(resources.border_vertical, border_right, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.5f);

            // Craw corners

            Rectangle corner_lt = new Rectangle(bounds.X, bounds.Y, (int)edge_w, (int)edge_h);
            Rectangle corner_lb = new Rectangle(bounds.X, bounds.Y + (int)(bounds.Height - edge_h), (int)edge_w, (int)edge_h);

            sp.Draw(resources.corner_tl, corner_lt, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.7f);
            sp.Draw(resources.corner_bl, corner_lb, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.7f);

            Rectangle corner_rt = new Rectangle(bounds.X + (int)(bounds.Width - edge_w), bounds.Y, (int)edge_w, (int)edge_h);
            Rectangle corner_rb = new Rectangle(bounds.X + (int)(bounds.Width - edge_w), bounds.Y + (int)(bounds.Height - edge_h), (int)edge_w, (int)edge_h);

            sp.Draw(resources.corner_tr, corner_rt, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.7f);
            sp.Draw(resources.corner_br, corner_rb, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.7f);

            bounds.X = x;
            bounds.Y = y;

            ////sp.Draw(resources.background, new Rectangle(10, 10, 780, 460), color);

            //Rectangle b = bounds;

            //int x = bounds.X;
            //int y = bounds.Y;
            //int w = bounds.Width;
            //int h = bounds.Height;

            //bounds.X += (int)offset.X;
            //bounds.Y += (int)offset.Y;

            //// Draw background
            //sp.Draw(resources.background, b, color);

         

            //// Draw borders horizontal
            //bounds.Height = (int)border_h;

            //sp.Draw(resources.border_horizontal, bounds, color);

            //bounds.Y -= (h - (int)border_h);

            //sp.Draw(resources.border_horizontal, bounds, color);

            //// Draw borders vertical
            //bounds.Y = y + (int)offset.Y;
            //bounds.Width = (int)border_w;
            //bounds.Height = h;

            //sp.Draw(resources.border_vertical, bounds, color);

            //bounds.X -= (x - (int)border_w);

            //sp.Draw(resources.border_vertical, bounds, color);

            //// Draw corners
            //bounds.X = x;
            //bounds.Y = y;

            //bounds.Width = (int)edge_w;
            //bounds.Height = (int)edge_h;

            //sp.Draw(resources.corner_tl, bounds, color);

            //bounds.X = (int)(x + w - edge_w);

            //sp.Draw(resources.corner_tr, bounds, color);

            //bounds.Y = (int)(y + h - edge_h);

            //sp.Draw(resources.corner_br, bounds, color);

            //bounds.X = x;

            //sp.Draw(resources.corner_bl, bounds, color);
        }

        public Rectangle Bounds
        {
            get { return bounds; }
            set { bounds = value; }
        }

        public float BorderW
        {
            get { return border_w; }
        }

        public float BorderH
        {
            get { return border_h; }
        }
    }
}
