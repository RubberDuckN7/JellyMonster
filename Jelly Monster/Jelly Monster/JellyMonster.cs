using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

using Microsoft.Advertising.Mobile.Xna;
using System.Diagnostics;
using System.Device.Location;

using ContentData;
using IrisEngine;

namespace Jelly_Monster
{
    public class JellyMonster : Microsoft.Xna.Framework.Game
    {
        //private static readonly string ApplicationId = "test_client";
        private static readonly string ApplicationId = "746db211-e3f8-4eb2-a698-59937d471eb7";
        private static readonly string AdUnitId = "10712139";
        //private static readonly string AdUnitId = "Image480_80"; //other test values: Image480_80, Image300_50, TextAd

        GraphicsDeviceManager graphics;
        SceneManager scene_manager;

        DrawableAd bannerAd;

        // We will use this to find the device location for better ad targeting.
        private GeoCoordinateWatcher gcw = null;

        public JellyMonster()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            TargetElapsedTime = TimeSpan.FromTicks(333333);
            graphics.PreferredBackBufferWidth = 800; 
            graphics.PreferredBackBufferHeight = 480;

            InactiveSleepTime = TimeSpan.FromSeconds(1);

            scene_manager = new SceneManager(this, "XML/Manager/DebugManager");
            Components.Add(scene_manager);

            SoundManager.Volume = 1f;
            SoundManager.SoundOff = false;
            SoundManager.MusicOff = false;
            BackButton.pressed = false;
        }

        protected override void Initialize()
        {
            AdGameComponent.Initialize(this, ApplicationId);
            Components.Add(AdGameComponent.Current);

            // Now create an actual ad for display.
            CreateAd();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Fonts.LoadContent(Content);
            SoundManager.LoadContent(Content);
            scene_manager.SetFontButtons(Fonts.FontMenu);
            LoadingScene.Load(scene_manager, true, new MainBackgroundScene(), new MainMenuScene());
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }

        /// <summary>
        /// Create a DrawableAd with desired properties.
        /// </summary>
        private void CreateAd()
        {
            // Create a banner ad for the game.
            int width = 480;
            int height = 80;
            int x = (GraphicsDevice.Viewport.Bounds.Width - width) / 2; // centered on the display
            int y = 5;

            bannerAd = AdGameComponent.Current.CreateAd(AdUnitId, new Rectangle(x, y, width, height), true);

            // Add handlers for events (optional).
            bannerAd.ErrorOccurred += new EventHandler<Microsoft.Advertising.AdErrorEventArgs>(bannerAd_ErrorOccurred);
            bannerAd.AdRefreshed += new EventHandler(bannerAd_AdRefreshed);

            // Set some visual properties (optional).
            //bannerAd.BorderEnabled = true; // default is true
            //bannerAd.BorderColor = Color.White; // default is White
            //bannerAd.DropShadowEnabled = true; // default is true

            // Provide the location to the ad for better targeting (optional).
            // This is done by starting a GeoCoordinateWatcher and waiting for the location to be available.
            // The callback will set the location into the ad. 
            // Note: The location may not be available in time for the first ad request.
            AdGameComponent.Current.Enabled = false;
            this.gcw = new GeoCoordinateWatcher();
            this.gcw.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(gcw_PositionChanged);
            this.gcw.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(gcw_StatusChanged);
            this.gcw.Start();
        }

        /// <summary>
        /// This is called whenever a new ad is received by the ad client.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bannerAd_AdRefreshed(object sender, EventArgs e)
        {
            Debug.WriteLine("Ad received successfully");
        }

        /// <summary>
        /// This is called when an error occurs during the retrieval of an ad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Contains the Error that occurred.</param>
        private void bannerAd_ErrorOccurred(object sender, Microsoft.Advertising.AdErrorEventArgs e)
        {
            Debug.WriteLine("Ad error: " + e.Error.Message);
        }

        private void gcw_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            // Stop the GeoCoordinateWatcher now that we have the device location.
            this.gcw.Stop();

            bannerAd.LocationLatitude = e.Position.Location.Latitude;
            bannerAd.LocationLongitude = e.Position.Location.Longitude;

            AdGameComponent.Current.Enabled = true;

            Debug.WriteLine("Device lat/long: " + e.Position.Location.Latitude + ", " + e.Position.Location.Longitude);
        }

        private void gcw_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Disabled || e.Status == GeoPositionStatus.NoData)
            {
                // in the case that location services are not enabled or there is no data
                // enable ads anyway
                AdGameComponent.Current.Enabled = true;
                Debug.WriteLine("GeoCoordinateWatcher Status :" + e.Status);
            }
        }

        /// <summary>
        /// Clean up the GeoCoordinateWatcher
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (this.gcw != null)
                {
                    this.gcw.Dispose();
                    this.gcw = null;
                }
            }
        }
    }
}
