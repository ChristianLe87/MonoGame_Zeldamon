using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shared
{
    public class Cave : Scene
    {
        public override Camera camera { get; set; }
        public override List<IEntity> entities { get; set; }
        public override int moneyValue { get; set; }
        public override Text moneyText { get; set; }
        public override bool isDark { get; set; }

        public override void Initialize(Point startPlayerPosition)
        {
            this.isDark = true;
            this.moneyText = new Text("Coins: 0", new Vector2(0, 0));
            this.moneyValue = 0;

            this.entities = new List<IEntity>()
            {
                new Player(startPlayerPosition),
                new Portal(new Point(4, 13), WK.Scene.GameScene, new Point(6, 9)),
            };

            this.entities.AddRange(MapHelper.PopulateMap(WK.Map.Cave));

            this.camera = new Camera();
        }
    }
}