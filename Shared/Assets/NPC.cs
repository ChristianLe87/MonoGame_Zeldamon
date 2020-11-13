using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class NPC
    {
        public Dictionary<string, Texture2D> textures;

        public NPC_State npcState = NPC_State.IdleDown;

        public Rectangle rectangle { get; private set; }

        public string tag { get; private set; }

        public NPC(Point position, string tag)
        {
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

    public class NPCHelpers
    {
        public static void Update()
        {
            // Face player
        }

        public static void Draw(SpriteBatch spriteBatch, NPC npc)
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
