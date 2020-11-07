using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphicsDeviceManager;
        public static ContentManager contentManager;

        SpriteBatch spriteBatch;

        Texture2D texture2D;
        Rectangle rectangle;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: Code
            texture2D = Tools.CreateColorTexture(Color.Pink);
            rectangle = new Rectangle(250, 250, 20, 20);
        }


        protected override void UnloadContent()
        {
            // TODO: Code
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Code

            if (true) this.IsMouseVisible = true;

            Vector2 oldPosition = new Vector2(rectangle.X, rectangle.Y);
            Vector2 newPosition = Tools.MovePlayer(oldPosition, 100, 100, 2);
            rectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, rectangle.Width, rectangle.Height);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // TODO: Code
            spriteBatch.Draw(texture2D, rectangle, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
