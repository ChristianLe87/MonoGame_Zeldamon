using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Tile
    {
        Texture2D texture2D;
        public Rectangle rectangle { get; private set; }
        public string tag { get; private set; }
        public Layer layer { get; private set; }

        public Tile(Texture2D texture, Layer layer, Point position, string tag)
        {
            this.texture2D = texture;
            this.rectangle = new Rectangle(position.X, position.Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.tag = tag;
            this.layer = layer;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, rectangle, Color.White);
        }
    }

    public enum Layer
    {
        Background,
        Main,
        Front
    }

}