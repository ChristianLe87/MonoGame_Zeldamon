using System.Collections.Generic;
using ChristianTools.Helpers;
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

            public static Texture2D Pink => Tools.Texture.CreateColorTexture(Color.Pink, WK.Default.ScaleFactor * WK.Default.AssetSize, WK.Default.ScaleFactor * WK.Default.AssetSize);
            public static Texture2D Red => Tools.Texture.CreateColorTexture(Color.Red, WK.Default.ScaleFactor * WK.Default.AssetSize, WK.Default.ScaleFactor * WK.Default.AssetSize);
            public static Texture2D LightGray => Tools.Texture.CreateColorTexture(Color.LightGray, WK.Default.ScaleFactor * WK.Default.AssetSize, WK.Default.ScaleFactor * WK.Default.AssetSize);

            public class Other
            {
                static Texture2D atlasTexture => Tools.Texture.GetTexture("TileCollection_32x96_PNG");
                public static Texture2D coin = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 0 * WK.Default.AssetSize, 1 * WK.Default.AssetSize, WK.Default.AssetSize), WK.Default.ScaleFactor);
                public static Texture2D hammer = Tools.Texture.CropTexture(atlasTexture, new Rectangle(1 * WK.Default.AssetSize, 0 * WK.Default.AssetSize, 1 * WK.Default.AssetSize, WK.Default.AssetSize), WK.Default.ScaleFactor);
                public static Texture2D key = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0 * WK.Default.AssetSize, 2 * WK.Default.AssetSize, 1 * WK.Default.AssetSize, WK.Default.AssetSize), WK.Default.ScaleFactor);
            }

            public class Player
            {
                static Texture2D atlasTexture = Tools.Texture.GetTexture("Player_96x128_PNG");

                static Texture2D idleUp = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 0 * WK.Default.AssetSize, 1 * WK.Default.AssetSize, WK.Default.AssetSize), WK.Default.ScaleFactor);
                static Texture2D[] idleUpArr = new Texture2D[] { idleUp };

                static Texture2D idleDown = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 1 * WK.Default.AssetSize, 1 * WK.Default.AssetSize, WK.Default.AssetSize), WK.Default.ScaleFactor);
                static Texture2D[] idleDownArr = new Texture2D[] { idleDown };

                static Texture2D idleRight = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 2 * WK.Default.AssetSize, 1 * WK.Default.AssetSize, WK.Default.AssetSize), WK.Default.ScaleFactor);
                static Texture2D[] idleRightArr = new Texture2D[] { idleRight };

                static Texture2D idleLeft = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 3 * WK.Default.AssetSize, 1 * WK.Default.AssetSize, WK.Default.AssetSize), WK.Default.ScaleFactor);
                static Texture2D[] idleLeftArr = new Texture2D[] { idleLeft };


                static Texture2D moveUp = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 4 * WK.Default.AssetSize, 6 * WK.Default.AssetSize, WK.Default.AssetSize), WK.Default.ScaleFactor);
                static Texture2D[] moveUpArr = Tools.Texture.SliceHorizontalTexture(moveUp, 6);

                static Texture2D moveDown = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 5 * WK.Default.AssetSize, 6 * WK.Default.AssetSize, WK.Default.AssetSize), WK.Default.ScaleFactor);
                static Texture2D[] moveDownArr = Tools.Texture.SliceHorizontalTexture(moveDown, 6);

                static Texture2D moveRight = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 6 * WK.Default.AssetSize, 6 * WK.Default.AssetSize, WK.Default.AssetSize), WK.Default.ScaleFactor);
                static Texture2D[] moveRightArr = Tools.Texture.SliceHorizontalTexture(moveRight, 6);

                static Texture2D moveLeft = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 7 * WK.Default.AssetSize, 6 * WK.Default.AssetSize, WK.Default.AssetSize), WK.Default.ScaleFactor);
                static Texture2D[] moveLeftArr = Tools.Texture.SliceHorizontalTexture(moveLeft, 6);


                public static Dictionary<CharacterState, (Texture2D[], AnimationOption)> animations = new Dictionary<CharacterState, (Texture2D[], AnimationOption)>()
                {
                    { CharacterState.IdleUp, (idleUpArr, AnimationOption.Loop) },
                    { CharacterState.IdleDown, (idleDownArr, AnimationOption.Loop) },
                    { CharacterState.IdleRight, (idleRightArr, AnimationOption.Loop) },
                    { CharacterState.IdleLeft, (idleLeftArr, AnimationOption.Loop) },
                    
                    { CharacterState.MoveUp, (moveUpArr, AnimationOption.Loop) },
                    { CharacterState.MoveDown, (moveDownArr, AnimationOption.Loop) },
                    { CharacterState.MoveRight, (moveRightArr, AnimationOption.Loop) },
                    { CharacterState.MoveLeft, (moveLeftArr, AnimationOption.Loop) }
                };
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

        public class Font
        {
            static Texture2D myFont = Tools.Texture.GetTexture("MyFont_130x28_PNG");

            private static readonly char[,] chars = new char[,]
            {
                    { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                    { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' },
                    { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'Ñ', 'ñ', 'ß','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0','\0' },
                    { ',', ':', ';', '?', '.', '!', ' ','\'','(',')','_','\"','<','>','-','+','\\','\0','\0','\0','\0','\0','\0','\0','\0','\0' }
            };

            public static SpriteFont MyFont = Tools.Font.GenerateFont(myFont, chars);
        }

        public class Scene
        {
            public static string Menu => "GameMenu";
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
                { 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
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
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 0, 1, 1, 1, 1, 1 }
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