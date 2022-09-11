using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace IrisEngine
{
    public class ButtonNamed : IElement
    {
        public delegate void Callback(byte id, TouchLocationState state);
        Entity entity;
        ButtonResources resources;
        Vector2 text_pos;
        string name;
        byte id;
        bool pressed;

        public Callback Event;

        public ButtonNamed(ButtonResources resources, Rectangle bounds, string name, byte id)
        {
            this.resources = resources;
            this.text_pos = Utility.GetTextPosition(resources.font, bounds, name);
            this.name = name;
            this.id = id;
            this.pressed = false;

            this.entity = new Entity(resources.background, bounds);
        }

        public override void Draw(SpriteBatch sp, Color color, Vector2 offset)
        {
            entity.Draw(sp, color, offset);

            float x = text_pos.X;
            float y = text_pos.Y;

            text_pos += offset;

            //sp.DrawString(resources.font, name, text_pos, color);
            sp.DrawString(resources.font, name, text_pos, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            text_pos.X = x;
            text_pos.Y = y;

            if (pressed)
            {
                x = (float)entity.X;
                y = (float)entity.Y;

                Rectangle b = entity.Bounds;
                b.X += (int)offset.X;
                b.Y += (int)offset.Y;

                sp.Draw(resources.pressed, b, color);

                entity.X = (int)x;
                entity.Y = (int)y;
            }
        }

        public void Draw(SpriteBatch sp, Color color)
        {
            entity.Draw(sp);
            sp.DrawString(resources.font, name, text_pos, color);
            if (pressed)
                sp.Draw(resources.pressed, entity.Bounds, color);
        }

        public override void HandleInput(TouchCollection touches, float dt)
        {
            pressed = false;
            for (byte i = 0; i < touches.Count; i++)
            {
                Vector2 point = touches[i].Position;

                if (Utility.PointVsRectangle(point, entity.Bounds))
                {
                    Event(id, touches[i].State);

                    if (touches[i].State == TouchLocationState.Pressed || touches[i].State == TouchLocationState.Moved)
                        pressed = true;
                }
            }
        }


    }
}
