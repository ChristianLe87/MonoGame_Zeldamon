using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Flash : IEntity
    {
        public Dictionary<string, Texture2D> flashTextures;
        public bool isFlashOn { get; set; }

        public Layer layer { get; }

        public Rectangle rectangle { get; set; }

        public bool isFlashKeyRelease;

        public Flash()
        {
            this.isFlashOn = false;
            this.isFlashKeyRelease = true;

            this.flashTextures = new Dictionary<string, Texture2D>()
            {
                { WK.Content.Texture.Flash.FlashDayOn_Down_720x720_PNG, Tools.GetTexture(WK.Content.Texture.Flash.FlashDayOn_Down_720x720_PNG, WK.Content.Folder.Flash) },
                { WK.Content.Texture.Flash.FlashDayOn_Left_720x720_PNG, Tools.GetTexture(WK.Content.Texture.Flash.FlashDayOn_Left_720x720_PNG, WK.Content.Folder.Flash) },
                { WK.Content.Texture.Flash.FlashDayOn_Right_720x720_PNG, Tools.GetTexture(WK.Content.Texture.Flash.FlashDayOn_Right_720x720_PNG, WK.Content.Folder.Flash) },
                { WK.Content.Texture.Flash.FlashDayOn_Up_720x720_PNG, Tools.GetTexture(WK.Content.Texture.Flash.FlashDayOn_Up_720x720_PNG, WK.Content.Folder.Flash) },
                { WK.Content.Texture.Flash.FlashNightOff_720x720_PNG, Tools.GetTexture(WK.Content.Texture.Flash.FlashNightOff_720x720_PNG, WK.Content.Folder.Flash) },
                { WK.Content.Texture.Flash.FlashNightOn_Down_720x720_PNG, Tools.GetTexture(WK.Content.Texture.Flash.FlashNightOn_Down_720x720_PNG, WK.Content.Folder.Flash) },
                { WK.Content.Texture.Flash.FlashNightOn_Left_720x720_PNG, Tools.GetTexture(WK.Content.Texture.Flash.FlashNightOn_Left_720x720_PNG, WK.Content.Folder.Flash) },
                { WK.Content.Texture.Flash.FlashNightOn_Up_720x720_PNG, Tools.GetTexture(WK.Content.Texture.Flash.FlashNightOn_Up_720x720_PNG, WK.Content.Folder.Flash) },
                { WK.Content.Texture.Flash.FlashNightOn_Right_720x720_PNG, Tools.GetTexture(WK.Content.Texture.Flash.FlashNightOn_Right_720x720_PNG, WK.Content.Folder.Flash) }
            };
        }
    }
}