using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Coin : IPickable
    {
        public Rectangle rectangle { get; set; }
        public bool isActive { get; set; }
        public Texture2D texture { get; }

        public Layer layer { get; }

        public Coin(bool isActive, Point point, Layer layer)
        {
            this.rectangle = new Rectangle(point.X * WK.Default.Pixels_X, point.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.isActive = isActive;
            this.texture = Tools.GetSubtextureFromAtlasTexture(new Point(3, 4));
            this.layer = layer;
        }
    }
}
