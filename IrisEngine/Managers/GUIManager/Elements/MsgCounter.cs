using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IrisEngine
{
    public class MsgCounter : IElement
    {
        Entity entity;
        SpriteFont font;

        Vector2 text_pos;

        string message;

        public MsgCounter(Texture2D texture, SpriteFont font, Rectangle bounds, string message)
        {
            this.entity = new Entity(texture, bounds);
            this.font = font;

            this.message = message;
            this.text_pos = Utility.GetTextPosition(font, entity.Bounds, message);
        }

        public override void Draw(SpriteBatch sp, Color color, Vector2 offset)
        {
            entity.Draw(sp, color, offset);

            float x = text_pos.X, y = text_pos.Y;

            text_pos += offset;

            sp.DrawString(font, message, text_pos, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            text_pos.X = x;
            text_pos.Y = y;
        }

        public void Draw(SpriteBatch sp, Color color)
        {
            entity.Draw(sp);
            sp.DrawString(font, message, text_pos, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }

        public void SetMsg(string msg)
        {
            message = msg;
            this.text_pos = Utility.GetTextPosition(font, entity.Bounds, message);
        }


    }
}
