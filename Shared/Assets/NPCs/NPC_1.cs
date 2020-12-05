using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class NPC_1 : NPC
    {
        public override NPC_State npcState { get; set; }
        public override Dictionary<string, Texture2D> textures { get; set; }
        public override Rectangle rectangle { get; set; }
        public override Rectangle triggerArea { get; set; }
        public override string[] text { get; set; }

        public NPC_1(Point position, Layer layer)
        {
            this.layer = layer;
            this.text = new string[] { "Hello", "World" };
            this.npcState = NPC_State.IdleDown;

            this.textures = new Dictionary<string, Texture2D>()
            {
                { "texture_IdleUp",  Tools.GetSubtextureFromAtlasTexture(new Point(1, 4)) },
                { "texture_IdleDown" , Tools.GetSubtextureFromAtlasTexture(new Point(1, 1)) },
                { "texture_IdleRight" , Tools.GetSubtextureFromAtlasTexture(new Point(1, 3)) },
                { "texture_IdleLeft" , Tools.GetSubtextureFromAtlasTexture(new Point(1, 2)) },
            };

            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
            this.triggerArea = new Rectangle(position.X * WK.Default.Pixels_X -1, position.Y * WK.Default.Pixels_Y -1, WK.Default.Pixels_X + 2, WK.Default.Pixels_Y + 2);
        }
    }
}