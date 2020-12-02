using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Shared
{
    public class GameScene : Scene
    {
        public override Camera camera { get; set; }
        public override List<IEntity> entities { get; set; }
        public override int moneyValue { get; set; }
        public override Text moneyText { get; set; }
        public override bool isDark { get; set; }

        public override void Initialize(Point startPlayerPosition)
        {
            this.isDark = false;

            this.moneyText = new Text("", new Vector2(0, 0));
            this.moneyValue = 0;


            // Populate entities
            this.entities = new List<IEntity>()
            {
                // Add Player
                new Player(startPlayerPosition),

                // Add NPCs
                new NPC_1(new Point(8, 15)),

                // add Portals
                new Portal(new Point(7, 13), WK.Scene.House_1, new Point(4, 12)),
                new Portal(new Point(6, 8), WK.Scene.Cave, new Point(4, 12)),

                // Add Coins
                new Coin(true, new Point(10, 13)),

                // Add cube
                new Cube(new Point(10, 17)),
            };


            // Add Map
            this.entities.AddRange(MapHelper.PopulateMap(WK.Map.Map1));

            camera = new Camera();
        }
    }
}
