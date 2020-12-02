using System;
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
        public Rectangle rectangle;
        public Rectangle areaOfIntersection;
        public Cube_Moving cube_Moving;

        public Cube(Point position)
        {
            this.texture2D = Tools.CreateColorTexture(Color.Gray);
            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.areaOfIntersection = new Rectangle(position.X * WK.Default.Pixels_X - 1, position.Y * WK.Default.Pixels_Y - 1, WK.Default.Pixels_X + 2, WK.Default.Pixels_Y + 2);
            this.cube_Moving = Cube_Moving.No;
        }
    }

    public class CubeHelper
    {
        public static void Update(IScene scene, Cube cube)
        {
            Player player = scene.entities.OfType<Player>().First();
            
            if (player.rectangle.Intersects(cube.areaOfIntersection))
            {
                KeyboardState keyboardState = Keyboard.GetState();

                int y = player.rectangle.Y - cube.rectangle.Y;
                if (y == 0)
                {
                    if (player.rectangle.X < cube.rectangle.X)
                    {
                        if (player.playerState == PlayerState.IdleRight && keyboardState.IsKeyDown(Keys.M))
                        {
                            cube.cube_Moving = Cube_Moving.Right;
                            cube.rectangle.X++;
                            cube.areaOfIntersection.X++;
                        }
                    }
                    else
                    {
                        if (player.playerState == PlayerState.IdleLeft && keyboardState.IsKeyDown(Keys.M))
                        {
                            cube.cube_Moving = Cube_Moving.Left;
                            cube.rectangle.X--;
                            cube.areaOfIntersection.X--;
                        }
                    }
                }

                int x = player.rectangle.X - cube.rectangle.X;
                if (x == 0)
                {
                    if (player.rectangle.Y > cube.rectangle.Y)
                    {
                        if (player.playerState == PlayerState.IdleUp && keyboardState.IsKeyDown(Keys.M))
                        {
                            cube.cube_Moving = Cube_Moving.Up;
                            cube.rectangle.Y--;
                            cube.areaOfIntersection.Y--;
                        }
                    }
                    else
                    {
                        if (player.playerState == PlayerState.IdleDown && keyboardState.IsKeyDown(Keys.M))
                        {
                            cube.cube_Moving = Cube_Moving.Down;
                            cube.rectangle.Y++;
                            cube.areaOfIntersection.Y++;
                        }
                    }
                }
            }

            MoveCube(cube, player);
        }

        public static void Draw(SpriteBatch spriteBatch, Cube cube)
        {
            spriteBatch.Draw(cube.texture2D, cube.rectangle, Color.White);
        }

        private static void MoveCube(Cube cube, Player player)
        {
            if (cube.cube_Moving == Cube_Moving.Down)
            {
                // move until cube until alligne with tile
                if (cube.rectangle.Y % WK.Default.Pixels_Y != 0)
                {
                    cube.rectangle.Y++;
                    cube.areaOfIntersection.Y++;
                }
                else
                    cube.cube_Moving = Cube_Moving.No;
            }

            if (cube.cube_Moving == Cube_Moving.Left)
            {
                // move until cube until alligne with tile
                if (cube.rectangle.X % WK.Default.Pixels_X != 0)
                {
                    cube.rectangle.X--;
                    cube.areaOfIntersection.X--;
                }
                else
                    cube.cube_Moving = Cube_Moving.No;
            }

            if (cube.cube_Moving == Cube_Moving.Up)
            {
                // move until cube until alligne with tile
                if (cube.rectangle.Y % WK.Default.Pixels_Y != 0)
                {
                    cube.rectangle.Y--;
                    cube.areaOfIntersection.Y--;
                }
                else
                    cube.cube_Moving = Cube_Moving.No;
            }

            if (cube.cube_Moving == Cube_Moving.Right)
            {
                // move until cube until alligne with tile
                if (cube.rectangle.X % WK.Default.Pixels_X != 0)
                {
                    cube.rectangle.X++;
                    cube.areaOfIntersection.X++;
                }
                else
                    cube.cube_Moving = Cube_Moving.No;
            }
        }
    }

}
