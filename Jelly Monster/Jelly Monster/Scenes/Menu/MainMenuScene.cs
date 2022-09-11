using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using Microsoft.Xna.Framework.GamerServices;
using System.IO.IsolatedStorage;

using IrisEngine;

namespace Jelly_Monster
{
    public class MainMenuScene : IScene
    {
        PlayerData player_data;
        PlayerSaveData player_save;

        //Texture2D harrier;

        public MainMenuScene()
        {
            IsPopup = true;
            TransitionTime = 0.2f;

            player_data = null;//new PlayerData();
            player_save = null;// new PlayerSaveData();
        }

        public MainMenuScene(PlayerData player_data, PlayerSaveData player_save)
        {
            IsPopup = true;
            TransitionTime = 0.2f;
            this.player_data = player_data;
            this.player_save = player_save;
        }

        public override void Load()
        {
            Page = SceneManager.GUI.AddPage();

            //harrier = SceneManager.Content.Load<Texture2D>("Textures/harrier_slots");

            //if (player_save == null)
            {
                player_data = new PlayerData();
                player_save = new PlayerSaveData();

                //player_data.trial = Guide.IsTrialMode;
                player_data.trial = false;


                if (Save.FileExist("jelly_save.dat"))
                {
                    player_save = Save.LoadFile("jelly_save.dat");

                    ButtonNamed b_new = Page.AddButton(new Rectangle(590, 360, 200, 100), EORIENTATION.Bottom, "New", 0);
                    b_new.Event += OnNew;
                }
                else
                {
                    player_save.scores.Add(0);

                    Save.SaveFile(player_save, "jelly_save.dat");
                }

                //player_save.scores.Clear();

                //for (byte i = 0; i < 21; i++)
                //    player_save.scores.Add(i);

                if (player_save.music_off == 1)
                    SoundManager.MusicOff = true;
                else
                    SoundManager.MusicOff = false;

                if (player_save.sound_off == 1)
                    SoundManager.SoundOff = true;
                else
                    SoundManager.SoundOff = false;

                // Testing!!!
                //player_save.scores.Clear();

                //for (byte i = 0; i < 21 * 6; i++)
                //    player_save.scores.Add((byte)(i + 2));
            }
                /*if (!player_data.trial)
                {
                    if (Save.FileExist("jelly_save.dat"))
                    {
                        player_save = Save.LoadFile("jelly_save.dat");

                        ButtonNamed b_new = Page.AddButton(new Rectangle(500, 280, 200, 100), EORIENTATION.Bottom, "New", 0);
                        b_new.Event += OnNew;
                    }
                    else
                    {
                        player_save.scores.Add(0);

                        Save.SaveFile(player_save, "jelly_save.dat");
                    }

                    //for (byte i = 0; i < 21 * 6; i++)
                    //    player_save.scores.Add((byte)Utility.Random(0f, 10f));
                }
                else
                {
                    player_save.scores.Add(0);
                }
            }*/

            

            //Page.AddMsgBox(Fonts.FontMenu, new Rectangle(200, 20, 400, 400), EORIENTATION.Top, "");

            ButtonNamed b_play = Page.AddButton(new Rectangle(590, 120, 200, 100), EORIENTATION.Top, "Play", 0);
            ButtonNamed b_exit = Page.AddButton(new Rectangle(590, 240, 200, 100), EORIENTATION.Bottom, "Exit", 0);
            ButtonNamed b_options = Page.AddButton(new Rectangle(20, 350, 200, 100), EORIENTATION.Top, "Options", 0);

            b_play.Event += OnPlay;
            b_exit.Event += OnExit;
            b_options.Event += OnOptions;
        }

        public override void Unload()
        {
            base.Unload();
        }

        public override void Draw(SpriteBatch sp)
        {
            //sp.Begin();

            //sp.Draw(harrier, new Rectangle(400, 0, 400, 480), Color.White);

            //sp.End();

            base.Draw(sp);
        }

        public override void Update(float dt, bool has_focus, bool covered_by_other)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                if (!BackButton.pressed && !covered_by_other)
                {
                    SoundManager.PlayOnClick();
                    Save.SaveFile(player_save, "jelly_save.dat");
                    SceneManager.Game.Exit();
                }
            }
            else
                BackButton.pressed = false;

            base.Update(dt, has_focus, covered_by_other);
        }

        public override void HandleInput(TouchCollection touches, float dt)
        {

        }

        public void OnPlay(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed)
            {
                SoundManager.PlayOnClick();
                LoadingScene.Load(SceneManager, true, new WorldBackgroundScene(), new WorldSceneOne(player_data, player_save));
            }
        }

        public void OnExit(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed)
            {
                SoundManager.PlayOnClick();
                Save.SaveFile(player_save, "jelly_save.dat");
                SceneManager.Game.Exit();
            }
        }

        public void OnNew(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed)
            {
                SoundManager.PlayOnClick();
                SceneManager.AddScene(new ConfirmNewScene(player_data, player_save));
            }
        }

        public void OnOptions(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed)
            {
                SoundManager.PlayOnClick();
                SceneManager.AddScene(new OptionScene(player_save));
            }
        }
    }
}
