using System;
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
        public Texture2D texture { get; private set; }
        public string tag { get; }
        public bool isActive { get; set; }

        public DxUiUpdateSystem dxUiUpdateSystem { get; }
        public DxUiDrawSystem dxUiDrawSystem { get; }

        public Minimimap(Dictionary<int, Color> minimapColors, int[,] map, Vector2 centerPosition)
        {
            // Implementation
            {
                Color[] colors = ToArrayOfColors(minimapColors, map);

                Texture2D mapTexture = CreateTexture(colors, map.GetLength(1), map.GetLength(0));

                this.texture = Tools.Texture.ScaleTexture(mapTexture, 15);
                this.rectangle = Tools.GetRectangle.Rectangle(centerPosition, texture);

                this.tag = "";
                this.isActive = true;
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
    }
}