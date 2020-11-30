﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class SceneHelper
    {
        public static void Update(IScene scene)
        {
            Player player = scene.entities.OfType<Player>().First();
            List<NPC> NPCs = scene.entities.OfType<NPC>().ToList();
            List<Portal> portals = scene.entities.OfType<Portal>().ToList();
            Dialog dialog = scene.entities.OfType<Dialog>().FirstOrDefault();
            List<Coin> pickables = scene.entities.OfType<Coin>().Where(x => x.isActive == true).ToList();
            List<PointsFeedback> my_PointFeedbacks = scene.entities.OfType<PointsFeedback>().ToList();

            CameraHelper.Update(scene.camera, player);

            foreach (var npc in NPCs) NPCHelper.Update(npc, player, scene);
            foreach (var pickable in pickables) CoinHelper.Update(scene, pickable);
            foreach (var fed in my_PointFeedbacks) PointsFeedbackHelper.Update(fed);


            // if dialog, dont update player
            if (dialog != null)
                DialogHelper.Update(dialog, scene);
            else
                PlayerHelper.Update(scene);

            foreach (var portal in portals) PortalHelpers.Update(portal, player);

            TextHelper.Update(scene.moneyText, $"Money: {player.money}");
        }

        public static void Draw(SpriteBatch spriteBatch, IScene scene)
        {
            Player player = scene.entities.OfType<Player>().First();
            List<Tile> tiles = scene.entities.OfType<Tile>().ToList();
            List<NPC> NPCs = scene.entities.OfType<NPC>().ToList();
            List<Portal> portals = scene.entities.OfType<Portal>().ToList();
            Dialog dialog = scene.entities.OfType<Dialog>().FirstOrDefault();
            List<IPickable> pickables = scene.entities.OfType<IPickable>().Where(x => x.isActive == true).ToList();
            List<PointsFeedback> my_PointFeedbacks = scene.entities.OfType<PointsFeedback>().ToList();

            CameraHelper.Draw(spriteBatch, scene.camera);

            MapHelper.Draw(spriteBatch, tiles);
            PlayerHelper.Draw(spriteBatch, player);

            foreach (var pickable in pickables) CoinHelper.Draw(spriteBatch, pickable);
            foreach (var npc in NPCs) NPCHelper.Draw(spriteBatch, npc);
            foreach (var portal in portals) PortalHelpers.Draw(spriteBatch, portal);
            foreach (var pickable in pickables) CoinHelper.Draw(spriteBatch, pickable);
            foreach (var fed in my_PointFeedbacks) PointsFeedbackHelper.Draw(spriteBatch, fed);

            FlashHelper.Draw(spriteBatch,scene);
            if (dialog != null) DialogHelper.Draw(spriteBatch, dialog);
            TextHelper.Draw(spriteBatch, scene.moneyText);
        }
    }
}
