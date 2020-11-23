
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class House_1 : IScene
    {
        public Camera camera { get; set; }
        public List<IEntity> entities { get; set; }

        public void Initialize(Point startPlayerPosition)
        {
            this.entities = new List<IEntity>()
            {
                new Player(startPlayerPosition,"player"),
                new NPC_2(new Point(3, 11), "npc"),
                new Portal(new Point(4 * WK.Default.Pixels_Y, 13 * WK.Default.Pixels_Y), WK.Scene.GameScene, new Point(7 * WK.Default.Pixels_X, 14 * WK.Default.Pixels_Y), "portal"),
                new Map(WK.Map.Map2, "map")
            };

            this.camera = new Camera();
        }
    }
}