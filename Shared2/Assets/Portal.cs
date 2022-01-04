using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Portal : IEntity
    {
        public Rectangle rectangle { get; set; }
        public string targetScene;
        public Point targetPosition;
        public Texture2D texture { get; set; }

        public Layer layer { get; }

        public Portal(Point position, string targetScene, Point targetPosition, Layer layer)
        {
            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.targetScene = targetScene;
            this.targetPosition = targetPosition;

            this.texture = Tools.CreateColorTexture(Color.Red);
            this.layer = layer;
        }
    }
}
