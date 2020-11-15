using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class Button
    {
        Texture2D texture;
        Rectangle rectangle;
        bool isKeyRelease;

        public Button(Rectangle rectangle)
        {
            this.isKeyRelease = true;
            this.rectangle = rectangle;
            this.texture = Tools.GetTexture(WK.Content.Texture.UI.X_Button, WK.Content.Folder.UI);
        }

        public void Update(IScene scene)
        {
            Dialog dialog = scene.entities.First(x => x.tag == "dialog") as Dialog;
            this.rectangle = new Rectangle(dialog.rectangle.Center.X - (WK.Default.Pixels_X / 2), dialog.rectangle.Y + (dialog.rectangle.Height - WK.Default.Pixels_Y), WK.Default.Pixels_X, WK.Default.Pixels_Y);
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.X) && isKeyRelease == true)
            {
                isKeyRelease = false;
                scene.entities.RemoveAll(x => x.tag == "dialog");
            }

            if (keyboardState.IsKeyUp(Keys.X) && isKeyRelease == false)
            {
                isKeyRelease = true;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
