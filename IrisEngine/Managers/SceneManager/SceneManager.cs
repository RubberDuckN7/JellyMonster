using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Linq;

using ContentData;

namespace IrisEngine
{
    public class SceneManager : DrawableGameComponent
    {
        List<IScene> scenes = new List<IScene>();
        List<IScene> scenes_temp = new List<IScene>();

        GUIManager manager_gui;

        SpriteBatch sprite_batch;
        SpriteFont system_font;
        Texture2D loading_texture;
        Texture2D blank_texture;

        string xml_name;

        public SceneManager(Game game, string xml_name)
            : base(game)
        {
            this.xml_name = xml_name;
        }

        public override void Initialize()
        {
            base.Initialize();

            // Create classes here, if any.
        }

        protected override void LoadContent()
        {
            // Load content belonging to the scene manager.
            ContentManager content = Game.Content;
            sprite_batch = new SpriteBatch(GraphicsDevice);

            SceneManagerData sm_data = content.Load<SceneManagerData>(xml_name);

            loading_texture = content.Load<Texture2D>(sm_data.LoadingTexture);
            system_font = content.Load<SpriteFont>(sm_data.SystemFont);
            blank_texture = content.Load<Texture2D>("Textures/blank");

            manager_gui = new GUIManager();

            manager_gui.Load(Game, sm_data.XmlNameGUI, "");

            foreach (IScene scene in scenes)
            {
                scene.Load();
            }
        }

        protected override void UnloadContent()
        {
            foreach (IScene scene in scenes)
            {
                scene.Unload();
            }
        }

        public override void Update(GameTime gameTime)
        {
            TouchCollection touches = TouchPanel.GetState();
            float dt = gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            scenes_temp.Clear();

            foreach(IScene scene in scenes)
                scenes_temp.Add(scene);

            bool other_has_focus = false;
            bool covered_by_other = false;

            while(scenes_temp.Count > 0)
            {
                IScene scene = scenes_temp[scenes_temp.Count - 1];

                scenes_temp.RemoveAt(scenes_temp.Count - 1);

                // Should be named "has_focus"
                scene.Update(dt, !other_has_focus, covered_by_other);

                if(scene.IsActive)
                {
                    if(!other_has_focus)
                    {
                        scene.HandleInput(touches, dt);

                        // Not all scenes will use page.
                        // Those who use, wont use pages directly for handling input and
                        // transiting away, all this will be handled in IScene, except for 
                        // input, which is here. 
                        // SceneManager will know better which scene is active and which is not.
                        // Can be changed in future.
                        
                        if(scene.Page != null)
                            scene.Page.HandleInput(touches, dt);
                        other_has_focus = true;
                    }

                    if(!scene.IsPopup)
                        covered_by_other = true;
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (IScene scene in scenes)
            {
                if (scene.SceneState == SceneState.Hidden)
                    continue;

                scene.Draw(sprite_batch);
            }
        }

        public void AddScene(IScene scene)
        {
            scene.SceneManager = this;
            scene.IsExiting = false;

            scene.Load();

            scenes.Add(scene);
        }

        public void RemoveScene(IScene scene)
        {
            scene.Unload();

            scenes.Remove(scene);
            scenes_temp.Remove(scene);
        }

        public void SetFontButtons(SpriteFont font)
        {
            manager_gui.ResourcesButton.font = font;
        }

        public IScene[] GetScenes()
        {
            return scenes.ToArray();
        }

        public GUIManager GUI
        {
            get { return manager_gui; }
        }

        public SpriteBatch SpriteBatch
        {
            get { return sprite_batch; }
        }

        public SpriteFont Font
        {
            get { return system_font; }
        }

        public Texture2D LoadingTexture
        {
            get { return loading_texture; }
        }

        public Texture2D BlankTexture
        {
            get { return blank_texture; }
        }

        public ContentManager Content
        {
            get { return Game.Content; }
        }

        public int Width
        {
            get { return Game.GraphicsDevice.Viewport.Bounds.Width; }
        }

        public int Height
        {
            get { return Game.GraphicsDevice.Viewport.Bounds.Height; }
        }

        /// <summary>
        /// Helper draws a translucent black fullscene sprite, used for fading
        /// scenes in and out, and for darkening the background behind popups.
        /// </summary>
        public void FadeBackBufferToBlack(float alpha)
        {
            //sprite_batch.Begin();
            sprite_batch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            sprite_batch.Draw(loading_texture, GraphicsDevice.Viewport.Bounds, Color.Black * alpha);
            sprite_batch.End();
        }

        public void Deactivate()
        {
#if !WINDOWS_PHONE
            return;
#else
            // Save state somehow.
            // Example had "serialization" here.
#endif
        }

        public bool Activate(bool instancePreserved)
        {
#if !WINDOWS_PHONE
            return false;
#else
            return false;
#endif
        }
    }
}
