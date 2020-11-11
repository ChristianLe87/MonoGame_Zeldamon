using System;
using System.Collections.Generic;
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
            map = new Map(WK.Map.Map2);
            player = new Player(startPlayerPosition);
            camera = new Camera();

            portals = new List<Portal>()
            {
                new Portal(new Point(4 * WK.Default.Pixels_Y, 13 * WK.Default.Pixels_Y), WK.Scene.GameScene, new Point(7 * WK.Default.Pixels_X, 14 * WK.Default.Pixels_Y))
            };

            NPCs = new List<NPC>()
            {
                new NPC(new Point(3, 11))
            };
        }

        public void Update()
        {
            camera.Update(player);

            map.Update();
            player.Update(map);

            foreach (var portal in portals) portal.Update(player);
            foreach (var npc in NPCs) npc.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            camera.Draw(spriteBatch);

            map.Draw(spriteBatch);
            player.Draw(spriteBatch);

            foreach (var portal in portals) portal.Draw(spriteBatch);
            foreach (var npc in NPCs) npc.Draw(spriteBatch);
        }
    }
}