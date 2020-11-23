using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Dialog : IEntity
    {
        public string[] text;
        public string actualText;
        Texture2D backgrowndTexture;
        //Button button;
        SpriteFont font;
        public Rectangle rectangle;
        public string tag { get; private set; }
        bool isKeyRelease;


        public Dialog(string[] text, Rectangle rectangle, string tag)
        {
            this.tag = tag;
            this.text = text;
            this.actualText = text[0];
            this.backgrowndTexture = Tools.CreateColorTexture(Color.LightBlue);
            //this.button = new Button(this);// new Rectangle(rectangle.Center.X - (WK.Default.Pixels_X / 2), rectangle.Y + (rectangle.Height - WK.Default.Pixels_Y), WK.Default.Pixels_X, WK.Default.Pixels_Y));
            this.font = Game1.contentManager.Load<SpriteFont>(WK.Content.Font.Arial_20);
            this.rectangle = rectangle;
            this.isKeyRelease = true;
        }

        public void Update(IScene scene, string[] text = null)
        {
            Player player = scene.entities.First(x => x.tag == "player") as Player;

            //if (text != null) this.text = text;
            this.rectangle.X = player.rectangle.X - (WK.Default.CanvasWidth / 2) + (WK.Default.Pixels_X / 2);
            this.rectangle.Y = player.rectangle.Y + (WK.Default.CanvasHeight / 2) - rectangle.Height + (WK.Default.Pixels_Y / 2);

            //button.Update(scene);
            NextText(scene);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgrowndTexture, rectangle, Color.White);
            spriteBatch.DrawString(font, actualText, new Vector2(rectangle.X, rectangle.Y), Color.Black);
            //button.Draw(spriteBatch);
        }

        public void NextText(IScene scene)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.X) && isKeyRelease == true)
            {
                isKeyRelease = false;

                int index = Array.IndexOf(text, actualText);

                if (index + 1 == text.Length)
                    scene.entities.RemoveAll(x => x.tag == "dialog");
                else
                    actualText = text[index + 1];

            }

            if (keyboardState.IsKeyUp(Keys.X) && isKeyRelease == false)
            {
                isKeyRelease = true;
            }
        }
    }
}
