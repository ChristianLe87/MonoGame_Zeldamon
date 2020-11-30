using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class CoinHelper
    {
        public static void Update(IScene scene, IPickable pickable)
        {
            Player player = scene.entities.OfType<Player>().First();

            if (pickable.rectangle.Intersects(player.rectangle) && pickable.isActive == true)
            {
                pickable.isActive = false;
                player.money++;
                scene.entities.Add(new My_PointFeedback(new Point(pickable.rectangle.X, pickable.rectangle.Y), "+1", "feedback"));
            }
        }

        public static void Draw(SpriteBatch spriteBatch, IPickable pickable)
        {
            spriteBatch.Draw(pickable.texture, pickable.rectangle, Color.White);
        }
    }
}
