using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using IrisEngine;

namespace Jelly_Monster
{
    public class OptionScene : IScene
    {
        PlayerSaveData player_save;

        public OptionScene(PlayerSaveData player_save)
        {
            this.player_save = player_save;

            TransitionTime = 0.2f;
            IsPopup = true;
        }

        public override void Load()
        {
            Page = SceneManager.GUI.AddPage();

            Page.AddMsgBox(Fonts.FontMessage, new Rectangle(350, 175, 265, 170), EORIENTATION.Top, "\nMusic Off   Sound Off");

            ButtonNamed b_back = Page.AddButton(new Rectangle(20, 350, 200, 100), EORIENTATION.Top, "Back", 0);

            CheckBox cb_music = Page.AddCheckBox(new Rectangle(404, 270, 50, 50), EORIENTATION.Top, 0);
            CheckBox cb_sound = Page.AddCheckBox(new Rectangle(507, 270, 50, 50), EORIENTATION.Top, 1);

            b_back.Event += OnBack;
            cb_music.Event += OnCheckbox;
            cb_sound.Event += OnCheckbox;

            cb_music.Checked(SoundManager.MusicOff);
            cb_sound.Checked(SoundManager.SoundOff);
        }

        public override void Unload()
        {
            base.Unload();
        }

        public override void Draw(SpriteBatch sp)
        {
            SceneManager.FadeBackBufferToBlack(TimeAlpha * 0.7f);
            base.Draw(sp);
        }

        public override void Update(float dt, bool has_focus, bool covered_by_other)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                if (!BackButton.pressed)
                {
                    SoundManager.PlayOnClick();
                    player_save.music_off = 0;
                    player_save.sound_off = 0;

                    if (SoundManager.MusicOff)
                        player_save.music_off = 1;
                    if (SoundManager.SoundOff)
                        player_save.sound_off = 1;

                    Save.SaveFile(player_save, "jelly_save.dat");
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

        public void OnCheckbox(byte id, bool pressed)
        {
            if (id == 0)
            {
                SoundManager.MusicOff = pressed;
            }
            else if (id == 1)
            {
                SoundManager.SoundOff = pressed;
            }


        }

        public void OnBack(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed)
            {
                player_save.music_off = 0;
                player_save.sound_off = 0;

                if(SoundManager.MusicOff)
                    player_save.music_off = 1;
                if(SoundManager.SoundOff)
                    player_save.sound_off = 1;

                SoundManager.PlayOnClick();
                Save.SaveFile(player_save, "jelly_save.dat");
                ExitScene();
            }
        }
    }
}
