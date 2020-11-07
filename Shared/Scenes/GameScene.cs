using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameScene : IScene
    {
        Camera camera;

        Map map;
        Player player;
        
        public GameScene()
        {
            map = new Map(WK.Map.Map1);
            player = new Player();
            camera = new Camera();

        }

        public void Update()
        {
            camera.Update(player);

            map.Update();
            player.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            camera.Draw(spriteBatch);

            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
    }
}
