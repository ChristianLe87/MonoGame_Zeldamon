using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Cube_1 : IPushable
    {
        public Texture2D texture2D { get; }
        public Pushable_MoveDirection pushable_State { get; set; }
        public Layer layer { get; }
        public Rectangle rectangle { get; set; }
        public Rectangle areaOfIntersection { get => new Rectangle(rectangle.X - 1, rectangle.Y - 1, rectangle.Width + 2, rectangle.Height + 2); }

        public Cube_1(Point position, Layer layer)
        {
            this.texture2D = Tools.CreateColorTexture(Color.Gray);
            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.pushable_State = Pushable_MoveDirection.No;
            this.layer = layer;
        }
    }
}