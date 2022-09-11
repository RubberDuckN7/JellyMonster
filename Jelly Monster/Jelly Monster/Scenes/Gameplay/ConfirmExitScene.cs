using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using IrisEngine;

namespace Jelly_Monster
{
    public class ConfirmExitScene : IScene
    {
        PlayerData player_data;
        PlayerSaveData player_save;

        public ConfirmExitScene(PlayerData player_data, PlayerSaveData player_save)
        {
            this.player_data = player_data;
            this.player_save = player_save;

            IsPopup = true;
            TransitionTime = 0.2f;
        }

        public override void Load()
        {
            Page = SceneManager.GUI.AddPage();

            ButtonNamed b_continue = Page.AddButton(new Rectangle(410, 190, 200, 100), EORIENTATION.Right, "Continue", 0);
            ButtonNamed b_menu = Page.AddButton(new Rectangle(190, 190, 200, 100), EORIENTATION.Left, "Menu", 0);

            b_continue.Event += OnContinue;
            b_menu.Event += OnMenu;
        }

        public override void Unload()
        {
            base.Unload();
        }

        public override void Draw(SpriteBatch sp)
        {
            SceneManager.FadeBackBufferToBlack(TimeAlpha * 0.6f);

            base.Draw(sp);
        }

        public override void Update(float dt, bool has_focus, bool covered_by_other)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                if (!BackButton.pressed)
                {
                    BackButton.pressed = true;
                    SoundManager.PlayOnClick();
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

        public void OnMenu(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed)
            {
                Save.SaveFile(player_save, "jelly_save.dat");
                SoundManager.PlayOnClick();
                LoadingScene.Load(SceneManager, true, new MainBackgroundScene(), new MainMenuScene(player_data, player_save));
            }
        }
    }
}
