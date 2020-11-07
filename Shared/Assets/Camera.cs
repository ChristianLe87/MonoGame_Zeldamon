using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Camera
    {
        public Matrix transform;
        Viewport viewport;
        Vector2 center;

        public Camera()
        {
            this.viewport = Game1.spriteBatch.GraphicsDevice.Viewport;
        }

        public void Update(Player player)
        {
            if (player == null) return;

            center = new Vector2(
                (player.rectangle.X + player.rectangle.Width / 2) - this.viewport.Width / 2,
                (player.rectangle.Y + player.rectangle.Height / 2) - this.viewport.Height / 2);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, transform);
        }
    }
}
