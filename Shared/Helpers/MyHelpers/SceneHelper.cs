using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class SceneHelper
    {
        public static void Update(IScene scene)
        {
            Player player = scene.entities.OfType<Player>().First();
            //List<Tile> tiles = scene.entities.OfType<Tile>().ToList();
            List<Inpc> NPCs = scene.entities.OfType<Inpc>().ToList();
            List<Portal> portals = scene.entities.OfType<Portal>().ToList();
            Dialog dialog = scene.entities.OfType<Dialog>().FirstOrDefault();
            List<IPickable> pickables = scene.entities.OfType<IPickable>().Where(x => x.isActive == true).ToList();

            scene.camera.Update(player);

            foreach (var npc in NPCs) NPCHelper.Update(npc, player, scene);
            foreach (var pickable in pickables) CoinHelper.Update(player, pickable);
            foreach (var pickable in pickables) CoinHelper.Update(player, pickable);


            // if dialog, dont update player
            if (dialog != null)
                DialogHelper.Update(dialog, scene);
            else
                PlayerHelper.Update(scene);

            foreach (var portal in portals) PortalHelpers.Update(portal, player);

            scene.moneyText.Update($"Money: {player.money}");
        }

        public static void Draw(SpriteBatch spriteBatch, IScene scene)
        {
            Player player = scene.entities.OfType<Player>().First();
            List<Tile> tiles = scene.entities.OfType<Tile>().ToList();
            List<Inpc> NPCs = scene.entities.OfType<Inpc>().ToList();
            List<Portal> portals = scene.entities.OfType<Portal>().ToList();
            Dialog dialog = scene.entities.OfType<Dialog>().FirstOrDefault();
            List<IPickable> pickables = scene.entities.OfType<IPickable>().Where(x => x.isActive == true).ToList();
            scene.camera.Draw(spriteBatch);

            MapHelper.Draw(spriteBatch, tiles);
            PlayerHelper.Draw(spriteBatch, player);

            foreach (var pickable in pickables) CoinHelper.Draw(spriteBatch, pickable);
            foreach (var npc in NPCs) NPCHelper.Draw(spriteBatch, npc);
            foreach (var portal in portals) PortalHelpers.Draw(spriteBatch, portal);
            foreach (var pickable in pickables) CoinHelper.Draw(spriteBatch, pickable);
            FlashHelper.Draw(spriteBatch,scene);
            if (dialog != null) DialogHelper.Draw(spriteBatch, dialog);
            scene.moneyText.Draw(spriteBatch);
        }
    }
}
