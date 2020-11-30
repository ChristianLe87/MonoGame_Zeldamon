using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class TextHelper
    {
        public static void Update(Text text, string newText = null)
        {
            if (newText != null) text.text = newText;
        }

        public static void Draw(SpriteBatch spriteBatch, Text text)
        {
            spriteBatch.DrawString(text.font, text.text, text.position, Color.Black);
        }
    }
}
