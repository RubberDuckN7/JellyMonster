using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using IrisEngine;

namespace Jelly_Monster
{
    public class EndGameScene : IScene
    {
        public EndGameScene()
        {
            IsPopup = true;
            TransitionTime = 0.2f;
        }

        public override void Load()
        {
            Page = SceneManager.GUI.AddPage();

            RScaledResources resources = new RScaledResources();
            resources.background = SceneManager.GUI.ResourcesContainer.background.background;
            resources.border_horizontal = SceneManager.GUI.ResourcesRScaled.border_horizontal;
            resources.border_vertical = SceneManager.GUI.ResourcesRScaled.border_vertical;
            resources.corner_bl = SceneManager.GUI.ResourcesRScaled.corner_bl;
            resources.corner_br = SceneManager.GUI.ResourcesRScaled.corner_br;
            resources.corner_tl = SceneManager.GUI.ResourcesRScaled.corner_tl;
            resources.corner_tr = SceneManager.GUI.ResourcesRScaled.corner_tr;

            ButtonNamed b_continue = Page.AddButton(new Rectangle(600, 230, 200, 100), EORIENTATION.Top, "Continue", 0);

            Page.AddMsgBox(resources, Fonts.FontMessage, new Rectangle(200, 40, 400, 200), EORIENTATION.Bottom, ""
                + "   Congratulations on \n   winning the game!\n"
                + "   For your all hard work \n   to get to this level\n"
                + "   you deserve a cookie. \n   *Hands over a air cookie*\n"
               // + "\n"
               // + "Feel free to drop a comment \n   about this game, and share your thoughts."
               // + "\n   - Dev"
            );

            Page.AddMsgBox(resources, Fonts.FontMessage, new Rectangle(200, 260, 400, 170), EORIENTATION.Bottom, ""
                + "   Your feedback matters! :O"
                + "\n   Feel free to leave a comment and \n   rate the game to improve it."
               // + "\n    - Dev"
            );

            b_continue.Event += OnContinue;
        }

        public override void Unload()
        {
            base.Unload();
        }

        public override void Draw(SpriteBatch sp)
        {
            sp.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            //Color color = Color.Gray;
            //color.B = 40;
            //color.A = 230;

            //sp.Draw(SceneManager.BlankTexture, SceneManager.Game.GraphicsDevice.Viewport.Bounds, color);

            sp.End();

            SceneManager.FadeBackBufferToBlack(TimeAlpha * 0.7f);

            base.Draw(sp);
        }

        public override void Update(float dt, bool has_focus, bool covered_by_other)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                if (!BackButton.pressed)
                {
                    BackButton.pressed = true;
                    ExitScene();
                }
            }
            else
                BackButton.pressed = false;

            base.Update(dt, has_focus, covered_by_other);
        }

        public override void HandleInput(TouchCollection touches, float dt)
        {

        }

        public void OnContinue(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed)
            {
                SoundManager.PlayOnClick();
                ExitScene();
            }
        }
    }
}
