using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Portal
    {
        Rectangle position;

        string targetScene;
        Point targetPosition;

        Texture2D texture2D;

        public Portal(Point position, string targetScene, Point targetPosition, Texture2D texture2D = null)
        {
            this.position = new Rectangle(position.X, position.Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.targetScene = targetScene;
            this.targetPosition = targetPosition;

            this.texture2D = texture2D == null ? Tools.CreateColorTexture(Color.Red) : texture2D;
        }

        public void Update(Player player)
        {
            if (player.rectangle.Intersects(position))
            {
                Game1.ChangeScene(targetScene, targetPosition);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, position, Color.White);
        }
    }
}
