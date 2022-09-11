using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace IrisEngine
{
    public class Button : IElement
    {
        public delegate void Callback(byte id, TouchLocationState state);
        Entity entity;
        ButtonResources resources;
        byte id;
        bool pressed;

        public Callback Event;

        public Button(ButtonResources resources, Rectangle bounds, byte id)
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

                sp.Draw(resources.pressed, b, color);

                entity.X = x;
                entity.Y = y;
            }
        }

        public void Draw(SpriteBatch sp, Color color)
        {
            entity.Draw(sp);
            if (pressed)
                sp.Draw(resources.pressed, entity.Bounds, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0.5f);
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
