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
        public string[] text { get; set; }

        public NPC_2(Point position, string tag)
        {
            this.npcState = NPC_State.IdleDown;
            this.tag = tag;

            this.textures = new Dictionary<string, Texture2D>()
            {
                {"texture_IdleUp",  Tools.GetTexture(WK.Content.Texture.Player.Idle_Up, WK.Content.Folder.Player) },
                {"texture_IdleDown", Tools.GetTexture(WK.Content.Texture.Player.Idle_Down, WK.Content.Folder.Player) },
                {"texture_IdleRight",  Tools.GetTexture(WK.Content.Texture.Player.Idle_Right, WK.Content.Folder.Player) },
                {"texture_IdleLeft",  Tools.GetTexture(WK.Content.Texture.Player.Idle_Left, WK.Content.Folder.Player) }
            };

            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);

            this.text = new string[] { "Good By", "Christian" };
        }
    }
}
