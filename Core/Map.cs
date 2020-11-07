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
                            spriteBatch.Draw(map_x, new Rectangle(x: elem * WK.Default.pixels_x, y: row * WK.Default.pixels_y, width: WK.Default.pixels_x, height: WK.Default.pixels_y), Color.White);
                            break;
                        case '.':
                            spriteBatch.Draw(map_p, new Rectangle(x: elem * WK.Default.pixels_x, y: row * WK.Default.pixels_y, width: WK.Default.pixels_x, height: WK.Default.pixels_y), Color.White);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}