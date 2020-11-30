using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class CoinHelper
    {
        public static void Update(IScene scene, Coin pickable)
        {
            Player player = scene.entities.OfType<Player>().First();

            if (pickable.rectangle.Intersects(player.rectangle) && pickable.isActive == true)
            {
                pickable.isActive = false;
                player.money++;
                scene.entities.Add(new PointsFeedback(new Point(pickable.rectangle.X, pickable.rectangle.Y), "+1"));
            }
        }

        public static void Draw(SpriteBatch spriteBatch, IPickable pickable)
        {
            spriteBatch.Draw(pickable.texture, pickable.rectangle, Color.White);
        }
    }
}
