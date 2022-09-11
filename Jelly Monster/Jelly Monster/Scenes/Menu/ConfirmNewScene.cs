using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using IrisEngine;

namespace Jelly_Monster
{
    public class ConfirmNewScene : IScene
    {
        PlayerData player_data;
        PlayerSaveData player_save;
        public ConfirmNewScene(PlayerData player_data, PlayerSaveData player_save)
        {
            this.player_data = player_data;
            this.player_save = player_save;

            IsPopup = true;
            TransitionTime = 0.2f;
        }

        public override void Load()
        {
            Page = SceneManager.GUI.AddPage();

            Page.AddMsgBox(Fonts.FontMenu, new Rectangle(200, 20, 400, 400), EORIENTATION.Top, "");

            ButtonNamed b_yes = Page.AddButton(new Rectangle(300, 40, 200, 100), EORIENTATION.Top, "Yes", 0);
            ButtonNamed b_no = Page.AddButton(new Rectangle(300, 160, 200, 100), EORIENTATION.Bottom, "No", 0);

            b_yes.Event += OnYes;
            b_no.Event += OnNo;
        }

        public override void Unload()
        {
            base.Unload();
        }

        public override void Draw(SpriteBatch sp)
        {
            base.Draw(sp);
        }

        public override void Update(float dt, bool has_focus, bool covered_by_other)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                if (!BackButton.pressed)
                {
                    SoundManager.PlayOnClick();
                    ExitScene();
                    BackButton.pressed = true;
                }
            }
            else
                BackButton.pressed = false;

            base.Update(dt, has_focus, covered_by_other);
        }

        public override void HandleInput(TouchCollection touches, float dt)
        {

        }

        public void OnYes(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed)
            {
                SoundManager.PlayOnClick();
                player_save.scores.Clear();
                player_save.scores.Add(0);
                Save.SaveFile(player_save, "jelly_save.dat");

                LoadingScene.Load(SceneManager, true, new WorldBackgroundScene(), new WorldSceneOne(player_data, player_save)); 
            }
        }

        public void OnNo(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed)
            {
                SoundManager.PlayOnClick();
                ExitScene();
            }
        }
    }
}
