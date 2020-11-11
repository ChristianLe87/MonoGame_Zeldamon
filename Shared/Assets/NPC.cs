using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class NPC
    {
        Texture2D texture_IdleUp;
        Texture2D texture_IdleDown;
        Texture2D texture_IdleRight;
        Texture2D texture_IdleLeft;

        NPC_State npcState = NPC_State.IdleDown;

        Rectangle rectangle;

        public NPC(Point position)
        {
            this.texture_IdleUp = Tools.GetTexture(WK.Content.Texture.Player.Idle_Up);
            this.texture_IdleDown = Tools.GetTexture(WK.Content.Texture.Player.Idle_Down);
            this.texture_IdleRight = Tools.GetTexture(WK.Content.Texture.Player.Idle_Right);
            this.texture_IdleLeft = Tools.GetTexture(WK.Content.Texture.Player.Idle_Left);

            this.rectangle = new Rectangle(position.X * WK.Default.Pixels_X, position.Y * WK.Default.Pixels_Y, WK.Default.Pixels_X, WK.Default.Pixels_Y);
        }

        public void Update()
        {
            // Face player
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (npcState)
            {
                case NPC_State.IdleUp:
                    spriteBatch.Draw(texture_IdleUp, rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                case NPC_State.IdleDown:
                    spriteBatch.Draw(texture_IdleDown, rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                case NPC_State.IdleRight:
                    spriteBatch.Draw(texture_IdleRight, rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                case NPC_State.IdleLeft:
                    spriteBatch.Draw(texture_IdleLeft, rectangle, new Rectangle(0, 0, 16, 16), Color.White);
                    break;
                default:
                    break;
            }
        }

        public void Trigger()
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
