using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using IrisEngine;

namespace Jelly_Monster
{
    public class ScoreScene : IScene
    {
        PlayerData player_data;
        PlayerSaveData player_save;
        GameData score_data;
        string level_path;
        byte id;
        byte score;
        byte muffin_count;
        bool endgame;

        public ScoreScene(PlayerData player_data, PlayerSaveData player_save, GameData score_data, string level_path, byte muffin_count)
        {
            this.endgame = false;
            this.player_data = player_data;
            this.player_save = player_save;
            //this.score_data = score_data;

            this.level_path = level_path;
            this.id = player_data.current_id;
            this.muffin_count = muffin_count;

            if (score_data.won)
            {
                this.score = (byte)score_data.score;

                float percent = ((float)score_data.score / (float)muffin_count) * 100f;
                byte bprc = (byte)percent;

                if (this.player_save.scores[player_data.current_id] < bprc)
                    this.player_save.scores[player_data.current_id] = bprc;
            }
            //if(this.player_save.scores[player_data.current_id] < score_data.score)
            //    this.player_save.scores[player_data.current_id] = (byte)(((float)score_data.score / (float)muffin_count) * 100f);

            if (score_data.won)
            {
                SoundManager.PlayOnScore();

                if (this.player_save.scores.Count - 1 == this.player_data.current_id)// + this.player_data.world_id * 21)
                {
                    if (this.player_save.scores.Count < 21 * 6)
                    {
                        this.player_save.scores.Add(0);
                        this.player_data.current_id++;
                    }
                    else
                    {
                        endgame = true;
                    }
                }
            }

            IsPopup = true;
            TransitionTime = 0.2f;

            Save.SaveFile(player_save, "jelly_save.dat");
        }

        public override void Load()
        {
            Page = SceneManager.GUI.AddPage();

            ButtonNamed b_continue = Page.AddButton(new Rectangle(600, 110, 200, 100), EORIENTATION.Top, "Continue", 0);

            if (!endgame)
            {
                ButtonNamed b_replay = Page.AddButton(new Rectangle(600, 230, 200, 100), EORIENTATION.Bottom, "Replay", 0);
                ButtonNamed b_menu = Page.AddButton(new Rectangle(600, 350, 200, 100), EORIENTATION.Bottom, "Menu", 0);

                b_replay.Event += OnReplay;
                b_menu.Event += OnMenu;
            }

            Page.AddMsgBox(Fonts.FontScore, new Rectangle(150, 90, 300, 300), EORIENTATION.Top, ""
                + "\n    Score: \n" + "    " + score + " / " + muffin_count);
                //+ "\n    / " 
                //+ "\n" + muffin_count
                //);

            b_continue.Event += OnContinue;
        }

        public override void Unload()
        {
            base.Unload();
        }

        public override void Draw(SpriteBatch sp)
        {
            SceneManager.FadeBackBufferToBlack(TimeAlpha * 0.4f);

            base.Draw(sp);
        }

        public override void Update(float dt, bool has_focus, bool covered_by_other)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                if (!BackButton.pressed)
                {
                    BackButton.pressed = true;

                    if (endgame)
                    {
                        endgame = false;
                        this.SceneManager.AddScene(new EndGameScene());
                    }
                    else
                    {
                        SoundManager.PlayOnClick();
                        LoadingScene.Load(SceneManager, true, new MainBackgroundScene(), new MainMenuScene(player_data, player_save));
                    }
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
            if (endgame)
            {
                //ExitScene();
                endgame = false;
                this.SceneManager.AddScene(new EndGameScene());
                return;
            }

            if (state == TouchLocationState.Pressed)
            {
                SoundManager.PlayOnClick();

                switch(player_data.world_id)
                {
                    case 0:
                        LoadingScene.Load(SceneManager, true, new WorldBackgroundScene(), new WorldSceneOne(player_data, player_save));
                        break;
                    case 1:
                        LoadingScene.Load(SceneManager, true, new WorldBackgroundScene(), new WorldSceneTwo(player_data, player_save));
                        break;
                    case 2:
                        LoadingScene.Load(SceneManager, true, new WorldBackgroundScene(), new WorldSceneThree(player_data, player_save));
                        break;
                    case 3:
                        LoadingScene.Load(SceneManager, true, new WorldBackgroundScene(), new WorldSceneFour(player_data, player_save));
                        break;
                    case 4:
                        LoadingScene.Load(SceneManager, true, new WorldBackgroundScene(), new WorldSceneFive(player_data, player_save));
                        break;
                    case 5:
                        LoadingScene.Load(SceneManager, true, new WorldBackgroundScene(), new WorldSceneSix(player_data, player_save));
                        break;
                }
            }
        }

        public void OnReplay(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed)
            {
                SoundManager.PlayOnClick();
                LoadingScene.Load(SceneManager, true, new GameScene(player_data, player_save, level_path));   
            }
        }

        public void OnMenu(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Released)
            {
                SoundManager.PlayOnClick();
                //Save.SaveFile(player_save, "jelly_save.dat");
                LoadingScene.Load(SceneManager, true, new MainBackgroundScene(), new MainMenuScene(player_data, player_save));
            }
        }
    }
}
