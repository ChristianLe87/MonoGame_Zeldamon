using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class MapHelper
    {
        public static void Draw(SpriteBatch spriteBatch, List<Tile> tiles)
        {
            foreach (var tile in tiles) spriteBatch.Draw(tile.texture2D, tile.rectangle, Color.White);
        }

        public static List<IEntity> PopulateMap(char[,] originalMap)
        {
            Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>()
            {
                { "map_x", Tools.GetSubtextureFromAtlasTexture(new Point(3, 5)) },
                { "map_p", Tools.GetSubtextureFromAtlasTexture(new Point(2, 5)) },
                { "map_other", Tools.CreateColorTexture(Color.Red) }
            };

            List<IEntity> map = new List<IEntity>();

            for (int row = 0; row < originalMap.GetLength(0); row++)
            {
                for (int elem = 0; elem < originalMap.GetLength(1); elem++)
                {
                    switch (originalMap[row, elem])
                    {
                        case 'x':
                            map.Add(new Tile(textures["map_x"], new Point(elem, row), true, Layer.Back, "tile"));
                            break;
                        case '.':
                            map.Add(new Tile(textures["map_p"], new Point(elem, row), false, Layer.Back, "tile"));
                            break;
                        default:
                            map.Add(new Tile(textures["map_other"], new Point(elem, row), false, Layer.Back, "tile")); ;
                            break;
                    }
                }
            }
            return map;
        }
    }
}
