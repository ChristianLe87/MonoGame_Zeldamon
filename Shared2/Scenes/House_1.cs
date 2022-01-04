using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shared
{
    public class House_1 : IScene
    {
        public List<IEntity> entities { get; set; }
        public Camera camera { get; set; }
        public int moneyValue { get; set; }
        public MoneyText moneyText { get; set; }
        public bool isDark { get; set; }

        public void Initialize(Point startPlayerPosition)
        {
            this.isDark = false;
            this.moneyText = new MoneyText("Coins: 0", new Vector2(0, 0));
            this.moneyValue = 0;

            this.entities = new List<IEntity>()
            {
                new Player(startPlayerPosition, Layer.Middle),
                new NPC_2(new Point(3, 11), Layer.Middle),
                new Portal(new Point(4, 13), WK.Scene.GameScene, new Point(7, 14), Layer.Back),
            };

            this.entities.AddRange(MapHelper.PopulateMap(WK.Map.Map2));

            this.camera = new Camera();
        }
    }
}