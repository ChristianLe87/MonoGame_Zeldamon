using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Portal : IEntity
    {
        public Rectangle rectangle { get; private set; }
        public string tag { get; private set; }
        public string targetScene;
        public Point targetPosition;

        public Texture2D texture2D;

        public Portal(Point position, string targetScene, Point targetPosition, string tag, Texture2D texture2D = null)
        {
            this.tag = tag;

            this.rectangle = new Rectangle(position.X, position.Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.targetScene = targetScene;
            this.targetPosition = targetPosition;

            this.texture2D = texture2D == null ? Tools.CreateColorTexture(Color.Red) : texture2D;
        }
    }

    public class PortalHelpers
    {
        public static void Update(Portal portal, Player player)
        {
            if (player.rectangle.Intersects(portal.rectangle))
            {
                Game1.ChangeScene(portal.targetScene, portal.targetPosition);
            }
        }

        public static void Draw(SpriteBatch spriteBatch, Portal portal)
        {
            spriteBatch.Draw(portal.texture2D, portal.rectangle, Color.White);
        }
    }
}
