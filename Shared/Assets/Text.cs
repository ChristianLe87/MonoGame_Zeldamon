using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Text : IEntity
    {
        public SpriteFont font;
        public string text;
        public Vector2 position;

        public string tag { get; private set; }
        public Layer layer { get; private set; }

        public Rectangle rectangle => throw new System.NotImplementedException();
        public Texture2D texture => throw new System.NotImplementedException();

        public Text(string text, Vector2 position, string tag, Layer layer)
        {
            this.tag = tag;
            this.layer = layer;
            this.text = text;
            this.position = position;
            this.font = Game1.contentManager.Load<SpriteFont>(WK.Content.Font.Arial_20);
        }        
    }

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