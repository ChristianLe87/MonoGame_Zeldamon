using System.Collections.Generic;
using ChristianTools.Helpers;
using ChristianTools.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class WK
    {
        public class Default : IDefault
        {
            public string WindowTitle => "Monogame_Zeldamon";
            public double FPS => 60;
            public bool IsFullScreen => false;
            public bool AllowUserResizing => true;
            public int ScaleFactor => 2;
            public int canvasWidth { get => AssetSize * 28 * ScaleFactor; }
            public int canvasHeight { get => AssetSize * 16 * ScaleFactor; }
            public int AssetSize => 16;
            public string GameDataFileName => "Monogame_Zeldamon_GameData";
            public bool isMouseVisible { get; set; } = true;
        }

        public class Textures
        {
            public static Texture2D Transparent => Tools.Texture.CreateColorTexture(Color.Transparent, ChristianGame.Default.ScaleFactor * ChristianGame.Default.AssetSize, ChristianGame.Default.ScaleFactor * ChristianGame.Default.AssetSize);
            public static Texture2D Pink => Tools.Texture.CreateColorTexture(Color.Pink, ChristianGame.Default.ScaleFactor * ChristianGame.Default.AssetSize, ChristianGame.Default.ScaleFactor * ChristianGame.Default.AssetSize);
            public static Texture2D Red => Tools.Texture.CreateColorTexture(Color.Red, ChristianGame.Default.ScaleFactor * ChristianGame.Default.AssetSize, ChristianGame.Default.ScaleFactor * ChristianGame.Default.AssetSize);
            public static Texture2D LightGray => Tools.Texture.CreateColorTexture(Color.LightGray, ChristianGame.Default.ScaleFactor * ChristianGame.Default.AssetSize, ChristianGame.Default.ScaleFactor * ChristianGame.Default.AssetSize);

            public class Other
            {
                static Texture2D atlasTexture => Tools.Texture.GetTexture("AtlasTiles_PNG");

                public static Texture2D coin = Tools.Texture.GetUnitTileFromAtlasTexture(atlasTexture, 0, 5, ChristianGame.Default.ScaleFactor);
                public static Texture2D hammer = Tools.Texture.CropTexture(atlasTexture, new Rectangle(1 * ChristianGame.Default.AssetSize, 5 * ChristianGame.Default.AssetSize, 1 * ChristianGame.Default.AssetSize, ChristianGame.Default.AssetSize), ChristianGame.Default.ScaleFactor);
                public static Texture2D key = Tools.Texture.CropTexture(atlasTexture, new Rectangle(2 * ChristianGame.Default.AssetSize, 5 * ChristianGame.Default.AssetSize, 1 * ChristianGame.Default.AssetSize, ChristianGame.Default.AssetSize), ChristianGame.Default.ScaleFactor);
                public static Texture2D keyDoor = Tools.Texture.CropTexture(atlasTexture, new Rectangle(3 * ChristianGame.Default.AssetSize, 5 * ChristianGame.Default.AssetSize, 1 * ChristianGame.Default.AssetSize, ChristianGame.Default.AssetSize), ChristianGame.Default.ScaleFactor);
            }

            public class Player
            {
                static Texture2D atlasTexture = Tools.Texture.GetTexture("Player_96x128_PNG");

                static Texture2D idleUp = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 0 * ChristianGame.Default.AssetSize, 1 * ChristianGame.Default.AssetSize, ChristianGame.Default.AssetSize), ChristianGame.Default.ScaleFactor);
                static Texture2D[] idleUpArr = new Texture2D[] { idleUp };

                static Texture2D idleDown = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 1 * ChristianGame.Default.AssetSize, 1 * ChristianGame.Default.AssetSize, ChristianGame.Default.AssetSize), ChristianGame.Default.ScaleFactor);
                static Texture2D[] idleDownArr = new Texture2D[] { idleDown };

                static Texture2D idleRight = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 2 * ChristianGame.Default.AssetSize, 1 * ChristianGame.Default.AssetSize, ChristianGame.Default.AssetSize), ChristianGame.Default.ScaleFactor);
                static Texture2D[] idleRightArr = new Texture2D[] { idleRight };

                static Texture2D idleLeft = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 3 * ChristianGame.Default.AssetSize, 1 * ChristianGame.Default.AssetSize, ChristianGame.Default.AssetSize), ChristianGame.Default.ScaleFactor);
                static Texture2D[] idleLeftArr = new Texture2D[] { idleLeft };


                static Texture2D moveUp = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 4 * ChristianGame.Default.AssetSize, 6 * ChristianGame.Default.AssetSize, ChristianGame.Default.AssetSize), ChristianGame.Default.ScaleFactor);
                static Texture2D[] moveUpArr = Tools.Texture.SliceHorizontalTexture(moveUp, 6);

                static Texture2D moveDown = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 5 * ChristianGame.Default.AssetSize, 6 * ChristianGame.Default.AssetSize, ChristianGame.Default.AssetSize), ChristianGame.Default.ScaleFactor);
                static Texture2D[] moveDownArr = Tools.Texture.SliceHorizontalTexture(moveDown, 6);

                static Texture2D moveRight = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 6 * ChristianGame.Default.AssetSize, 6 * ChristianGame.Default.AssetSize, ChristianGame.Default.AssetSize), ChristianGame.Default.ScaleFactor);
                static Texture2D[] moveRightArr = Tools.Texture.SliceHorizontalTexture(moveRight, 6);

                static Texture2D moveLeft = Tools.Texture.CropTexture(atlasTexture, new Rectangle(0, 7 * ChristianGame.Default.AssetSize, 6 * ChristianGame.Default.AssetSize, ChristianGame.Default.AssetSize), ChristianGame.Default.ScaleFactor);
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
            public static string House1 => "House1";
            public static string Cave => "Cave";
        }

        public class Map
        {
            public class Map1
            {
                static Texture2D atlasTexture => Tools.Texture.GetTexture("AtlasTiles_PNG");

                public static Dictionary<int, Texture2D> textures = Tools.Texture.GetTileTextures(atlasTexture);

                public static Tiled tiled = Tiled_JsonSerialization.Read<Tiled>("Map1");
            }

            public class House1
            {
                static Texture2D atlasTexture => Tools.Texture.GetTexture("AtlasTiles_PNG");

                public static Dictionary<int, Texture2D> textures = Tools.Texture.GetTileTextures(atlasTexture);

                public static Tiled tiled = Tiled_JsonSerialization.Read<Tiled>("House1");
            }
        }
    }
}