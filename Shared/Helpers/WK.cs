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
            public static int ScaleFactor => 2;
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