using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class PushableHelper
    {
        public static void Update(IScene scene, IPushable pushable)
        {
        }

        public static void Draw(SpriteBatch spriteBatch, IPushable cube)
        {
            spriteBatch.Draw(cube.texture2D, cube.rectangle, Color.White);
        }
    }
}
