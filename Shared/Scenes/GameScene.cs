using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameScene : IScene
    {
        Camera camera;
        public List<IEntity> entities { get; set; }

        public void Initialize(Point startPlayerPosition)
        {
            this.entities = new List<IEntity>()
            {
                new Player(startPlayerPosition, "player", this),
                new NPC_1(new Point(8, 15), "npc"),
                new Portal(new Point(7 * WK.Default.Pixels_X, 13 * WK.Default.Pixels_Y), WK.Scene.House_1, new Point(4 * WK.Default.Pixels_Y, 12 * WK.Default.Pixels_Y), "portal"),
                new Map(WK.Map.Map1, "map1")
            };

            camera = new Camera();
        }

        public void Update()
        {
            Player player = entities.First(x => x.tag == "player") as Player;
            Map map = entities.First(x => x.tag == "map1") as Map;
            List<Inpc> NPCs = entities.Where(x => x.tag == "npc").Select(x=>x as Inpc).ToList();
            List<Portal> portals = entities.Where(x => x.tag == "portal").Select(x => x as Portal).ToList();
            List<Dialog> dialogs = entities.Where(x => x.tag == "dialog").Select(x => x as Dialog).ToList();

            camera.Update(player);

            MapHelpers.Update();
            PlayerHelpers.Update(player);

            foreach (var portal in portals) PortalHelpers.Update(portal, player);
            foreach (var dialog in dialogs) dialog.Update(player, new string[] { $"X: {player.rectangle.X}\nY:{player.rectangle.Y}" });
            foreach (var npc in NPCs) NPCHelpers.Update(npc, player, this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Player player = entities.First(x => x.tag == "player") as Player;
            Map map = entities.First(x => x.tag == "map1") as Map;
            List<Inpc> NPCs = entities.Where(x => x.tag == "npc").Select(x => x as Inpc).ToList();
            List<Portal> portals = entities.Where(x => x.tag == "portal").Select(x => x as Portal).ToList();
            List<Dialog> dialogs = entities.Where(x => x.tag == "dialog").Select(x => x as Dialog).ToList();

            camera.Draw(spriteBatch);

            MapHelpers.Draw(spriteBatch,map.tiles);
            PlayerHelpers.Draw(spriteBatch, player);

            foreach (var npc in NPCs) NPCHelpers.Draw(spriteBatch, npc);
            foreach (var portal in portals) PortalHelpers.Draw(spriteBatch, portal);
            foreach (var dialog in dialogs) dialog.Draw(spriteBatch);
        }
    }
}
