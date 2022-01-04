using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shared
{
    public class NPCHelper
    {
        public static void Update(Inpc npc, Player player, IScene scene)
        {
            RotateToPlayer(player, npc);
            Trigger(scene, npc);
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

        private static void RotateToPlayer(Player player, Inpc npc)
        {
            int y = player.rectangle.Y - npc.rectangle.Y;
            if(y == 0)
            {
                if(player.rectangle.X< npc.rectangle.X)
                {
                    npc.npcState = NPC_State.IdleLeft;
                }
                else
                {
                    npc.npcState = NPC_State.IdleRight;
                }
            }

            int x = player.rectangle.X - npc.rectangle.X;
            if(x == 0)
            {
                if (player.rectangle.Y > npc.rectangle.Y)
                {
                    npc.npcState = NPC_State.IdleDown;
                }
                else
                {
                    npc.npcState = NPC_State.IdleUp;
                }
            }
        }

        private static void Trigger(IScene scene, Inpc npc)
        {
            Player player = scene.entities.OfType<Player>().First();

            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                if (npc.triggerArea.Intersects(player.rectangle))
                {
                       if (scene.entities.OfType<Dialog>().Count() == 0)
                    {
                        var x = player.rectangle.X - (WK.Default.CanvasWidth / 2) + (WK.Default.Pixels_X / 2);
                        var y = player.rectangle.Y + (WK.Default.CanvasHeight / 2) - (WK.Default.CanvasHeight / 3) + (WK.Default.Pixels_Y / 2);

                        scene.entities.Add(new Dialog(npc, new Rectangle(x, y, WK.Default.CanvasWidth, (WK.Default.CanvasHeight / 3))));
                    }
                }
            }
        }
    }
}