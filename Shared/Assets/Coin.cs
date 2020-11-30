using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Coin : IEntity, IPickable
    {
        public Rectangle rectangle { get; set; }
        public bool isActive { get; set; }
        public Texture2D texture { get; set; }

        public Coin(bool isActive, Point point)
        {
            this.rectangle = new Rectangle(point.X * WK.Default.Pixels_X, point.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.isActive = isActive;
            this.texture = Tools.GetSubtextureFromAtlasTexture(new Point(3, 4));
        }
    }
}
