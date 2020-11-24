using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class DialogHelper
    {
        public static void Update(Dialog dialog, IScene scene)
        {
            NextText(dialog, scene);
        }

        public static void Draw(SpriteBatch spriteBatch, Dialog dialog)
        {
            spriteBatch.Draw(dialog.backgrowndTexture, dialog.rectangle, Color.White);
            spriteBatch.DrawString(dialog.font, dialog.actualText, new Vector2(dialog.rectangle.X, dialog.rectangle.Y), Color.Black);
        }

        private static void NextText(Dialog dialog, IScene scene)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.X) && dialog.isKeyRelease == true)
            {
                dialog.isKeyRelease = false;

                int index = Array.IndexOf(dialog.text, dialog.actualText);

                if (index + 1 == dialog.text.Length)
                    scene.entities.RemoveAll(x => x.tag == "dialog");
                else
                    dialog.actualText = dialog.text[index + 1];

            }

            if (keyboardState.IsKeyUp(Keys.X) && dialog.isKeyRelease == false)
            {
                dialog.isKeyRelease = true;
            }
        }
    }
}
