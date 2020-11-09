using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    internal class Map
    {
        Texture2D map_x;
        Texture2D map_p;
        Texture2D map_other;

        private Tile[,] map;

        public Map(char[,] originalMap)
        {
            this.map_x = Tools.CreateColorTexture(Color.Brown);
            this.map_p = Tools.CreateColorTexture(Color.Green);
            this.map_other = Tools.CreateColorTexture(Color.Red);

            this.map = PopulateMap(originalMap);
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int elem = 0; elem < map.GetLength(1); elem++)
                {
                    map[row, elem].Draw(spriteBatch);
                }
            }
        }

        private Tile[,] PopulateMap(char[,] originalMap)
        {
            Tile[,] map = new Tile[originalMap.GetLength(0), originalMap.GetLength(1)];

            for (int row = 0; row < originalMap.GetLength(0); row++)
            {
                for (int elem = 0; elem < originalMap.GetLength(1); elem++)
                {
                    switch (originalMap[row, elem])
                    {
                        case 'x':
                            map[row, elem] = new Tile(map_x, Layer.Background, new Point(elem * WK.Default.Pixels_X, row * WK.Default.Pixels_Y), "x");
                            break;
                        case '.':
                            map[row, elem] = new Tile(map_p, Layer.Background, new Point(elem * WK.Default.Pixels_X, row * WK.Default.Pixels_Y), ".");
                            break;
                        default:
                            map[row, elem] = new Tile(map_other, Layer.Background, new Point(elem * WK.Default.Pixels_X, row * WK.Default.Pixels_Y), "");
                            break;
                    }
                }
            }
            return map;
        }
    }
}