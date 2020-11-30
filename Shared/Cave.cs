using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shared
{
    public class Cave : IScene
    {
        public Camera camera { get; set; }
        public List<IEntity> entities { get; set; }
        public int moneyValue { get; set; }
        public Text moneyText { get; set; }
        public bool isDark { get; private set; }

        public void Initialize(Point startPlayerPosition)
        {
            this.isDark = true;
            this.moneyText = new Text("Coins: 0", new Vector2(0, 0), "text", Layer.Front);
            this.moneyValue = 0;

            this.entities = new List<IEntity>()
            {
                new Player(startPlayerPosition, Layer.Middle, "player"),
                new Portal(new Point(4, 13), WK.Scene.GameScene, new Point(6, 9), "portal"),
            };

            this.entities.AddRange(MapHelper.PopulateMap(WK.Map.Cave));

            this.camera = new Camera();
        }
    }
}
