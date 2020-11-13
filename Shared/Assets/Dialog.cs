using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Dialog : IEntity
    {
        string[] text;
        Texture2D backgrowndTexture;
        SpriteFont font;
        Rectangle rectangle;
        public string tag { get; private set; }

        public Dialog(string[] text, Rectangle rectangle, string tag)
        {
            this.tag = tag;
            this.text = text;
            this.backgrowndTexture = Tools.CreateColorTexture(Color.LightBlue);
            this.font = Game1.contentManager.Load<SpriteFont>(WK.Content.Font.Arial_20);
            this.rectangle = rectangle;
        }

        public void Update(Player player, string[] text = null)
        {
            if(text != null) this.text = text;
            this.rectangle.X = player.rectangle.X - (WK.Default.CanvasWidth / 2) + (WK.Default.Pixels_X / 2);
            this.rectangle.Y = player.rectangle.Y + (WK.Default.CanvasHeight / 2) - rectangle.Height + (WK.Default.Pixels_Y / 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrowndTexture, rectangle, Color.White);
            spriteBatch.DrawString(font, text[0], new Vector2(rectangle.X, rectangle.Y), Color.Black);
        }
    }
}
