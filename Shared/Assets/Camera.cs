using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Camera
    {
        public Matrix transform;
        public Viewport viewport;
        public Vector2 center;

        public Camera()
        {
            this.viewport = Game1.spriteBatch.GraphicsDevice.Viewport;
        }
    }
}
