﻿using System;
using ChristianTools.Components;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using ChristianTools.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Minimimap : IUI
    {
        public Rectangle rectangle { get; private set; }
        //Vector2 centerPosition { get => rectangle.Center.ToVector2(); }

        public Texture2D texture { get; private set; }
        public string tag { get; }
        public bool isActive { get; set; }

        public DxUiUpdateSystem dxUiUpdateSystem { get; }
        public DxUiDrawSystem dxUiDrawSystem { get; }

        Texture2D miniPlayerTexture;

        public Minimimap(Dictionary<int, Color> minimapColors, int[,] map, Vector2 centerPosition, int scaleFactor)//, Camera camera//, Player player)
        {
            // Implementation
            {
                Color[] colors = ToArrayOfColors(minimapColors, map);

                Texture2D mapTexture = CreateTexture(colors, map.GetLength(1), map.GetLength(0));

                this.texture = Tools.Texture.ScaleTexture(mapTexture, scaleFactor);
                this.rectangle = Tools.GetRectangle.Rectangle(centerPosition, texture);

                this.tag = "";
                this.isActive = true;
                //this.camera = camera;

                this.dxUiUpdateSystem = (InputState lastInputState, InputState inputState) => UpdateSystem();
                this.dxUiDrawSystem = (SpriteBatch spriteBatch) => DrawSystem(spriteBatch);
                this.miniPlayerTexture = Tools.Texture.CreateColorTexture(Color.Red, scaleFactor, scaleFactor);
            }

            // Helpers
            Color[] ToArrayOfColors(Dictionary<int, Color> minimapColors, int[,] map)
            {
                List<Color> colors = new List<Color>();

                for (int row = 0; row < map.GetLength(0); row++)
                {
                    for (int element = 0; element < map.GetLength(1); element++)
                    {
                        if (minimapColors[map[row, element]] != null)
                        {
                            colors.Add(minimapColors[map[row, element]]);
                        }
                    }
                }

                return colors.ToArray();
            }

            Texture2D CreateTexture(Color[] colors, int W, int H)
            {
                GraphicsDevice graphicsDevice = ChristianGame.graphicsDevice;

                Texture2D texture2D = new Texture2D(graphicsDevice, W, H, false, SurfaceFormat.Color);

                texture2D.SetData(colors);

                return texture2D;
            }
        }

        private void UpdateSystem()
        {
            //Player player = ChristianGame.GetScene.entities.OfType<Player>().First();
            //playerPosition = rectangle.Center.ToVector2();// + player.rigidbody.centerPosition;
        }

        private void DrawSystem(SpriteBatch spriteBatch)
        {

            // === minimap ===
            Rectangle rect = new Rectangle((int)(rectangle.X + ChristianGame.GetScene.camera.rectangle.X), (int)(rectangle.Y + ChristianGame.GetScene.camera.rectangle.Y), rectangle.Width, rectangle.Height);
            spriteBatch.Draw(texture, rect.Center.ToVector2(), Color.White);




            // === mini player ===
            Player player = ChristianGame.GetScene.entities.OfType<Player>().First();

            // put player on the minimap
            Vector2 miniPlayer = rect.Center.ToVector2();


            // center player in the minimap
            int assetSize_x_scaleFactor = WK.Default.AssetSize * WK.Default.ScaleFactor;

            int adjust_x = (int)((player.rigidbody.centerPosition.X - (assetSize_x_scaleFactor / 2)) / (assetSize_x_scaleFactor));
            int adjust_y = (int)((player.rigidbody.centerPosition.Y - (assetSize_x_scaleFactor / 2)) / (assetSize_x_scaleFactor));

            miniPlayer.X += adjust_x * WK.Default.ScaleFactor;
            miniPlayer.Y += adjust_y * WK.Default.ScaleFactor;

            spriteBatch.Draw(miniPlayerTexture, miniPlayer, Color.White);
        }
    }
}