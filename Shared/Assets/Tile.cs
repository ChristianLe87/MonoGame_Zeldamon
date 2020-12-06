using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Tile : IEntity
    {
        public Texture2D texture { get; }
        public Rectangle rectangle { get; set; }

        public Layer layer { get; }

        public Tile(Texture2D texture, Point position, Layer layer)
        {
            this.texture = texture;
            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.layer = layer;
        }
    }
}