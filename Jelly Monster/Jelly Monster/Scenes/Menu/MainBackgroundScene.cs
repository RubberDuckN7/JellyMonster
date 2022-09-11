using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input.Touch;

using IrisEngine;

namespace Jelly_Monster
{
    public class MainBackgroundScene : IScene
    {
        ContentManager content;
        Texture2D background;

        public MainBackgroundScene()
        {
            this.content = null;
        }

        public override void Load()
        {
            if (content == null)
                content = new ContentManager(SceneManager.Game.Services, "Content");

            background = content.Load<Texture2D>("Textures/background_main");

        }

        public override void Unload()
        {
            content.Unload();
            base.Unload();
        }

        public override void Draw(SpriteBatch sp)
        {
            sp.Begin(SpriteSortMode.FrontToBack,
                  BlendState.AlphaBlend);

            sp.Draw(background, SceneManager.Game.GraphicsDevice.Viewport.Bounds, Color.DarkGray);

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
