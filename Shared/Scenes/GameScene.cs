using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameScene : IScene
    {
        Camera camera;

        Map map;
        Player player;

        List<Portal> portals;
        List<NPC> NPCs;

        Dialog dialog;

        public void Initialize(Point startPlayerPosition)
        {
            map = new Map(WK.Map.Map1);
            player = new Player(startPlayerPosition, "player");
            camera = new Camera();

            portals = new List<Portal>()
            {
                new Portal(player, new Point(7 * WK.Default.Pixels_X, 13 * WK.Default.Pixels_Y), WK.Scene.House_1, new Point(4 * WK.Default.Pixels_Y, 12 * WK.Default.Pixels_Y), "portal")
            };

            this.NPCs = new List<NPC>()
            {
                //new NPC(new Point(3, 11), "npc")
            };

            dialog = new Dialog(new string[] { "dfsafdsa" }, new Rectangle(0, 0, WK.Default.CanvasWidth, (WK.Default.CanvasHeight / 3)));
        }

        public void Update()
        {
            
            var npcRectangles = NPCs.Select(x => x.rectangle).ToList();
            var mapRectangles = map.tiles.Where(x => x.tag == "x").Select(x => x.rectangle).ToList();

            List<Rectangle> rectangles = npcRectangles.Concat(mapRectangles).ToList();

            camera.Update(player);

            MapHelpers.Update();
            PlayerHelpers.Update(rectangles, player);

            foreach (var portal in portals) PortalHelpers.Update(portal, player);

            dialog.Update(player, new string[] { $"X: {player.rectangle.X}\nY:{player.rectangle.Y}" });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            camera.Draw(spriteBatch);

            MapHelpers.Draw(spriteBatch,map.tiles);
            PlayerHelpers.Draw(spriteBatch, player);

            foreach (var portal in portals) PortalHelpers.Draw(spriteBatch, portal);

            dialog.Draw(spriteBatch);
        }
    }
}
