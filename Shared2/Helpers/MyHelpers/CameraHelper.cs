using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class CameraHelper
    {
        public static void Update(Camera camera, Player player)
        {
            if (player == null) return;

            camera.center = new Vector2(
                (player.rectangle.X + player.rectangle.Width / 2) - camera.viewport.Width / 2,
                (player.rectangle.Y + player.rectangle.Height / 2) - camera.viewport.Height / 2);
            camera.transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-camera.center.X, -camera.center.Y, 0));
        }

        public static void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);
        }
    }
}
