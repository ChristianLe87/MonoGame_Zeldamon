using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class GameScene : IScene
    {
        Map map;
        Player player;

        public GameScene()
        {
            map = new Map(WK.Map.Map1);
            player = new Player();
        }

        public void Update()
        {
            map.Update();
            player.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
    }
}
