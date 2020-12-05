using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    interface IPushable
    {

    }

    public class Cube : IPushable, IEntity
    {
        public Texture2D texture2D;
        public Rectangle rectangle { get; set; }
        public Rectangle areaOfIntersection { get => new Rectangle(rectangle.X - 1, rectangle.Y - 1, rectangle.Width + 2, rectangle.Height + 2); }
        public Cube_Moving cube_Moving;
        public Layer layer { get; }

        public Cube(Point position, Layer layer)
        {
            this.texture2D = Tools.CreateColorTexture(Color.Gray);
            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.cube_Moving = Cube_Moving.No;
            this.layer = layer;
        }
    }

    public class CubeHelper
    {

        private static void MoveRectangle(Cube cube)
        {
            cube.rectangle = cube.cube_Moving switch
            {
                Cube_Moving.Up => new Rectangle(cube.rectangle.X, cube.rectangle.Y - 1, cube.rectangle.Width, cube.rectangle.Height),
                Cube_Moving.Down => new Rectangle(cube.rectangle.X, cube.rectangle.Y + 1, cube.rectangle.Width, cube.rectangle.Height),
                Cube_Moving.Right => new Rectangle(cube.rectangle.X + 1, cube.rectangle.Y, cube.rectangle.Width, cube.rectangle.Height),
                Cube_Moving.Left => new Rectangle(cube.rectangle.X - 1, cube.rectangle.Y, cube.rectangle.Width, cube.rectangle.Height),
                Cube_Moving.No => cube.rectangle,
                _ => throw new NotImplementedException(),
            };
        }

        public static void Update(IScene scene, Cube cube)
        {

            Player player = scene.entities.OfType<Player>().First();

            List<Rectangle> rectangles = scene.entities
                                                    .Where(x => x.GetType() != typeof(Cube))
                                                    .Where(x => x.GetType() != typeof(Player))
                                                    .Where(x => x.layer == Layer.Middle)
                                                    .Select(x => x.rectangle).ToList();

            cube.cube_Moving = player.playerState switch
            {
                PlayerState.IdleUp => Cube_Moving.Up,
                PlayerState.IdleDown => Cube_Moving.Down,
                PlayerState.IdleRight => Cube_Moving.Right,
                PlayerState.IdleLeft => Cube_Moving.Left,
            };

            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.M) && player.rectangle.Intersects(cube.areaOfIntersection))
            {
                cube.cube_Moving = FutureMovement(player, cube);

                bool canMove = CanMove(cube, rectangles);

                if (canMove)
                {
                    MoveRectangle(cube);
                }
                else
                    cube.cube_Moving = Cube_Moving.No;
            }

            MoveCube(cube);
        }

        public static void Draw(SpriteBatch spriteBatch, Cube cube)
        {
            spriteBatch.Draw(cube.texture2D, cube.rectangle, Color.White);
        }

        private static Cube_Moving FutureMovement(Player player, Cube cube)
        {
            int y = player.rectangle.Y - cube.rectangle.Y;
            if (y == 0)
            {
                if (player.rectangle.X < cube.rectangle.X)
                {
                    if (player.playerState == PlayerState.IdleRight)
                    {
                        return cube.cube_Moving = Cube_Moving.Right;
                    }
                }
                else
                {
                    if (player.playerState == PlayerState.IdleLeft)
                    {
                        return cube.cube_Moving = Cube_Moving.Left;
                    }
                }
            }

            int x = player.rectangle.X - cube.rectangle.X;
            if (x == 0)
            {
                if (player.rectangle.Y > cube.rectangle.Y)
                {
                    if (player.playerState == PlayerState.IdleUp)
                    {
                        return cube.cube_Moving = Cube_Moving.Up;
                    }
                }
                else
                {
                    if (player.playerState == PlayerState.IdleDown)
                    {
                        return cube.cube_Moving = Cube_Moving.Down;
                    }
                }
            }

            return Cube_Moving.No;
        }

        private static bool CanMove(Cube cube, List<Rectangle> rectangles)
        {

            Rectangle futureRectangle = cube.cube_Moving switch
            {
                Cube_Moving.Up => new Rectangle(cube.rectangle.X, cube.rectangle.Y - 1, cube.rectangle.Width, cube.rectangle.Height),
                Cube_Moving.Down => new Rectangle(cube.rectangle.X, cube.rectangle.Y + 1, cube.rectangle.Width, cube.rectangle.Height),
                Cube_Moving.Right => new Rectangle(cube.rectangle.X + 1, cube.rectangle.Y, cube.rectangle.Width, cube.rectangle.Height),
                Cube_Moving.Left => new Rectangle(cube.rectangle.X - 1, cube.rectangle.Y, cube.rectangle.Width, cube.rectangle.Height),
                Cube_Moving.No => cube.rectangle
            };

            foreach (var rec in rectangles)
            {
                if (futureRectangle.Intersects(rec))
                {
                    return false;
                }
            }

            return true;
        }

        private static void MoveCube(Cube cube)
        {
            // move until cube until alligne with tile
            {
                if (cube.cube_Moving == Cube_Moving.Down)
                {
                    // move until cube until alligne with tile
                    if (cube.rectangle.Y % WK.Default.Pixels_Y != 0)
                    {
                        MoveRectangle(cube);
                    }
                    else
                        cube.cube_Moving = Cube_Moving.No;
                }

                if (cube.cube_Moving == Cube_Moving.Left)
                {
                    // move until cube until alligne with tile
                    if (cube.rectangle.X % WK.Default.Pixels_X != 0)
                    {
                        MoveRectangle(cube);
                    }
                    else
                        cube.cube_Moving = Cube_Moving.No;
                }

                if (cube.cube_Moving == Cube_Moving.Up)
                {
                    // move until cube until alligne with tile
                    if (cube.rectangle.Y % WK.Default.Pixels_Y != 0)
                    {
                        MoveRectangle(cube);
                    }
                    else
                        cube.cube_Moving = Cube_Moving.No;
                }

                if (cube.cube_Moving == Cube_Moving.Right)
                {
                    // move until cube until alligne with tile
                    if (cube.rectangle.X % WK.Default.Pixels_X != 0)
                    {
                        MoveRectangle(cube);
                    }
                    else
                        cube.cube_Moving = Cube_Moving.No;
                }
            }
        }
    }
}
