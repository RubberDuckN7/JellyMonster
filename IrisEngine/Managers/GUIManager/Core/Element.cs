using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace IrisEngine
{
    public abstract class IElement
    {
        public virtual void HandleInput(TouchCollection touches, float dt) { }
        public virtual void Draw(SpriteBatch sp, Color color, Vector2 offset) { }
    }
}
