using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Map : IEntity
    {
        Dictionary<string, Texture2D> textures;

        public List<Tile> tiles { get; private set; }
        public string tag { get; private set; }

        public Map(char[,] originalMap, string tag)
        {
            this.tag = tag;
            this.textures = new Dictionary<string, Texture2D>()
            {
                { "map_x", Tools.CreateColorTexture(Color.Brown) },
                { "map_p", Tools.CreateColorTexture(Color.Green) },
                { "map_other", Tools.CreateColorTexture(Color.Red) }
            };

            this.tiles = MapHelpers.PopulateMap(originalMap, textures);
        }
    }

    public class MapHelpers
    {
        public static void Update()
        {
        }

        public static void Draw(SpriteBatch spriteBatch, List<Tile> tiles)
        {
            foreach (var m in tiles) m.Draw(spriteBatch);
        }

        public static List<Tile> PopulateMap(char[,] originalMap, Dictionary<string, Texture2D> textures)
        {
            List<Tile> map = new List<Tile>();// new Tile[originalMap.GetLength(0), originalMap.GetLength(1)];

            for (int row = 0; row < originalMap.GetLength(0); row++)
            {
                for (int elem = 0; elem < originalMap.GetLength(1); elem++)
                {
                    switch (originalMap[row, elem])
                    {
                        case 'x':
                            map.Add(new Tile(textures["map_x"], Layer.Background, new Point(elem * WK.Default.Pixels_X, row * WK.Default.Pixels_Y), "x"));
                            break;
                        case '.':
                            map.Add(new Tile(textures["map_p"], Layer.Background, new Point(elem * WK.Default.Pixels_X, row * WK.Default.Pixels_Y), "."));
                            break;
                        default:
                            map.Add(new Tile(textures["map_other"], Layer.Background, new Point(elem * WK.Default.Pixels_X, row * WK.Default.Pixels_Y), ""));
                            break;
                    }
                }
            }
            return map;
        }
    }
}
