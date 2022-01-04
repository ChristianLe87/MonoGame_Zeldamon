using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
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
            spriteBatch.Draw(portal.texture, portal.rectangle, Color.White);
        }
    }
}
