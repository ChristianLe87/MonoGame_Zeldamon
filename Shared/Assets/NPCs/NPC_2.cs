﻿using System.Collections.Generic;
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
        public Layer layer { get; }

        public NPC_2(Point position, Layer layer, string tag)
        {
            this.npcState = NPC_State.IdleDown;
            this.tag = tag;
            this.layer = layer;

            this.textures = new Dictionary<string, Texture2D>()
            {
                { "texture_IdleUp",  Tools.GetSubtextureFromAtlasTexture(new Point(1, 4)) },
                { "texture_IdleDown" , Tools.GetSubtextureFromAtlasTexture(new Point(1, 1)) },
                { "texture_IdleRight" , Tools.GetSubtextureFromAtlasTexture(new Point(1, 3)) },
                { "texture_IdleLeft" , Tools.GetSubtextureFromAtlasTexture(new Point(1, 2)) },
            };

            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);

            this.text = new string[] { "Good By", "Christian" };
        }
    }
}
