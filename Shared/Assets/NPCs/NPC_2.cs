using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class NPC_2 : Inpc
    {
        public Dictionary<string, Texture2D> textures { get; private set; }
        public NPC_State npcState { get; set; }
        public Rectangle rectangle { get; set; }
        public string tag { get; private set; }
        public Rectangle triggerArea { get; set; }

        public NPC_2(Point position, string tag)
        {
            this.npcState = NPC_State.IdleDown;
            this.tag = tag;

            this.textures = new Dictionary<string, Texture2D>()
            {
                {"texture_IdleUp",  Tools.GetTexture(WK.Content.Texture.Player.Idle_Up) },
                {"texture_IdleDown", Tools.GetTexture(WK.Content.Texture.Player.Idle_Down) },
                {"texture_IdleRight",  Tools.GetTexture(WK.Content.Texture.Player.Idle_Right) },
                {"texture_IdleLeft",  Tools.GetTexture(WK.Content.Texture.Player.Idle_Left) }
            };

            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
        }
    }
}
