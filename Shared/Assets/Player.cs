using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
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

        public void Update(Map map)
        {
            MovePlayer(map);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }

        private void MovePlayer(Map map)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
            {
                if (GetCollideDirection(map, rectangle, CharacterDirecction.Up) == CharacterDirecction.Up) return;

                rectangle.Y -= 1;
            }
            else if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
            {
                if (GetCollideDirection(map, rectangle, CharacterDirecction.Down) == CharacterDirecction.Down) return;

                rectangle.Y += 1;
            }
            else if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                if (GetCollideDirection(map, rectangle, CharacterDirecction.Right) == CharacterDirecction.Right) return;

                rectangle.X += 1;
            }
            else if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
            {
                if (GetCollideDirection(map, rectangle, CharacterDirecction.Left) == CharacterDirecction.Left) return;

                rectangle.X -= 1;
            }
        }


        private CharacterDirecction GetCollideDirection(Map map, Rectangle playerRectangle, CharacterDirecction MoveDirection)
        {
            Rectangle futurePlayerRectangle = rectangle;

            if (MoveDirection == CharacterDirecction.Right)
            {
                futurePlayerRectangle.X++;

                bool collisionDetected = GetIfWillIntersects(map, "x", futurePlayerRectangle);

                if (collisionDetected) return CharacterDirecction.Right;
            }
            else if (MoveDirection == CharacterDirecction.Left)
            {
                futurePlayerRectangle.X--;

                bool collisionDetected = GetIfWillIntersects(map, "x", futurePlayerRectangle);

                if (collisionDetected) return CharacterDirecction.Left;
            }
            else if (MoveDirection == CharacterDirecction.Up)
            {
                futurePlayerRectangle.Y--;

                bool collisionDetected = GetIfWillIntersects(map, "x", futurePlayerRectangle);

                if (collisionDetected) return CharacterDirecction.Up;
            }
            else if (MoveDirection == CharacterDirecction.Down)
            {
                futurePlayerRectangle.Y++;

                bool collisionDetected = GetIfWillIntersects(map, "x", futurePlayerRectangle);

                if (collisionDetected) return CharacterDirecction.Down;
            }

            return CharacterDirecction._null;
        }

        private bool GetIfWillIntersects(Map map, string tag, Rectangle futurePlayerRectangle)
        {
            return map.map
                        .Where(x => x.tag == tag)
                        .Select(x => x.rectangle.Intersects(futurePlayerRectangle))
                        .Contains(true);
        }
    }

    public enum CharacterDirecction
    {
        Up,
        Down,
        Right,
        Left,
        _null
    }
}
