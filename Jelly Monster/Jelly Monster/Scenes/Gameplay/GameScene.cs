using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using IrisEngine;
using ContentData;

//////////////////////////////////////////////////////////////////////////////////
// TODO:
//   1: Rewrite the whole damn thing ( .__.)     :  High  : Done
//   2: Refine killed state, and exiting state   :  Low   : Done
//   3: Add enemies for first world              :  High  : Done
//   4: Add resources for whole first world      :  High  : Done
//   5: Add score scene and replayability        :  High  : Done
//   6: Add confirm exit/restart/continue scene  :  High  :
//   7: Add basic sounds                         :  Low   : Done
//   8: Add different fonts                      :  Low   : Done
//   9: Add xml world loading                    :  High  : Done
//
//   ---------------------------------------------------------------------------
//   A:
// 
//
//////////////////////////////////////////////////////////////////////////////////

namespace Jelly_Monster
{
    public class GameScene : IScene
    {
        ContentManager content;
        Level level;
        JellyPlayer player;

        Color background_color;

        string level_path;

        Texture2D bounding_texture;

        PlayerData player_data;
        PlayerSaveData player_save;
        GameData score_data;

        MsgCounter life_counter;

        float exiting_time;
        bool exiting;
        bool immortal;
        bool exited;
        bool paused;

        public GameScene(PlayerData player_data, PlayerSaveData player_save, string level_path)
        {
            this.player_data = player_data;
            this.player_save = player_save;

            this.content = null;
            this.level = new Level(this);
            this.player = new JellyPlayer(level, 370, 210, 60, 60);
            this.score_data = new GameData();
            this.score_data.life_count = 3;
            this.score_data.score = 0;
            this.score_data.won = false;
            
            this.level_path = level_path;
            this.exiting_time = 0f;
            this.exiting = false;
            this.immortal = false;
            this.exited = false;

            // Real sampled color
            this.background_color = Color.White;

            switch(player_data.world_id)
            {
                case 0:
                    // Lava
                    this.background_color = new Color(217, 114, 0);
                    break;
                case 1:
                    // Underworld
                    this.background_color = new Color(47, 31, 17);
                    break;
                case 2:
                    // Forest
                    this.background_color = new Color(33, 166, 253);
                    break;
                case 3:
                    // Scary
                    this.background_color = new Color(36, 36, 94);
                    break;
                case 4:
                    // Industrial
                    this.background_color = new Color(26, 26, 37);
                    break;
                case 5:
                    // Heaven
                    this.background_color = new Color(79, 119, 228);
                    break;
            }
        }

        public override void Load()
        {
            SoundManager.StartMusic();

            content = new ContentManager(SceneManager.Game.Services, "Content");

            Page = SceneManager.GUI.AddPage();

            ButtonResources br_up = new ButtonResources();
            ButtonResources br_right = new ButtonResources();
            ButtonResources br_left = new ButtonResources();

            br_up.background = content.Load<Texture2D>("Textures/CustomGUI/button_up");
            br_up.pressed = content.Load<Texture2D>("Textures/CustomGUI/button_up");

            br_right.background = content.Load<Texture2D>("Textures/CustomGUI/button_right");
            br_right.pressed = content.Load<Texture2D>("Textures/CustomGUI/button_right");

            br_left.background = content.Load<Texture2D>("Textures/CustomGUI/button_left");
            br_left.pressed = content.Load<Texture2D>("Textures/CustomGUI/button_left");

            br_up.font = Fonts.FontMenu;
            br_right.font = Fonts.FontMenu;
            br_left.font = Fonts.FontMenu;

            Button b_up = Page.AddButton(br_up , new Rectangle(670, 360, 120, 120), EORIENTATION.Left, 0);
            Button b_left = Page.AddButton(br_left, new Rectangle(10, 360, 120, 120), EORIENTATION.Left, 0);
            Button b_right = Page.AddButton(br_right, new Rectangle(150, 360, 120, 120), EORIENTATION.Left, 0);
            //Button b_immortal = Page.AddButton(new Rectangle(700, 0, 100, 100), EORIENTATION.Bottom, 0);

            life_counter = Page.AddMsgCounter(Fonts.FontMessage, new Rectangle(0, 0, 100, 40), EORIENTATION.Top, "");

            b_up.Event += OnUp;
            b_left.Event += OnLeft;
            b_right.Event += OnRight;
            //b_immortal.Event += OnImmortal;

            bounding_texture = content.Load<Texture2D>("Textures/Debug/bounding_texture");

            level.Load(content, level_path);

            player.Load(content);

            life_counter.SetMsg("Life: " + score_data.life_count);
        }

        public override void Unload()
        {
            SoundManager.StopMusic();
            base.Unload();
        }

