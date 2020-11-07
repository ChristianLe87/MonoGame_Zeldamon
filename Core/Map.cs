using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    internal class Map
    {
        Texture2D map_x;
        Texture2D map_p;

        private char[,] map1;

        public Map(char[,] map1)
        {
            this.map1 = map1;
            this.map_x = Tools.CreateColorTexture(Color.Brown);
            this.map_p = Tools.CreateColorTexture(Color.Green);
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int row = 0; row < map1.GetLength(0); row++)
            {
                for (int elem = 0; elem < map1.GetLength(1); elem++)
                {
                    switch (map1[row, elem])
                    {
                        case 'x':
                            spriteBatch.Draw(map_x, new Rectangle(x: elem * WK.Default.Pixels_X, y: row * WK.Default.Pixels_Y, width: WK.Default.Pixels_X, height: WK.Default.Pixels_Y), Color.White);
                            break;
                        case '.':
                            spriteBatch.Draw(map_p, new Rectangle(x: elem * WK.Default.Pixels_X, y: row * WK.Default.Pixels_Y, width: WK.Default.Pixels_X, height: WK.Default.Pixels_Y), Color.White);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}