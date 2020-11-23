using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Scene_Helper
    {
        public static void Update(IScene scene)
        {
            Player player = scene.entities.First(x => x.tag == "player") as Player;
            Map map = scene.entities.First(x => x.tag == "map") as Map;
            List<Inpc> NPCs = scene.entities.Where(x => x.tag == "npc").Select(x => x as Inpc).ToList();
            List<Portal> portals = scene.entities.Where(x => x.tag == "portal").Select(x => x as Portal).ToList();
            Dialog dialog = scene.entities.FirstOrDefault(x => x.tag == "dialog") as Dialog;

            scene.camera.Update(player);

            foreach (var npc in NPCs) NPCHelpers.Update(npc, player, scene);

            // if dialog, dont update player
            if (dialog != null)
                Dialog_Helper.Update(dialog, scene);
            else
                PlayerHelpers.Update(scene);


            foreach (var portal in portals) PortalHelpers.Update(portal, player);
            MapHelpers.Update();
        }

        public static void Draw(SpriteBatch spriteBatch, IScene scene)
        {
            Player player = scene.entities.First(x => x.tag == "player") as Player;
            Map map = scene.entities.First(x => x.tag == "map") as Map;
            List<Inpc> NPCs = scene.entities.Where(x => x.tag == "npc").Select(x => x as Inpc).ToList();
            List<Portal> portals = scene.entities.Where(x => x.tag == "portal").Select(x => x as Portal).ToList();
            Dialog dialog = scene.entities.FirstOrDefault(x => x.tag == "dialog") as Dialog;

            scene.camera.Draw(spriteBatch);

            MapHelpers.Draw(spriteBatch, map.tiles);
            PlayerHelpers.Draw(spriteBatch, player);

            foreach (var npc in NPCs) NPCHelpers.Draw(spriteBatch, npc);
            foreach (var portal in portals) PortalHelpers.Draw(spriteBatch, portal);

            if (dialog != null) Dialog_Helper.Draw(spriteBatch, dialog);
        }
    }
}
