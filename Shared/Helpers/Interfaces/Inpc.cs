using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface Inpc
    {
        NPC_State npcState { get; }
        Dictionary<string, Texture2D> textures { get; }
        Rectangle rectangle { get; }
        Rectangle triggerArea { get; }
        string[] text { get; }
    }
}