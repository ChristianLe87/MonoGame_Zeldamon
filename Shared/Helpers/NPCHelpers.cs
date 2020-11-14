using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class NPCHelpers
    {
        public static void Update()
        {
            // Face player
        }

        public static void Draw(SpriteBatch spriteBatch, Inpc npc)
        {
            switch (npc.npcState)
            {
                case NPC_State.IdleUp:
                    spriteBatch.Draw(npc.textures["texture_IdleUp"], npc.rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                case NPC_State.IdleDown:
                    spriteBatch.Draw(npc.textures["texture_IdleDown"], npc.rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                case NPC_State.IdleRight:
                    spriteBatch.Draw(npc.textures["texture_IdleRight"], npc.rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                case NPC_State.IdleLeft:
                    spriteBatch.Draw(npc.textures["texture_IdleLeft"], npc.rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                default:
                    break;
            }
        }

        public static void Trigger()
        {
            Console.WriteLine("Hello");
        }
    }

    public enum NPC_State
    {
        IdleUp,
        IdleDown,
        IdleRight,
        IdleLeft
    }
}