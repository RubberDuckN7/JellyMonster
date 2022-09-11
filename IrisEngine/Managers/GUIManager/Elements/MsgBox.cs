using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/////////////////////////////////////////////////////////////////////////////////////////
// * Message should start from the top
// * Try to clip message automatically, so it will be easier adding message boxes
//
/////////////////////////////////////////////////////////////////////////////////////////

namespace IrisEngine
{
    public class MsgBox : IElement
    {
        EntityScaled entity;
        SpriteFont font;

        Vector2 text_pos;

        string message;

        public MsgBox(RScaledResources resources, SpriteFont font, float x, float y, float c_w, float c_h, float b_w, float b_h, string message)
        {
            this.message = message;
            this.font = font;

            Vector2 msg_size = font.MeasureString(message);

            int width = (int)(c_w * 2.0f + msg_size.X),
                height = (int)(c_h * 2.0f + msg_size.Y);
            Rectangle bounds = new Rectangle((int)x, (int)y, width, height);

            entity = new EntityScaled(resources, bounds, c_w, c_h, b_w, b_h);

            text_pos = new Vector2((float)(bounds.X + b_w + 3.0f), (float)(bounds.Y + b_h + 3.0f));
        }

        public MsgBox(RScaledResources resources, SpriteFont font, Rectangle bounds, float c_w, float c_h, float b_w, float b_h, string message)
        {
            this.font = font;
            entity = new EntityScaled(resources, bounds, c_w, c_h, b_w, b_h);
            this.message = message;
            
            float offset = 1.2f;
            text_pos = new Vector2((float)(bounds.X + b_w + offset), (float)(bounds.Y + b_h + offset));
        }

        public MsgBox(EntityScaled entity, SpriteFont font, string message)
        {
            this.entity = entity;
            this.font = font;
            this.message = message;

            text_pos = Utility.GetTextPosition(font, entity.Bounds, message);
        }

        public override void Draw(SpriteBatch sp, Color color, Vector2 offset)
        {
            entity.Draw(sp, color, offset);

            float x = text_pos.X, y = text_pos.Y;

            text_pos += offset;

            color = Color.Black;
            sp.DrawString(font, message, text_pos, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            text_pos.X = x;
            text_pos.Y = y;
        }

        public void Draw(SpriteBatch sp, Color color)
        {
            entity.Draw(sp);

            color = Color.Black;
            sp.DrawString(font, message, text_pos, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }

        public void SetFont(SpriteFont font)
        {
            this.font = font;

            text_pos = Utility.GetTextPosition(font, entity.Bounds, message);
        }

        public void SetMsg(string msg)
        {
            message = msg;

            float offset = 1.2f;
            text_pos = new Vector2((float)(entity.Bounds.X + entity.BorderW + offset), (float)(entity.Bounds.Y + entity.BorderH + offset));

            //text_pos = Utility.GetTextPosition(font, entity.Bounds, message);
        }

        public void AddMsg(string msg)
        {
            message += msg;

            float offset = 1.2f;
            text_pos = new Vector2((float)(entity.Bounds.X + entity.BorderW + offset), (float)(entity.Bounds.Y + entity.BorderH + offset));

            //text_pos = Utility.GetTextPosition(font, entity.Bounds, message);
        }



    }
}
