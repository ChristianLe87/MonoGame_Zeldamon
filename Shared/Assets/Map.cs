using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Map
    {
        Texture2D map_x;
        Texture2D map_p;
        Texture2D map_other;

        public List<Tile> map { get; private set; }

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
            foreach (var m in map) m.Draw(spriteBatch);
        }

        private List<Tile> PopulateMap(char[,] originalMap)
        {
            List<Tile> map = new List<Tile>();// new Tile[originalMap.GetLength(0), originalMap.GetLength(1)];

            for (int row = 0; row < originalMap.GetLength(0); row++)
            {
                for (int elem = 0; elem < originalMap.GetLength(1); elem++)
                {
                    switch (originalMap[row, elem])
                    {
                        case 'x':
                            map.Add(new Tile(map_x, Layer.Background, new Point(elem * WK.Default.Pixels_X, row * WK.Default.Pixels_Y), "x"));
                            break;
                        case '.':
                            map.Add(new Tile(map_p, Layer.Background, new Point(elem * WK.Default.Pixels_X, row * WK.Default.Pixels_Y), "."));
                            break;
                        default:
                            map.Add(new Tile(map_other, Layer.Background, new Point(elem * WK.Default.Pixels_X, row * WK.Default.Pixels_Y), ""));
                            break;
                    }
                }
            }
            return map;
        }
    }
}