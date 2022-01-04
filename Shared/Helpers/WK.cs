using System.Collections.Generic;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class WK
    {
        public class Default
        {
            public static string WindowTitle => "Monogame_Zeldamon";
            public static double FPS => 60;
            public static bool IsFullScreen = false;
            public static bool AllowUserResizing = true;
            public static int ScaleFactor => 1;
            public static int Width { get => AssetSize * 28 * ScaleFactor; }
            public static int Height { get => AssetSize * 16 * ScaleFactor; }
            public static Point Center => new Point(Width / 2, Height / 2);
            public static int AssetSize => 16;
            public static string GameDataFileName => "Monogame_Zeldamon_GameData";
        }

        public class Textures
        {
            public static Texture2D atlasTexture => Tools.Texture.GetTexture("TileCollection_352x288_PNG");

            public static Texture2D Pink => Tools.Texture.CreateColorTexture(Color.Pink, WK.Default.ScaleFactor * WK.Default.AssetSize, WK.Default.ScaleFactor * WK.Default.AssetSize);
            public static Texture2D Red => Tools.Texture.CreateColorTexture(Color.Red, WK.Default.ScaleFactor * WK.Default.AssetSize, WK.Default.ScaleFactor * WK.Default.AssetSize);
            public static Texture2D LightGray => Tools.Texture.CreateColorTexture(Color.LightGray, WK.Default.ScaleFactor * WK.Default.AssetSize, WK.Default.ScaleFactor * WK.Default.AssetSize);


            public class Player
            {
                /*public static Dictionary<CharacterState, (Texture2D[], CharacterState)> textures = new Dictionary<CharacterState, (Texture2D[], CharacterState)>()
                {
                    {"Idle_Up", },
                    {"Idle_Down", },
                    {"Idle_Right", },
                    {"Idle_Left", },
                    {"Walk_Up", },
                    {"Walk_Down", },
                    {"Walk_Right", },
                    {"Walk_Left", },
                };*/
            }

            public class Map
            {
                public class Map1
                {
                    public static Dictionary<int, Texture2D> textures => new Dictionary<int, Texture2D>()
                    {
                        { 0, null },
                        { 1, LightGray },
                        { 2, Red }
                    };
                }
            }
        }

        public class Scene
        {
            public static string GameScene => "GameScene";
            public static string House_1 => "House_1";
            public static string Cave => "Cave";
        }

        public class Map
        {
            public static int[,] Map1 = new int[,]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 1, 2, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 2, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };

            public static int[,] Map2 = new int[,]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 1, 1, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 1, 1, 1, 1, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 1, 1, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 }
            };

            public static int[,] Cave = new int[,]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 1, 1, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 1, 1, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
                { 1, 0, 0, 1, 1, 1, 1, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 }
            };
        }
    }
}