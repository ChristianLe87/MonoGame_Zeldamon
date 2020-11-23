using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface Inpc : IEntity
    {
        public NPC_State npcState { get; set; }
        public Dictionary<string, Texture2D> textures { get; }
        public Rectangle rectangle { get; set; }
        public Rectangle triggerArea { get; set; }
        public string[] text { get; set; }
    }
}
