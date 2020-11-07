using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Game_Scene : IScene
    {
        Player player;

        public Game_Scene()
        {
            player = new Player();
        }

        public void Update()
        {
            player.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }
    }
}
