﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Player
    {
        Texture2D texture2D;
        public Rectangle rectangle;

        public Player(Point startPosition)
        {
            texture2D = Tools.CreateColorTexture(Color.Pink);
            rectangle = new Rectangle(startPosition.X, startPosition.Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
        }

        public void Update()
        {
            Vector2 oldPosition = new Vector2(rectangle.X, rectangle.Y);
            Vector2 newPosition = MovePlayer(oldPosition, 2);
            rectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, rectangle.Width, rectangle.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }

        private Vector2 MovePlayer(Vector2 position, int moveSpeed)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
                position.X -= moveSpeed;
            }
            else if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                position.X += moveSpeed;
            }
            else if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
            {
                position.Y -= moveSpeed;
            }
            else if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
            {
                position.Y += moveSpeed;
            }

            return position;
        }
    }
}
