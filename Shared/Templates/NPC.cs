using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public abstract class NPC : Inpc, IEntity
    {
        public abstract NPC_State npcState { get; set; }
        public abstract Dictionary<string, Texture2D> textures { get; set; }
        public abstract Rectangle rectangle { get; set; }
        public abstract Rectangle triggerArea { get; set; }
        public abstract string[] text { get; set; }
        public string tag { get; set; }
        public Layer layer { get; set; }
        public Texture2D texture { get; set; }
    }
}