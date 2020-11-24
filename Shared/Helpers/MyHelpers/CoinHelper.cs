using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class CoinHelper
    {
        public static void Update(Player player, IPickable pickable)
        {
            if (pickable.rectangle.Intersects(player.rectangle) && pickable.isActive == true)
            {
                pickable.isActive = false;
                player.money++;
            }
        }

        public static void Draw(SpriteBatch spriteBatch, IPickable pickable)
        {
            spriteBatch.Draw(pickable.texture, pickable.rectangle, Color.White);
        }
    }
}
