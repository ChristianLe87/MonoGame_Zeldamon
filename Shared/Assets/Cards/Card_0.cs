using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Card_0 : ICard
    {
        public Texture2D texture2D { get; }
        public Layer layer { get; }
        public Rectangle rectangle { get; set; }

        public Card_0(Point position, Layer layer)
        {
            this.layer = layer;
            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, 3 * WK.Default.Pixels_X, 4 * WK.Default.Pixels_Y);
            this.texture2D = Tools.GetTexture(WK.Content.Texture.Card.Carta_0, WK.Content.Folder.Cartas);
        }
    }
}