using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Dialog
    {
        string[] text;
        Texture2D backgrowndTexture;
        SpriteFont font;
        Rectangle rectangle;

        public Dialog(string[] text, Rectangle rectangle)
        {
            this.text = text;
            this.backgrowndTexture = Tools.CreateColorTexture(Color.LightBlue);
            this.font = Game1.contentManager.Load<SpriteFont>(WK.Content.Arial_20);
            this.rectangle = rectangle;
        }

        public void Update(Player player)
        {
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
