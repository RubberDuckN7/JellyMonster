using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using Microsoft.Xna.Framework.GamerServices;

using IrisEngine;
using ContentData;

namespace Jelly_Monster
{
    public class WorldSceneSix : IScene
    {
        ContentManager content;
        Texture2D background;
        Texture2D locked;
        Texture2D mission;

        Container missions;
        PlayerData player_data;
        PlayerSaveData player_save;
        MapData levels;
        byte level_id;

        public WorldSceneSix(PlayerData player_data, PlayerSaveData player_save)
        {
            this.player_data = player_data;
            this.player_save = player_save;
            this.level_id = 254;

            this.player_data.world_id = 5;

            IsPopup = false;
            TransitionTime = 0.4f;
        }

        public override void Load()
        {
            content = new ContentManager(SceneManager.Game.Services, "Content");
            background = content.Load<Texture2D>("Textures/background_heaven");
            locked = content.Load<Texture2D>("Textures/locked");
            mission = content.Load<Texture2D>("Textures/mission");

            Page = SceneManager.GUI.AddPage();

            ContainerResources resources = new ContainerResources();

            levels = SceneManager.Content.Load<MapData>("XML/Worlds/MapSix");

            missions = Page.AddContainer(EORIENTATION.Left, 65, 25, 7, 3, 25f, 25f, 25f, 25f, 60f, 25f);
            missions.Event += OnMissions;

            for (byte i = 0; i < 21; i++)
            {
                if (player_save.scores.Count > i + 105)
                {
                    if (!player_data.trial)
                        missions.AddItem(mission, i);
                    else
                    {
                        // Add Locked
                        missions.AddItem(locked, i);
                    }
                }
                else
                {
                    missions.AddItem(locked, 254);
                }
            }

            if (player_data.trial)
            {
                //Page.AddMsgBox(Fonts.FontMessage, new Rectangle(300, 140, 200, 200), EORIENTATION.Left, "Buy full game :3");
            }

            ButtonNamed b_back = Page.AddButton(new Rectangle(0, 380, 200, 100), EORIENTATION.Bottom, "Back", 0);
            ButtonNamed b_play;

            if (!player_data.trial)
                b_play = Page.AddButton(new Rectangle(300, 380, 200, 100), EORIENTATION.Bottom, "Play", 0);
            else
                b_play = Page.AddButton(new Rectangle(300, 380, 200, 100), EORIENTATION.Bottom, "Buy Full game", 0);

            b_back.Event += OnBack;
            b_play.Event += OnPlay;

            Save.SaveFile(player_save, "jelly_save.dat");
        }

        public override void Unload()
        {
            content.Unload();
            base.Unload();
        }

        public override void Draw(SpriteBatch sp)
        {
            sp.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            sp.Draw(background, SceneManager.Game.GraphicsDevice.Viewport.Bounds, Color.White);

            //sp.DrawString(Fonts.FontMenu, "World six", Vector2.Zero, Color.Red);

            sp.End();

            base.Draw(sp);

            sp.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            Container.Item[] items = missions.GetRawItems;

            Vector2 p = new Vector2();

            if (SceneState == IrisEngine.SceneState.Active && player_data.world_id == 5)
            {
                for (byte i = 0; i < items.Length; i++)
                {
                    if (items[i].id < 200 && i + player_data.world_id * 21 < player_save.scores.Count)
                    {
                        p.X = items[i].pos.X + missions.TileSize * 0.13f;
                        p.Y = items[i].pos.Y + missions.TileSize * 0.2f;
                        if (player_save.scores[items[i].id + player_data.world_id * 21] == 0)
                            p.X += missions.TileSize * 0.2f;
                        sp.DrawString(Fonts.FontMessage, "" + player_save.scores[items[i].id + player_data.world_id * 21], p, Color.Gold, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
                    }
                }
            }

            sp.End();
        }

        public override void Update(float dt, bool has_focus, bool covered_by_other)
        {
            this.player_data.world_id = 5;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                if (!BackButton.pressed)
                {
                    SoundManager.PlayOnClick();
                    ExitScene();
                    SceneManager.AddScene(new WorldSceneFive(player_data, player_save));
                }
            }
            else
                BackButton.pressed = false;

            base.Update(dt, has_focus, covered_by_other);
        }

        public override void HandleInput(TouchCollection touches, float dt)
        {

        }

        public void OnBack(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed)
            {
                SoundManager.PlayOnClick();
                ExitScene();
                SceneManager.AddScene(new WorldSceneFive(player_data, player_save));
                //LoadingScene.Load(SceneManager, true, new MainBackgroundScene(), new MainMenuScene());
            }
        }

        public void OnCancel(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed)
            {
                SoundManager.PlayOnClick();
                //ExitScene();
                //SceneManager.AddScene(new WorldSceneOne());
            }
        }

        public void OnPlay(byte id, TouchLocationState state)
        {
            if (state == TouchLocationState.Pressed)
            {
                SoundManager.PlayOnClick();
                if (level_id != 255 && !player_data.trial && level_id != 254)
                    LoadingScene.Load(SceneManager, true, new GameScene(player_data, player_save, levels.Levels[level_id]));

                if (player_data.trial)
                    Guide.ShowMarketplace(PlayerIndex.One);
            }
        }

        public void OnMissions(byte id, TouchLocationState state)
        {
            this.player_data.current_id = this.level_id = id;
            this.player_data.current_id += (byte)(player_data.world_id * 21);

            SoundManager.PlayOnClick();

            /*if (id != 255 && id != 254)
            {
                this.player_data.current_id = id;
                this.level_id = id;
            }
            else
            {
                this.player_data.current_id = 255;
                this.level_id = 255;
            }*/
        }
    }
}
