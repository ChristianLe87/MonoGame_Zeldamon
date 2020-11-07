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

        SpriteBatch spriteBatch;

        public static string actualScene = WK.Scene.GameScene;
        Dictionary<string, IScene> scenes;

        int canvasWidth = 500;
        int canvasHeight = 500;

        public Game1()
        {
            // Content
            string absolutePath = Path.Combine(Environment.CurrentDirectory, "Content");
            this.Content.RootDirectory = absolutePath;
            contentManager = this.Content;

            // Window
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = canvasWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = canvasHeight;
            graphicsDeviceManager.ApplyChanges();

            this.scenes = new Dictionary<string, IScene>()
            {
                {WK.Scene.GameScene, new GameScene() }
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: Code
        }


        protected override void UnloadContent()
        {
            // TODO: Code
        }


        protected override void Update(GameTime gameTime)
        {
            // TODO: Code
            if (true) this.IsMouseVisible = true;

            scenes[actualScene].Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // TODO: Code
            scenes[actualScene].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
