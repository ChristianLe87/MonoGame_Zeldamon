using System;
using System.Collections.Generic;
using ChristianTools.Helpers;
using ChristianTools.UI;
using Microsoft.Xna.Framework;

namespace Shared
{
    public class Helpers
    {
        public static List<IUI> GetGameUI()
        {
            List<IUI> UIs = new List<IUI>();
            UIs.Add(new Label(new Rectangle(0, 0, 16, 16), WK.Font.MyFont, "coin", Label.TextAlignment.Top_Left, "coin"));


            if (ChristianGame.gameData.key1_ui_isVisible == true)
            {
                UIs.Add(new Image(texture: WK.Textures.Other.key, new Vector2(40, 20), "key1"));
            }

            if (ChristianGame.gameData.hammer_ui_isVisible == true)
            {
                UIs.Add(new Image(texture: WK.Textures.Other.hammer, new Vector2(20, 20), "hammer"));
            }


            return UIs;
        }
    }



}