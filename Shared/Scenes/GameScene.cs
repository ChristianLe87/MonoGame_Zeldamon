using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shared
{
    public class GameScene : IScene
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
                new Player(startPlayerPosition, "player"),
                new NPC_1(new Point(8, 15), "npc"),
                new Portal(new Point(7, 13), WK.Scene.House_1, new Point(4,12), "portal"),
                new Map(WK.Map.Map1, "map"),
                new Coin("coin", true, new Point(10, 13))
            };

            camera = new Camera();
        }
    }
}
