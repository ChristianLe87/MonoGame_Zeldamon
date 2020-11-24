﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shared
{
    public class House_1 : IScene
    {
        public Camera camera { get; set; }
        public List<IEntity> entities { get; set; }
        public int moneyValue { get; set; }
        public Text moneyText { get; set; }

        public void Initialize(Point startPlayerPosition)
        {
            this.moneyText = new Text("Coins: 0", new Vector2(0, 0));
            this.moneyValue = 0;

            this.entities = new List<IEntity>()
            {
                new Player(startPlayerPosition,"player"),
                new NPC_2(new Point(3, 11), "npc"),
                new Portal(new Point(4, 13), WK.Scene.GameScene, new Point(7, 14), "portal"),
                new Map(WK.Map.Map2, "map")
            };

            this.camera = new Camera();
        }
    }
}