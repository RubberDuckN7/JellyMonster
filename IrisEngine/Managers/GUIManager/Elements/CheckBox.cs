using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace IrisEngine
{
    public class CheckBox : IElement
    {
        public delegate void Callback(byte id, bool pressed);
        Entity entity;
        CheckBoxResources resources;
        byte id;
        bool pressed;

        public Callback Event;


        public CheckBox(CheckBoxResources resources, Rectangle bounds, byte id)
        {
            this.resources = resources;
            this.id = id;
            this.pressed = false;
            this.entity = new Entity(resources.background, bounds);
        }

        public override void Draw(SpriteBatch sp, Color color, Vector2 offset)
        {
            entity.Draw(sp, color, offset);

            if (pressed)
            {
                int x = entity.X;
                int y = entity.Y;

                Rectangle b = entity.Bounds;

                b.X += (int)offset.X;
                b.Y += (int)offset.Y;

                sp.Draw(resources.pressed, b, null, color, 0f, Vector2.Zero, SpriteEffects.None, 1f);

                entity.X = x;
                entity.Y = y;
            }
        }

        public void Draw(SpriteBatch sp, Color color)
        {
            entity.Draw(sp);
            if (pressed)
                sp.Draw(resources.pressed, entity.Bounds, color);
        }

        public override void HandleInput(TouchCollection touches, float dt)
        {
            for (byte i = 0; i < touches.Count; i++)
            {
                Vector2 point = touches[i].Position;

                if (Utility.PointVsRectangle(point, entity.Bounds))
                {
                    if (touches[i].State == TouchLocationState.Pressed)
                    {
                        pressed = !pressed;
                        Event(id, pressed);
                    }
                }
            }
        }

        public void Checked(bool pressed)
        {
            this.pressed = pressed;
        }
    }
}
