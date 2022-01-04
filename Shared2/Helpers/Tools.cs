using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Tools
    {
        public static Texture2D CreateColorTexture(Color color)
        {
            Texture2D newTexture = new Texture2D(Game1.graphicsDeviceManager.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            newTexture.SetData(new Color[] { color });
            return newTexture;
        }

        public static Texture2D GetTexture(string imageName, string folder)
        {
            string absolutePath = new DirectoryInfo(Path.Combine(Path.Combine(Game1.contentManager.RootDirectory, folder), $"{imageName}.png")).ToString();

            FileStream fileStream = new FileStream(absolutePath, FileMode.Open);

            var result = Texture2D.FromStream(Game1.graphicsDeviceManager.GraphicsDevice, fileStream);
            fileStream.Dispose();

            return result;
        }

        public static Texture2D GetSubtextureFromAtlasTexture(Point imagePosition)
        {
            Texture2D atlasTexture = GetTexture(WK.Content.Texture.GeneralCollection.TileCollection, "");

            Texture2D subtexture = new Texture2D(Game1.graphicsDeviceManager.GraphicsDevice, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            int count = WK.Default.Pixels_X * WK.Default.Pixels_Y;
            Color[] data = new Color[count];

            atlasTexture.GetData(0, new Rectangle(imagePosition.X * WK.Default.Pixels_X, imagePosition.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y), data, 0, count);
            subtexture.SetData(data);

            return subtexture;
        }


    }
}
