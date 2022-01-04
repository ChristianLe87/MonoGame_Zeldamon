using Microsoft.Xna.Framework;

namespace Shared
{
    public class PointsFeedback : IPointsFeedback
    {
        public Layer layer { get; }
        public Rectangle rectangle { get; set; }
        public int timeToDestroy { get; }
        public bool isAlive { get; set; }
        public MoneyText text { get; }
        public int actualTime { get; set; }

        public PointsFeedback(Point position, string text, Layer layer)
        {
            this.text = new MoneyText(text, new Vector2(position.X, position.Y));
            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.timeToDestroy = 60;
            this.isAlive = true;
            this.layer = layer;
        }
    }
}