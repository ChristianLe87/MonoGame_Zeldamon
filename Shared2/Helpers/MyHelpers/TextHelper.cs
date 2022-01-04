using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class TextHelper
    {
        public static void Update(MoneyText text, IScene scene, string newText = null)
        {
            if (newText != null) text.text = newText;
            text.position = new Vector2((scene.camera.center.X), (scene.camera.center.Y));
        }

        public static void Draw(SpriteBatch spriteBatch, MoneyText text)
        {
            spriteBatch.DrawString(text.font, text.text, text.position, Color.Black);
        }
    }
}
