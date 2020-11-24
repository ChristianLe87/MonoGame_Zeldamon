using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Text
    {
        public SpriteFont font;
        public string text;
        Vector2 position;

        public Text(string text, Vector2 position)
        {
            this.text = text;
            this.position = position;
            this.font = Game1.contentManager.Load<SpriteFont>(WK.Content.Font.Arial_20);
        }

        public void Update(string text = null)
        {
            if (text != null)
                this.text = text;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, Color.Black);
        }
    }
}
