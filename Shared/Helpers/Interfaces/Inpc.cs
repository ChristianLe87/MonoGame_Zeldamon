using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface Inpc : IEntity
    {
        NPC_State npcState { get; set; }
        Dictionary<string, Texture2D> textures { get; }
        Rectangle triggerArea { get; }
        string[] text { get; }
    }
}