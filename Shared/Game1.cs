using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphicsDeviceManager;
        public static ContentManager contentManager;

        public static SpriteBatch spriteBatch;

        private static string actualScene = WK.Scene.GameScene;
        private static Dictionary<string, Scene> scenes;

        public Game1()
        {
            // Content
            string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            this.Content.RootDirectory = absolutePath;
            contentManager = this.Content;

            // Window
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = WK.Default.CanvasWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = WK.Default.CanvasHeight;
            graphicsDeviceManager.ApplyChanges();

            spriteBatch = new SpriteBatch(GraphicsDevice);

            // FPS
            this.IsFixedTimeStep = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1d / WK.Default.FPS);

            // Scenes
            scenes = new Dictionary<string, Scene>()
            {
                {WK.Scene.GameScene, new GameScene() },
                {WK.Scene.House_1, new House_1() },
                {WK.Scene.Cave, new Cave() }
            };
            scenes[actualScene].Initialize(new Point(10, 15));

            base.Initialize();

        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Code
            if (true) this.IsMouseVisible = true;

            SceneHelper.Update(scenes[actualScene]);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SceneHelper.Draw(spriteBatch, scenes[actualScene]);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public static void ChangeScene(string targetScene, Point targetPlayerPosition)
        {
            actualScene = targetScene;
            scenes[actualScene].Initialize(targetPlayerPosition);
        }
    }
}