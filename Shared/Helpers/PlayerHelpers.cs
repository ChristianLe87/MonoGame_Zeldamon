﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class PlayerHelpers
    {
        public static void Update(IScene scene)
        {
            MovePlayer(scene);
        }

        public static void Draw(SpriteBatch spriteBatch, Player player)
        {
            switch (player.playerState)
            {
                case PlayerState.IdleUp:
                    spriteBatch.Draw(player.textures["texture_IdleUp"], player.rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                case PlayerState.IdleDown:
                    spriteBatch.Draw(player.textures["texture_IdleDown"], player.rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                case PlayerState.IdleRight:
                    spriteBatch.Draw(player.textures["texture_IdleRight"], player.rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                case PlayerState.IdleLeft:
                    spriteBatch.Draw(player.textures["texture_IdleLeft"], player.rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                case PlayerState.WalkUp:
                    spriteBatch.Draw(player.textures["texture_WalkUp"], player.rectangle, Color.White);
                    break;
                case PlayerState.WalkDown:
                    spriteBatch.Draw(player.textures["texture_WalkDown"], player.rectangle, Color.White);
                    break;
                case PlayerState.WalkRight:
                    spriteBatch.Draw(player.textures["texture_WalkRight"], player.rectangle, Color.White);
                    break;
                case PlayerState.WalkLeft:
                    spriteBatch.Draw(player.textures["texture_WalkLeft"], player.rectangle, Color.White);
                    break;
                default:
                    break;
            }
        }

        private static void MovePlayer(IScene scene)
        {
            Player player = scene.entities.First(x => x.tag == "player") as Player;

            List<Rectangle> NPCs = scene.entities.OfType<Inpc>().Select(x => x.rectangle).ToList();
            List<Rectangle> tiles = scene.entities.OfType<Map>().First().tiles.Where(x => x.tag == "x").Select(x => x.rectangle).ToList();
            List<Rectangle> rectangles = NPCs.Concat(tiles).ToList();

            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up) || player.characterDirecction == CharacterDirecction.Up)
            {
                player.playerState = PlayerState.IdleUp;

                if (GetCollideDirection(scene, CharacterDirecction.Up) == CharacterDirecction.Up) return;

                player.rectangle.Y -= 1;

                // move until player until alligne with tile
                if (player.rectangle.Y % WK.Default.Pixels_Y != 0)
                    player.characterDirecction = CharacterDirecction.Up;
                else
                    player.characterDirecction = CharacterDirecction._null;

            }
            else if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down) || player.characterDirecction == CharacterDirecction.Down)
            {
                player.playerState = PlayerState.IdleDown;

                if (GetCollideDirection(scene, CharacterDirecction.Down) == CharacterDirecction.Down) return;

                player.rectangle.Y += 1;

                // move until player until alligne with tile
                if (player.rectangle.Y % WK.Default.Pixels_Y != 0)
                    player.characterDirecction = CharacterDirecction.Down;
                else
                    player.characterDirecction = CharacterDirecction._null;

            }
            else if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right) || player.characterDirecction == CharacterDirecction.Right)
            {
                player.playerState = PlayerState.IdleRight;

                if (GetCollideDirection(scene, CharacterDirecction.Right) == CharacterDirecction.Right) return;

                player.rectangle.X += 1;

                // move until player until alligne with tile
                if (player.rectangle.X % WK.Default.Pixels_X != 0)
                    player.characterDirecction = CharacterDirecction.Right;
                else
                    player.characterDirecction = CharacterDirecction._null;

            }
            else if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left) || player.characterDirecction == CharacterDirecction.Left)
            {
                player.playerState = PlayerState.IdleLeft;

                if (GetCollideDirection(scene, CharacterDirecction.Left) == CharacterDirecction.Left) return;

                player.rectangle.X -= 1;

                // move until player until alligne with tile
                if (player.rectangle.X % WK.Default.Pixels_X != 0)
                    player.characterDirecction = CharacterDirecction.Left;
                else
                    player.characterDirecction = CharacterDirecction._null;

            }
        }


        private static CharacterDirecction GetCollideDirection(IScene scene, CharacterDirecction moveDirection)
        {
            Player player = scene.entities.First(x => x.tag == "player") as Player;

            List<Rectangle> NPCs = scene.entities.OfType<Inpc>().Select(x => x.rectangle).ToList();
            List<Rectangle> tiles = scene.entities.OfType<Map>().First().tiles.Where(x => x.tag == "x").Select(x => x.rectangle).ToList();
            List<Rectangle> rectangles = NPCs.Concat(tiles).ToList();

            Rectangle futurePlayerRectangle = player.rectangle;

            if (moveDirection == CharacterDirecction.Right)
            {
                futurePlayerRectangle.X++;

                bool collisionDetected = GetIfWillIntersects(rectangles, futurePlayerRectangle);

                if (collisionDetected) return CharacterDirecction.Right;
            }
            else if (moveDirection == CharacterDirecction.Left)
            {
                futurePlayerRectangle.X--;

                bool collisionDetected = GetIfWillIntersects(rectangles, futurePlayerRectangle);

                if (collisionDetected) return CharacterDirecction.Left;
            }
            else if (moveDirection == CharacterDirecction.Up)
            {
                futurePlayerRectangle.Y--;

                bool collisionDetected = GetIfWillIntersects(rectangles, futurePlayerRectangle);

                if (collisionDetected) return CharacterDirecction.Up;
            }
            else if (moveDirection == CharacterDirecction.Down)
            {
                futurePlayerRectangle.Y++;

                bool collisionDetected = GetIfWillIntersects(rectangles, futurePlayerRectangle);

                if (collisionDetected) return CharacterDirecction.Down;
            }

            return CharacterDirecction._null;
        }

        private static bool GetIfWillIntersects(List<Rectangle> rectangles, Rectangle futurePlayerRectangle)
        {
            return rectangles
                        .Select(x => x.Intersects(futurePlayerRectangle))
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