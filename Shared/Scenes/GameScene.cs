using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameScene : IScene
    {
        Camera camera;

        Map map;
        Player player;

        List<Portal> portals;

        Dialog dialog;

        public void Initialize(Point startPlayerPosition)
        {
            map = new Map(WK.Map.Map1);
            player = new Player(startPlayerPosition);
            camera = new Camera();

            portals = new List<Portal>()
            {
                new Portal(new Point(7 * WK.Default.Pixels_X, 13 * WK.Default.Pixels_Y), WK.Scene.House_1, new Point(4 * WK.Default.Pixels_Y, 12 * WK.Default.Pixels_Y))
            };

            dialog = new Dialog(new string[] { "dfsafdsa" }, new Rectangle(0, 0, WK.Default.CanvasWidth, (WK.Default.CanvasHeight / 3)));
        }

        public void Update()
        {
            camera.Update(player);

            map.Update();
            player.Update();

            foreach (var portal in portals) portal.Update(player);

            dialog.Update(player);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            camera.Draw(spriteBatch);

            map.Draw(spriteBatch);
            player.Draw(spriteBatch);

            foreach (var portal in portals) portal.Draw(spriteBatch);

            dialog.Draw(spriteBatch);
        }
    }
}
