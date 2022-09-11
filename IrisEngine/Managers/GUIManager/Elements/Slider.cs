using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

////////////////////////////////////////////////////////////////////////////////////////////
// No event for slider, it will use GetValue float only.
//
////////////////////////////////////////////////////////////////////////////////////////////

namespace IrisEngine
{
    public class Slider : IElement
    {
        EntityLine entity;
        Rectangle handle;
        Texture2D texture_handle;
        float move_to;
        float normalized_value;
        bool pressed;


        public Slider(SliderResources resources, Rectangle bounds)
        {
            float size = (float)(bounds.Width);

            this.entity = new EntityLine(resources, bounds, size, size);
            this.texture_handle = resources.handle;
            this.handle = new Rectangle(bounds.X, (int)(bounds.Y + bounds.Height * 0.5f), (int)size, (int)size);
            this.move_to = (float)handle.Y;
            this.normalized_value = 0.0f;
            this.pressed = false;

        }

        public Slider(SliderResources resources, Rectangle bounds, int handle_width, int handle_height, int end_width, int end_height)
        {
            this.entity = new EntityLine(resources, bounds, end_width, end_height);
            this.texture_handle = resources.handle;

            float temp_x = (float)(bounds.Width - handle_width);
            this.handle = new Rectangle((int)temp_x, (int)(bounds.Y + bounds.Height * 0.5f), handle_width, handle_height);

            this.move_to = (float)handle.Y;
            this.normalized_value = 0.0f;
            this.pressed = false;
        }

        public override void Draw(SpriteBatch sp, Color color, Vector2 offset)
        {
            entity.Draw(sp, offset, color);

            int x = handle.X;
            int y = handle.Y;

            handle.X += (int)offset.X;
            handle.Y += (int)offset.Y;

            sp.Draw(texture_handle, handle, color);

            handle.X = x;
            handle.Y = y;
        }

        public void Draw(SpriteBatch sp, Color color)
        {
            Draw(sp, color, Vector2.Zero);
        }

        public override void HandleInput(TouchCollection touches, float dt)
        {
            MoveHandle(dt);

            for (byte i = 0; i < touches.Count; i++)
            {
                Vector2 point = touches[i].Position;

                if (Utility.PointVsRectangle(point, entity.Bounds))
                {
                    if (touches[i].State == TouchLocationState.Pressed)
                    {
                        PressHandle(touches[i].Position);
                    }
                    else if (touches[i].State == TouchLocationState.Moved)
                    {
                        
                    }
                    else if (touches[i].State == TouchLocationState.Released)
                    {
                        
                    }
                }
            }
        }

        public float Value
        {
            get { return normalized_value; }
            set
            {
                // Move handle to position that represents this value.
            }
        }

        private void PressHandle(Vector2 point)
        {
            if (!pressed)
            {
                if (entity.Bounds.Y + entity.EndH > point.Y)
                    return;
                else if (entity.Bounds.Y + entity.Bounds.Height - entity.EndH < point.Y)
                    return;
                // Pressing handle it self for slider should not move.
                if (!Utility.PointVsRectangle(point, handle))
                {
                    pressed = true;
                    move_to = point.Y;
                }
            }
        }

        private void MoveHandle(Vector2 point)
        {

        }

        private void MoveHandle(float dt)
        {
            if (pressed)
            {
                float speed = entity.Bounds.Height * 0.8f * dt;
                if (move_to > handle.Y)
                {
                    // Speed is dependent on size of slider
                    handle.Y += (int)speed;
                }
                else
                {
                    handle.Y -= (int)speed;
                }

                if (move_to > handle.Y && move_to < handle.Y + handle.Height)
                {
                    pressed = false;
                }

                if (handle.Y < entity.Bounds.Y + entity.EndH)
                {
                    handle.Y = (int)(entity.Bounds.Y + entity.EndH);
                    pressed = false;
                }
                else if (handle.Y + handle.Height > entity.Bounds.Y + entity.Bounds.Height - entity.EndH)
                {
                    handle.Y = (int)(entity.Bounds.Y + entity.Bounds.Height - handle.Height - entity.EndH);
                    pressed = false;
                }

                normalized_value = NormalizeValue();
            }
        }

        private float NormalizeValue()
        {
            float size = (float)(entity.Bounds.Height - (entity.EndH * 2.0f + handle.Height));
            float pos = (float)(handle.Y - entity.Bounds.Y - entity.EndH);

            return pos / size;
        }

        private void ReleaseHandle()
        {
            pressed = false;
        }


    }
}
