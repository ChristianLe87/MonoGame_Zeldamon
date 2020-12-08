using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class PushableHelper
    {
        public static void Update(IScene scene, IPushable pushable)
        {
            Player player = scene.entities.OfType<Player>().First();

            KeyboardState keyboardState = Keyboard.GetState();

            if (player.frontIntesection.Intersects(pushable.rectangle) && keyboardState.IsKeyDown(Keys.M))
            {
                Pushable_MoveDirection moveDirection = player.playerState switch
                {
                    PlayerState.IdleUp => Pushable_MoveDirection.Up,
                    PlayerState.IdleDown => Pushable_MoveDirection.Down,
                    PlayerState.IdleRight => Pushable_MoveDirection.Right,
                    PlayerState.IdleLeft => Pushable_MoveDirection.Left,
                    PlayerState.WalkUp => Pushable_MoveDirection.Up,
                    PlayerState.WalkDown => Pushable_MoveDirection.Down,
                    PlayerState.WalkRight => Pushable_MoveDirection.Right,
                    PlayerState.WalkLeft => Pushable_MoveDirection.Left,
                };

                bool canMovePushable = CanMove(scene, pushable, moveDirection);

                if (canMovePushable == true)
                {
                    pushable.pushable_State = moveDirection;
                }
            }

            MovePushable(pushable);
        }


        public static void Draw(SpriteBatch spriteBatch, IPushable cube)
        {
            spriteBatch.Draw(cube.texture2D, cube.rectangle, Color.White);
        }


        private static bool CanMove(IScene scene, IPushable pushable, Pushable_MoveDirection moveDirection)
        {

            Rectangle futureRectangle = moveDirection switch
            {
                Pushable_MoveDirection.Up => new Rectangle(pushable.rectangle.X, pushable.rectangle.Y - 1, pushable.rectangle.Width, pushable.rectangle.Height),
                Pushable_MoveDirection.Down => new Rectangle(pushable.rectangle.X, pushable.rectangle.Y + 1, pushable.rectangle.Width, pushable.rectangle.Height),
                Pushable_MoveDirection.Right => new Rectangle(pushable.rectangle.X + 1, pushable.rectangle.Y, pushable.rectangle.Width, pushable.rectangle.Height),
                Pushable_MoveDirection.Left => new Rectangle(pushable.rectangle.X - 1, pushable.rectangle.Y, pushable.rectangle.Width, pushable.rectangle.Height),
                Pushable_MoveDirection.No => new Rectangle(pushable.rectangle.X, pushable.rectangle.Y, pushable.rectangle.Width, pushable.rectangle.Height),
            };

            List<Rectangle> rectangles = scene.entities
                                        .Where(x=>x.GetType() != typeof(Coin))
                                        .Where(x => x.layer == Layer.Middle)
                                        .Where(x => x.rectangle != pushable.rectangle)
                                        .Select(x => x.rectangle)
                                        .ToList();

            // future rectangle intersects?
            bool result = rectangles
                .Select(x => x.Intersects(futureRectangle))
                .Contains(true);

            return !result;
        }


        private static void MovePushable(IPushable pushable)
        {
            if (pushable.pushable_State == Pushable_MoveDirection.No) return;

            Rectangle futureRectangle = pushable.pushable_State switch
            {
                Pushable_MoveDirection.Up => new Rectangle(pushable.rectangle.X, pushable.rectangle.Y - 1, pushable.rectangle.Width, pushable.rectangle.Height),
                Pushable_MoveDirection.Down => new Rectangle(pushable.rectangle.X, pushable.rectangle.Y + 1, pushable.rectangle.Width, pushable.rectangle.Height),
                Pushable_MoveDirection.Right => new Rectangle(pushable.rectangle.X + 1, pushable.rectangle.Y, pushable.rectangle.Width, pushable.rectangle.Height),
                Pushable_MoveDirection.Left => new Rectangle(pushable.rectangle.X - 1, pushable.rectangle.Y, pushable.rectangle.Width, pushable.rectangle.Height),
                Pushable_MoveDirection.No => new Rectangle(pushable.rectangle.X, pushable.rectangle.Y, pushable.rectangle.Width, pushable.rectangle.Height),
            };

            pushable.rectangle = futureRectangle;

            if ((pushable.rectangle.Y % WK.Default.Pixels_Y == 0) && (pushable.rectangle.X % WK.Default.Pixels_X == 0))
                pushable.pushable_State = Pushable_MoveDirection.No;
        }
    }
}
