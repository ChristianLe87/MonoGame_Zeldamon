using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class House_1 : IScene
    {
        Camera camera;

        Map map;
        Player player;
        List<Portal> portals;
        List<NPC> NPCs;

        public void Initialize(Point startPlayerPosition)
        {
            this.map = new Map(WK.Map.Map2);
            this.player = new Player(startPlayerPosition,"player");
            this.camera = new Camera();

            this.portals = new List<Portal>()
            {
                new Portal(player, new Point(4 * WK.Default.Pixels_Y, 13 * WK.Default.Pixels_Y), WK.Scene.GameScene, new Point(7 * WK.Default.Pixels_X, 14 * WK.Default.Pixels_Y), "portal")
            };

            this.NPCs = new List<NPC>()
            {
                new NPC(new Point(3, 11), "npc")
            };
        }

        public void Update()
        {
            camera.Update(player);

            MapHelpers.Update();

            
            var npcRectangles = NPCs.Select(x => x.rectangle).ToList();
            var mapRectangles = map.tiles.Where(x=>x.tag == "x").Select(x=>x.rectangle).ToList();
            List<Rectangle> rectangles = npcRectangles.Concat(mapRectangles).ToList();

            PlayerHelpers.Update(rectangles, player);

            foreach (var portal in portals) PortalHelpers.Update(portal, player);
            foreach (var npc in NPCs) NPCHelpers.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            camera.Draw(spriteBatch);

            MapHelpers.Draw(spriteBatch, map.tiles);

            PlayerHelpers.Draw(spriteBatch, player);

            foreach (var portal in portals) PortalHelpers.Draw(spriteBatch, portal);
            foreach (var npc in NPCs) NPCHelpers.Draw(spriteBatch, npc);
        }
    }
}