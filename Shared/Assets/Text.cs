using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Text : IEntity
    {
        public SpriteFont font;
        public string text;
        public Vector2 position;
        public Rectangle rectangle => throw new System.NotImplementedException();
        public Texture2D texture => throw new System.NotImplementedException();

        public Text(string text, Vector2 position)
        {
            this.text = text;
            this.position = position;
            this.font = Game1.contentManager.Load<SpriteFont>(WK.Content.Font.Arial_20);
        }        
    }
}