using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Tile : IEntity
    {
        public Texture2D texture2D { get; }
        public Rectangle rectangle { get; private set; }
        public string tag { get; private set; }
        public Layer layer { get; }
        public bool isCollider;

        public Tile(Texture2D texture, Point position, bool isCollider, Layer layer, string tag)
        {
            this.texture2D = texture;
            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.tag = tag;
            this.layer = layer;
            this.isCollider = isCollider;
        }
    }

    public enum Layer
    {
        Back,
        Middle,
        Front
    }
}