using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Coin : IPickable
    {
        public string tag { get; private set; }
        public Rectangle rectangle { get; set; }
        public bool isActive { get; set; }
        public Texture2D texture { get; set; }

        public Coin(string tag, bool isActive, Point point)
        {
            this.rectangle = new Rectangle(point.X * WK.Default.Pixels_X, point.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.tag = tag;
            this.isActive = isActive;
            this.texture = Tools.CreateColorTexture(Color.Yellow);
        }
    }
}
