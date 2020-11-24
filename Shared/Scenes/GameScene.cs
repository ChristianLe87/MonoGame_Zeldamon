using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
                new Portal(new Point(7 * WK.Default.Pixels_X, 13 * WK.Default.Pixels_Y), WK.Scene.House_1, new Point(4 * WK.Default.Pixels_Y, 12 * WK.Default.Pixels_Y), "portal"),
                new Map(WK.Map.Map1, "map"),
                new Coin("coin", true, new Point(10,13))
            };

            camera = new Camera();
        }
    }
}
