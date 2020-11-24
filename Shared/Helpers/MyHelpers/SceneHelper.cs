using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class SceneHelper
    {
        public static void Update(IScene scene)
        {
            Player player = scene.entities.First(x => x.tag == "player") as Player;
            Map map = scene.entities.First(x => x.tag == "map") as Map;
            List<Inpc> NPCs = scene.entities.Where(x => x.tag == "npc").Select(x => x as Inpc).ToList();
            List<Portal> portals = scene.entities.Where(x => x.tag == "portal").Select(x => x as Portal).ToList();
            Dialog dialog = scene.entities.FirstOrDefault(x => x.tag == "dialog") as Dialog;
            List<IPickable> pickables = scene.entities.Where(x => x.tag == "coin").Select(x => x as IPickable).Where(x => x.isActive == true).ToList();

            scene.camera.Update(player);

            foreach (var npc in NPCs) NPCHelpers.Update(npc, player, scene);
            foreach (var pickable in pickables) CoinHelper.Update(player, pickable);
            foreach (var pickable in pickables) CoinHelper.Update(player, pickable);


            // if dialog, dont update player
            if (dialog != null)
                DialogHelper.Update(dialog, scene);
            else
                PlayerHelpers.Update(scene);

            foreach (var portal in portals) PortalHelpers.Update(portal, player);
            scene.moneyText.Update($"Money: {player.money}");

            MapHelpers.Update();
        }

        public static void Draw(SpriteBatch spriteBatch, IScene scene)
        {
            Player player = scene.entities.First(x => x.tag == "player") as Player;
            Map map = scene.entities.First(x => x.tag == "map") as Map;
            List<Inpc> NPCs = scene.entities.Where(x => x.tag == "npc").Select(x => x as Inpc).ToList();
            List<Portal> portals = scene.entities.Where(x => x.tag == "portal").Select(x => x as Portal).ToList();
            Dialog dialog = scene.entities.FirstOrDefault(x => x.tag == "dialog") as Dialog;
            List<IPickable> pickables = scene.entities.Where(x => x.tag == "coin").Select(x => x as IPickable).Where(x=>x.isActive == true).ToList();


            scene.camera.Draw(spriteBatch);

            MapHelpers.Draw(spriteBatch, map.tiles);
            PlayerHelpers.Draw(spriteBatch, player);

            foreach (var pickable in pickables) CoinHelper.Draw(spriteBatch, pickable);
            foreach (var npc in NPCs) NPCHelpers.Draw(spriteBatch, npc);
            foreach (var portal in portals) PortalHelpers.Draw(spriteBatch, portal);
            foreach (var pickable in pickables) CoinHelper.Draw(spriteBatch, pickable);

            if (dialog != null) DialogHelper.Draw(spriteBatch, dialog);
            scene.moneyText.Draw(spriteBatch);
        }
    }
}
