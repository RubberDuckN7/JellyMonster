using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input.Touch;

using IrisEngine;

namespace Jelly_Monster
{
    public class WorldBackgroundScene : IScene
    {
        public WorldBackgroundScene()
        {
        }

        public override void Load()
        {
        }

        public override void Unload()
        {
            base.Unload();
        }

        public override void Draw(SpriteBatch sp)
        {
            sp.Begin(SpriteSortMode.FrontToBack,
                  BlendState.AlphaBlend);

            sp.Draw(SceneManager.BlankTexture, SceneManager.GraphicsDevice.Viewport.Bounds, Color.Black);

            sp.End();

            base.Draw(sp);
        }

        public override void Update(float dt, bool has_focus, bool covered_by_other)
        {
            base.Update(dt, has_focus, covered_by_other);
        }

        public override void HandleInput(TouchCollection touches, float dt)
        {

        }
    }
}
