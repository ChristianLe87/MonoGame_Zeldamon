using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class FlashHelper
    {
        public static void Turn_On_Off(IScene scene)
        {
            Player player = scene.entities.OfType<Player>().First();

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.F) == true && player.flash.isFlashKeyRelease == true)
            {
                player.flash.isFlashOn = !player.flash.isFlashOn;
                player.flash.isFlashKeyRelease = false;
            }

            if(keyboardState.IsKeyUp(Keys.F) == true && player.flash.isFlashKeyRelease == false)
            {
                player.flash.isFlashKeyRelease = true;
            }

        }

        public static void Draw(SpriteBatch spriteBatch, IScene scene)
        {
            Player player = scene.entities.OfType<Player>().First();
            Rectangle rectangle = new Rectangle(player.rectangle.Center.X - (720 / 2), player.rectangle.Center.Y - (720 / 2), 720, 720);

            if (player.playerState == PlayerState.IdleUp || player.playerState == PlayerState.WalkUp)
            {
                if (scene.isDark == true && player.flash.isFlashOn == true)
                    spriteBatch.Draw(player.flash.flashTextures[WK.Content.Texture.Flash.FlashNightOn_Up_720x720_PNG], rectangle, Color.White);
                else if (scene.isDark == true && player.flash.isFlashOn == false)
                    spriteBatch.Draw(player.flash.flashTextures[WK.Content.Texture.Flash.FlashNightOff_720x720_PNG], rectangle, Color.White);
                else if (scene.isDark == false && player.flash.isFlashOn == true)
                    spriteBatch.Draw(player.flash.flashTextures[WK.Content.Texture.Flash.FlashDayOn_Up_720x720_PNG], rectangle, Color.White);
                //else if (scene.isDark == false && player.flash.isFlashOn == false) // doNothing
            }
            else if (player.playerState == PlayerState.IdleDown || player.playerState == PlayerState.WalkDown)
            {
                if (scene.isDark == true && player.flash.isFlashOn == true)
                    spriteBatch.Draw(player.flash.flashTextures[WK.Content.Texture.Flash.FlashNightOn_Down_720x720_PNG], rectangle, Color.White);
                else if (scene.isDark == true && player.flash.isFlashOn == false)
                    spriteBatch.Draw(player.flash.flashTextures[WK.Content.Texture.Flash.FlashNightOff_720x720_PNG], rectangle, Color.White);
                else if (scene.isDark == false && player.flash.isFlashOn == true)
                    spriteBatch.Draw(player.flash.flashTextures[WK.Content.Texture.Flash.FlashDayOn_Down_720x720_PNG], rectangle, Color.White);
                //else if (scene.isDark == false && player.flash.isFlashOn == false) // doNothing
            }
            else if (player.playerState == PlayerState.IdleRight || player.playerState == PlayerState.WalkRight)
            {
                if (scene.isDark == true && player.flash.isFlashOn == true)
                    spriteBatch.Draw(player.flash.flashTextures[WK.Content.Texture.Flash.FlashNightOn_Right_720x720_PNG], rectangle, Color.White);
                else if (scene.isDark == true && player.flash.isFlashOn == false)
                    spriteBatch.Draw(player.flash.flashTextures[WK.Content.Texture.Flash.FlashNightOff_720x720_PNG], rectangle, Color.White);
                else if (scene.isDark == false && player.flash.isFlashOn == true)
                    spriteBatch.Draw(player.flash.flashTextures[WK.Content.Texture.Flash.FlashDayOn_Right_720x720_PNG], rectangle, Color.White);
                //else if (scene.isDark == false && player.flash.isFlashOn == false) // doNothing
            }
            else if (player.playerState == PlayerState.IdleLeft || player.playerState == PlayerState.WalkLeft)
            {
                if (scene.isDark == true && player.flash.isFlashOn == true)
                    spriteBatch.Draw(player.flash.flashTextures[WK.Content.Texture.Flash.FlashNightOn_Left_720x720_PNG], rectangle, Color.White);
                else if (scene.isDark == true && player.flash.isFlashOn == false)
                    spriteBatch.Draw(player.flash.flashTextures[WK.Content.Texture.Flash.FlashNightOff_720x720_PNG], rectangle, Color.White);
                else if (scene.isDark == false && player.flash.isFlashOn == true)
                    spriteBatch.Draw(player.flash.flashTextures[WK.Content.Texture.Flash.FlashDayOn_Left_720x720_PNG], rectangle, Color.White);
                //else if (scene.isDark == false && player.flash.isFlashOn == false) // doNothing
            }
        }
    }
}
