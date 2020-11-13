
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class House_1 : IScene
    {
        Camera camera;
        List<IEntity> entities;

        public void Initialize(Point startPlayerPosition)
        {
            this.entities = new List<IEntity>()
            {
                new Player(startPlayerPosition,"player"),
                new NPC_2(new Point(3, 11), "npc"),
                new Portal(new Point(4 * WK.Default.Pixels_Y, 13 * WK.Default.Pixels_Y), WK.Scene.GameScene, new Point(7 * WK.Default.Pixels_X, 14 * WK.Default.Pixels_Y), "portal"),
                new Map(WK.Map.Map2, "map2")
            };

            this.camera = new Camera();
        }

        public void Update()
        {
            Player player = entities.First(x => x.tag == "player") as Player;
            Map map = entities.First(x => x.tag == "map2") as Map;
            List<Inpc> NPCs = entities.Where(x => x.tag == "npc").Select(x => x as Inpc).ToList(); ;
            List<Portal> portals = entities.Where(x => x.tag == "portal").Select(x => x as Portal).ToList();

            camera.Update(player);

            MapHelpers.Update();

            PlayerHelpers.Update(entities, player);

            foreach (var portal in portals) PortalHelpers.Update(portal, player);
            foreach (var npc in NPCs) NPCHelpers.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Player player = entities.First(x => x.tag == "player") as Player;
            Map map = entities.First(x => x.tag == "map2") as Map;
            List<Inpc> NPCs = entities.Where(x => x.tag == "npc").Select(x => x as Inpc).ToList();
            List<Portal> portals = entities.Where(x => x.tag == "portal").Select(x => x as Portal).ToList();

            camera.Draw(spriteBatch);

            MapHelpers.Draw(spriteBatch, map.tiles);

            PlayerHelpers.Draw(spriteBatch, player);

            foreach (var portal in portals) PortalHelpers.Draw(spriteBatch, portal);
            foreach (var npc in NPCs) NPCHelpers.Draw(spriteBatch, npc);
        }
    }
}