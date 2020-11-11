using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Shared
{
    public class Player
    {
        Texture2D texture_IdleUp;
        Texture2D texture_IdleDown;
        Texture2D texture_IdleRight;
        Texture2D texture_IdleLeft;
        Texture2D texture_WalkUp;
        Texture2D texture_WalkDown;
        Texture2D texture_WalkRight;
        Texture2D texture_WalkLeft;

        PlayerState playerState = PlayerState.IdleDown;

        public Rectangle rectangle;
        CharacterDirecction characterDirecction = CharacterDirecction._null;

        public Player(Point startPosition)
        {
            this.texture_IdleUp = Tools.GetTexture(WK.Content.Texture.Player.Idle_Up);
            this.texture_IdleDown = Tools.GetTexture(WK.Content.Texture.Player.Idle_Down);
            this.texture_IdleRight = Tools.GetTexture(WK.Content.Texture.Player.Idle_Right);
            this.texture_IdleLeft = Tools.GetTexture(WK.Content.Texture.Player.Idle_Left);
            this.texture_WalkUp = Tools.GetTexture(WK.Content.Texture.Player.Walk_Up);
            this.texture_WalkDown = Tools.GetTexture(WK.Content.Texture.Player.Walk_Down);
            this.texture_WalkRight = Tools.GetTexture(WK.Content.Texture.Player.Walk_Right);
            this.texture_WalkLeft = Tools.GetTexture(WK.Content.Texture.Player.Walk_Left);

            rectangle = new Rectangle(startPosition.X, startPosition.Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
        }

        public void Update(Map map)
        {
            MovePlayer(map);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (playerState)
            {
                case PlayerState.IdleUp:
                    spriteBatch.Draw(texture_IdleUp, rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                case PlayerState.IdleDown:
                    spriteBatch.Draw(texture_IdleDown, rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                case PlayerState.IdleRight:
                    spriteBatch.Draw(texture_IdleRight, rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                case PlayerState.IdleLeft:
                    spriteBatch.Draw(texture_IdleLeft, rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                case PlayerState.WalkUp:
                    spriteBatch.Draw(texture_WalkUp, rectangle, Color.White);
                    break;
                case PlayerState.WalkDown:
                    spriteBatch.Draw(texture_WalkDown, rectangle, Color.White);
                    break;
                case PlayerState.WalkRight:
                    spriteBatch.Draw(texture_WalkRight, rectangle, Color.White);
                    break;
                case PlayerState.WalkLeft:
                    spriteBatch.Draw(texture_WalkLeft, rectangle, Color.White);
                    break;
                default:
                    break;
            }
            
        }

        private void MovePlayer(Map map)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up) || characterDirecction == CharacterDirecction.Up)
            {
                playerState = PlayerState.IdleUp;

                if (GetCollideDirection(map, rectangle, CharacterDirecction.Up) == CharacterDirecction.Up) return;

                rectangle.Y -= 1;

                // move until player until alligne with tile
                if (rectangle.Y % WK.Default.Pixels_Y != 0)
                    characterDirecction = CharacterDirecction.Up;
                else
                    characterDirecction = CharacterDirecction._null;

            }
            else if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down) || characterDirecction == CharacterDirecction.Down)
            {
                playerState = PlayerState.IdleDown;

                if (GetCollideDirection(map, rectangle, CharacterDirecction.Down) == CharacterDirecction.Down) return;

                rectangle.Y += 1;

                // move until player until alligne with tile
                if (rectangle.Y % WK.Default.Pixels_Y != 0)
                    characterDirecction = CharacterDirecction.Down;
                else
                    characterDirecction = CharacterDirecction._null;

            }
            else if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right) || characterDirecction == CharacterDirecction.Right)
            {
                playerState = PlayerState.IdleRight;

                if (GetCollideDirection(map, rectangle, CharacterDirecction.Right) == CharacterDirecction.Right) return;

                rectangle.X += 1;

                // move until player until alligne with tile
                if (rectangle.X % WK.Default.Pixels_X != 0)
                    characterDirecction = CharacterDirecction.Right;
                else
                    characterDirecction = CharacterDirecction._null;

            }
            else if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left) || characterDirecction == CharacterDirecction.Left)
            {
                playerState = PlayerState.IdleLeft;

                if (GetCollideDirection(map, rectangle, CharacterDirecction.Left) == CharacterDirecction.Left) return;

                rectangle.X -= 1;

                // move until player until alligne with tile
                if (rectangle.X % WK.Default.Pixels_X != 0)
                    characterDirecction = CharacterDirecction.Left;
                else
                    characterDirecction = CharacterDirecction._null;

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

    public enum PlayerState
    {
        IdleUp,
        IdleDown,
        IdleRight,
        IdleLeft,
        WalkUp,
        WalkDown,
        WalkRight,
        WalkLeft
    }
}
