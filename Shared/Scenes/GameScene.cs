using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameScene : IScene
    {
        Camera camera;
        List<IEntity> entities;

        public void Initialize(Point startPlayerPosition)
        {
            this.entities = new List<IEntity>()
            {
                new Player(startPlayerPosition, "player"),
                //new NPC(new Point(3, 11), "npc")
                new Portal(new Point(7 * WK.Default.Pixels_X, 13 * WK.Default.Pixels_Y), WK.Scene.House_1, new Point(4 * WK.Default.Pixels_Y, 12 * WK.Default.Pixels_Y), "portal"),
                new Dialog(new string[] { "dfsafdsa" }, new Rectangle(0, 0, WK.Default.CanvasWidth, (WK.Default.CanvasHeight / 3)), "dialog"),
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
            PlayerHelpers.Update(entities, player);

            foreach (var portal in portals) PortalHelpers.Update(portal, player);
            foreach (var dialog in dialogs) dialog.Update(player, new string[] { $"X: {player.rectangle.X}\nY:{player.rectangle.Y}" });
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

            foreach (var portal in portals) PortalHelpers.Draw(spriteBatch, portal);
            foreach (var dialog in dialogs) dialog.Draw(spriteBatch);
        }
    }
}
