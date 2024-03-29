﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shared
{
    public class GameScene : IScene
    {
        public List<IEntity> entities { get; set; }
        public Camera camera { get; set; }
        public int moneyValue { get; set; }
        public MoneyText moneyText { get; set; }
        public bool isDark { get; set; }

        public void Initialize(Point startPlayerPosition)
        {
            this.isDark = false;

            this.moneyText = new MoneyText("", new Vector2(0, 0));
            this.moneyValue = 0;


            // Populate entities
            this.entities = new List<IEntity>()
            {
                // Add Player
                new Player(startPlayerPosition, Layer.Middle),

                // Add NPCs
                new NPC_1(new Point(8, 15), Layer.Middle),

                // add Portals
                new Portal(new Point(7, 13), WK.Scene.House_1, new Point(4, 12), Layer.Back),
                new Portal(new Point(6, 8), WK.Scene.Cave, new Point(4, 12), Layer.Back),

                // Add Coins
                new Coin(true, new Point(10, 13), Layer.Middle),

                // Add cube
                new Cube_1(new Point(10, 17), Layer.Middle),

                // Add Cards
                new Card_0(new Point(1, 1), Layer.Front),
            };


            // Add Map
            this.entities.AddRange(MapHelper.PopulateMap(WK.Map.Map1));

            camera = new Camera();
        }
    }
}
