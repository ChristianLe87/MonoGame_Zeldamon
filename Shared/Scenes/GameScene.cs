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
        public bool isDark { get; private set; }

        public void Initialize(Point startPlayerPosition)
        {
            this.isDark = false;

            this.moneyText = new Text("", new Vector2(0, 0));
            this.moneyValue = 0;


            // Populate entities
            this.entities = new List<IEntity>()
            {
                // Add Player
                new Player(startPlayerPosition, Layer.Middle, "player"),

                // Add NPCs
                new NPC_1(new Point(8, 15), Layer.Middle, "npc"),

                // add Portals
                new Portal(new Point(7, 13), WK.Scene.House_1, new Point(4, 12), "portal"),

                // Add Coins
                new Coin(true, new Point(10, 13), Layer.Middle, "coin"),
            };


            // Add Map
            this.entities.AddRange(MapHelper.PopulateMap(WK.Map.Map1));

            camera = new Camera();
        }
    }
}