        public override void Draw(SpriteBatch sp)
        {
            SceneManager.GraphicsDevice.Clear(background_color);


            sp.Begin(SpriteSortMode.FrontToBack,
                  BlendState.AlphaBlend);

            //sp.Draw(SceneManager.LoadingTexture, SceneManager.GraphicsDevice.Viewport.Bounds, Color.DarkGreen);

            level.Draw(sp);
            player.Draw(sp, level.OffsetWorld);

            Rectangle bound = player.Bounds;

            bound.X -= (int)level.OffsetWorld.X;
            bound.Y -= (int)level.OffsetWorld.Y;

            Vector2 offset = level.OffsetWorld;
            //string msg = "Pos X: " + player.Bounds.X + " Y: " + player.Bounds.Y + "\n" +
            //             "Offset X: " + offset.X + " Y: " + offset.Y;

            //string msg = "Life: " + score_data.life_count;

            //sp.DrawString(Fonts.FontMessage, msg, Vector2.Zero, Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            //sp.Draw(bounding_texture, bound, null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 1f);

            //sp.DrawString(Fonts.FontMessage, "Bounds X: " + player.Bounds.X + " Y: " + player.Bounds.Y, new Vector2(100f, 0f), Color.Red);

            sp.End();

            base.Draw(sp);
        }

        public override void Update(float dt, bool has_focus, bool covered_by_other)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                if (!BackButton.pressed)
                {
                    BackButton.pressed = true;
                    SceneManager.AddScene(new ConfirmExitScene(player_data, player_save));
                }
            }
            else
                BackButton.pressed = false;

            if (exiting)
            {
                exiting_time += dt;

                if (exiting_time > 0.3f && exiting_time < 10f)
                {
                    exiting_time = 100f;
                    SceneManager.AddScene(new ScoreScene(player_data, player_save, score_data, level_path, level.CollectableCount));
                    SoundManager.StopMusic();
                }

                //return;
            }

            if (!exited && has_focus)
            {
                player.Falling = true;
                player.Update(dt);

                Vector2 offset = level.OffsetWorld;

                //if (player.Bounds.Y > 400 || player.Bounds.Y < 80)
                {
                    //offset.X = (float)player.Bounds.X - 370f;
                    //offset.Y = (float)player.Bounds.Y - 210f;
                }

                if (player.Bounds.X > 370)
                    offset.X = (float)player.Bounds.X - 370f;

                if (player.Bounds.Y < 210)
                    offset.Y = (float)player.Bounds.Y - 210f;


                level.OffsetWorld = offset;

                if (!player.Respawning)
                    level.Update(dt);

                if (player.Bounds.Y > 480)
                {
                    if (!player.Respawning)
                        KillPlayer();
                }
            }

            base.Update(dt, has_focus, covered_by_other);
        }

        public override void HandleInput(TouchCollection touches, float dt)
        {
            for (byte i = 0; i < touches.Count; i++)
            {
                if (touches[i].State == TouchLocationState.Released)
                {
                    player.StopMoving();
                }
            }
        }

        #region EVENTS

        public void OnUp(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed || state == TouchLocationState.Moved)
            {
                if(!player.Falling)
                    SoundManager.PlayJump();
                player.Jump();
            }
        }

        public void OnLeft(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed || state == TouchLocationState.Moved)
                player.MoveLeft();
            else if (state == TouchLocationState.Released)
                player.StopMoving();
        }

        public void OnRight(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed || state == TouchLocationState.Moved)
                player.MoveRight();
            else if (state == TouchLocationState.Released)
                player.StopMoving();
        }

        public void OnImmortal(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed)
            {
                exiting_time = 0f;
                exiting = true;
                score_data.won = true;
            }
                //this.immortal = !this.immortal;
        }

        public void AddScore(byte sc)
        {
            score_data.score += (int)sc;
            SoundManager.PlayOnCollect();
        }

        public void KillPlayer()
        {
            //if (immortal)
            //    return;

            //player.Kill();
            //return;
            SoundManager.PlayOnDeath();

            if (score_data.life_count == 0)
            {
                score_data.won = false;
                exiting = true;
                exiting_time = 0f;
                exited = true;
            }
            else
            {
                player.Kill();
                score_data.life_count -= 1;
                life_counter.SetMsg("Life: " + score_data.life_count);
            }
        }

        public void OnJumpEvent(string type, float data)
        {
            player.Jump(data);
        }

        public void OnExitEvent(string type, float data)
        {

        }

        #endregion

        #region TRIGGERS

        public void TriggerJump(float data, byte id)
        {
            player.Jump(data);
        }

        public void TriggerExit(float data, byte id)
        {
            exiting_time = 0f;
            exiting = true;
            score_data.won = true;
        }

        #endregion

        #region GET FUNCTIONS

        public JellyPlayer JPlayer
        {
            get { return player; }
            set { player = value; }
        }

        public Texture2D BoundingTexture
        {
            get { return bounding_texture; }
        }

        #endregion
    }
}
